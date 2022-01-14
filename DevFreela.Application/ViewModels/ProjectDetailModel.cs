using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.ViewModels
{
    public class ProjectDetailModel
    {
        public ProjectDetailModel(int id, string title, string description, decimal totalCost, DateTime createdAt, DateTime? startedAt, string clientFullName, string freeLancerFullName)
        {
            Id = id;
            Title = title;
            Description = description;
            TotalCost = totalCost;
            CreatedAt = createdAt;
            StartedAt = startedAt;
            ClientFullName = clientFullName;
            FreeLancerFullName = freeLancerFullName;
        }

        public int Id { get; set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public decimal TotalCost { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? StartedAt { get; private set; }
        public string ClientFullName { get; private set; }
        public string FreeLancerFullName { get; private set; }

    }
}
