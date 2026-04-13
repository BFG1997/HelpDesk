using HelpDesk.Application.Common.Interfaces;
using HelpDesk.Application.Features.Auth.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelpDesk.Application.Features.Auth.Commands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, AuthResponse>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public LoginCommandHandler(IApplicationDbContext applicationDbContext, IPasswordHasher passwordHasher, IJwtTokenGenerator jwtTokenGenerator)
        {
            _applicationDbContext = applicationDbContext;
            _passwordHasher = passwordHasher;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<AuthResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _applicationDbContext.Users.FirstOrDefaultAsync(x => x.Email == request.Email, cancellationToken);

            if (user == null)
            {
                throw new UnauthorizedAccessException("Пользователя с таким Email не существует");
            }

            if (!_passwordHasher.Verify(request.Password, user.PasswordHash))
            {
                throw new UnauthorizedAccessException("Email или пароль не верные");
            }

            var token = _jwtTokenGenerator.Generate(user);

            return new AuthResponse()
            {
                UserId = user.Id,
                Email = user.Email,
                Role = user.Role,
                DisplayName = user.DisplayName,
                Token = token
            };
        }
    }
}
