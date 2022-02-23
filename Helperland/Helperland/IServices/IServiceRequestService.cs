using Helperland.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helperland.IServices
{
    public interface IServiceRequestService
    {
        Task<IEnumerable<ServiceRequest>> GetAll();

        Task<ServiceRequest> AddAsync(ServiceRequest sr);
        Task<ServiceRequestAddress> AddAddressAsync(ServiceRequestAddress sra);
    }
}
