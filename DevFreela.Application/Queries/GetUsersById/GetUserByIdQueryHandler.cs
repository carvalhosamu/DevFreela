using DevFreela.Application.InputModels;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Queries.GetUsersById
{
    internal class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDetailModel>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByIdQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserDetailModel> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _userRepository.GetByIdAsync(request.Id);

            if (result != null)
            {
                return new UserDetailModel(result.FullName, result.Email, result.BirthDate, result.CreatedAt, result.Active);
            }

            throw new ArgumentException("Id Não encontrado");
        }
    }
}
