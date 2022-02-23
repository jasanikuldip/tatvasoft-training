using Helperland.IServices;
using Helperland.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helperland.Services
{
    public class ServiceRequestService : IServiceRequestService
    {
        private readonly HelperlandContext context;

        public ServiceRequestService(HelperlandContext context)
        {
            this.context = context;
        }

        public async Task<ServiceRequestAddress> AddAddressAsync(ServiceRequestAddress sra)
        {
            await context.ServiceRequestAddresses.AddAsync(sra);
            await context.SaveChangesAsync();
            return sra;
        }

        public async Task<ServiceRequest> AddAsync(ServiceRequest sr)
        {
            await context.ServiceRequests.AddAsync(sr);
            await context.SaveChangesAsync();
            return sr;
        }

        public Task<IEnumerable<ServiceRequest>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
