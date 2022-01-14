using DevFreela.Application.ViewModels;
using DevFreela.Core.Repositories;
using DevFreela.Core.Service;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.LoginUser
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginViewModel>
    {
        private readonly IUserRepository _repository;
        private readonly IAuthService _authService;

        public LoginCommandHandler(IUserRepository repository, IAuthService authService)
        {
            _repository = repository;
            _authService = authService;
        }

        public async Task<LoginViewModel> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetByEmailAsync(request.Email);
            if (user == null)
            {
                return null;
            }
            var passwordHashed = _authService.ComputSha256Hash(request.Password);
            if (passwordHashed != user.Password)
            {
                return null;
            }

            return new LoginViewModel(request.Email, _authService.GenerateToken(user.Email, user.Role));
        }
    }
}
