using DevFreela.Core.DTOs;
using DevFreela.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Infrastructure.PaymentServices
{
    public class PaymentService : IPaymentService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        
        public Task<bool> ProcessPayment(PaymentInfoDTO payment)
        {
            return Task.FromResult(true);
        }
    }
}
