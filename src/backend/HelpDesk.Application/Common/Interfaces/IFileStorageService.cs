using System;
using System.Collections.Generic;
using System.Text;

namespace HelpDesk.Application.Common.Interfaces
{
    public interface IFileStorageService
    {
        /// <summary>
        /// Сохраняет файл и возвращает путь для последующего доступа.
        /// </summary>
        Task<string> SaveAsync(Stream stream, string fileName, string contentType, CancellationToken cancellationToken);

        /// <summary>
        /// Возвращает поток для скачивания файла.
        /// </summary>
        Task<Stream> GetAsync(string path, CancellationToken cancellationToken);

        /// <summary>
        /// Удаляет файл.
        /// </summary>
        Task DeleteAsync(string path, CancellationToken cancellationToken);
    }
}
