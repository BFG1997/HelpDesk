using HelpDesk.Application.Common.Interfaces;
using HelpDesk.Application.Features.Auth.DTOs;
using HelpDesk.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelpDesk.Application.Features.Auth.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, AuthResponse>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public RegisterCommandHandler(IApplicationDbContext applicationDbContext, IPasswordHasher passwordHasher, IJwtTokenGenerator jwtTokenGenerator)
        {
            _applicationDbContext = applicationDbContext;
            _passwordHasher = passwordHasher;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<AuthResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var existingUser = await _applicationDbContext.Users.FirstOrDefaultAsync(x => x.Email == request.Email, cancellationToken);

            if (existingUser != null)
            {
                throw new Exception("Пользователь с таким email уже есть");
            }

            var user = new User()
            {
                Id = Guid.NewGuid(),
                DisplayName = request.DisplayName,
                Email = request.Email,
                PasswordHash = _passwordHasher.Hash(request.Password),
                Role = Domain.Enums.UserRole.Client
            };

            await _applicationDbContext.Users.AddAsync(user);
            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            var token = _jwtTokenGenerator.Generate(user);

            return new AuthResponse
            {
                Token = token,
                DisplayName = user.DisplayName,
                Email = user.Email,
                UserId = user.Id,
                Role = user.Role
            };
        }
    }
}
