using DevFreela.Core.DTOs;
using DevFreela.Core.Repositories;
using DevFreela.Core.Service;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.FinishProject
{
    internal class FinishProjectCommandHandler : IRequestHandler<FinishProjectCommand, bool>
    {
        private readonly IProjectRepository _repository;
        private readonly IPaymentService _paymentService;

        public FinishProjectCommandHandler(IProjectRepository repository, IPaymentService paymentService)
        {
            _repository = repository;
            _paymentService = paymentService;
        }

        public async Task<bool> Handle(FinishProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _repository.GetByIdAsync(request.Id);
            if (project == null)
            {
                throw new ArgumentException("O Id Informado não existe", nameof(request.Id));
            }

            var paymentDto = new PaymentInfoDTO(request.Id, request.CreditCardNumber, request.Cvv, request.ExpiresAt, request.FullName);
            var result = await _paymentService.ProcessPayment(paymentDto);

            if (!result)
            {
                project.SetPaymentPending();
            }

            project.Finish();
            await _repository.SaveChangesAsync();
            return true;

        }
    }
}
