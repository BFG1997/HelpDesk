using HelpDesk.Application.Common.Interfaces;
using HelpDesk.Infrastructure.Settings;
using Microsoft.Extensions.Options;
using System.Runtime;

namespace HelpDesk.Infrastructure.Services;

public class FileStorageService : IFileStorageService
{
    private readonly FileStorageSettings _settings;

    public FileStorageService(IOptions<FileStorageSettings> options)
    {
        _settings = options.Value;
    }

    public async Task<string> SaveAsync(Stream stream, string fileName, string contentType, CancellationToken cancellationToken)
    {
        // Убедимся, что папка существует
        if (!Directory.Exists(_settings.UploadRootPath))
            Directory.CreateDirectory(_settings.UploadRootPath);

        // Генерируем уникальное имя файла
        var uniqueFileName = $"{Guid.NewGuid()}_{fileName}";
        var fullPath = Path.Combine(_settings.UploadRootPath, uniqueFileName);

        // Сохраняем файл
        await using var fileStream = new FileStream(fullPath, FileMode.Create);
        await stream.CopyToAsync(fileStream, cancellationToken);

        // Возвращаем только имя файла (относительный путь для хранения в БД)
        return uniqueFileName;
    }

    public async Task<Stream> GetAsync(string storagePath, CancellationToken cancellationToken)
    {
        var fullPath = Path.Combine(_settings.UploadRootPath, storagePath);
        if (!File.Exists(fullPath))
            throw new FileNotFoundException("File not found", storagePath);

        var memoryStream = new MemoryStream();
        await using var fileStream = new FileStream(fullPath, FileMode.Open, FileAccess.Read);
        await fileStream.CopyToAsync(memoryStream, cancellationToken);
        memoryStream.Position = 0;
        return memoryStream;
    }

    public Task DeleteAsync(string storagePath, CancellationToken cancellationToken)
    {
        var fullPath = Path.Combine(_settings.UploadRootPath, storagePath);
        if (File.Exists(fullPath))
            File.Delete(fullPath);

        return Task.CompletedTask;
    }
}
