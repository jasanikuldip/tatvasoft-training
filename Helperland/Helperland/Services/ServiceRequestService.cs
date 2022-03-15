using Helperland.IServices;
using Helperland.Models;
using Microsoft.EntityFrameworkCore;
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

        public async Task<ServiceRequestExtra> AddExtrasAsync(ServiceRequestExtra serviceRequestExtra)
        {
            await context.ServiceRequestExtras.AddAsync(serviceRequestExtra);
            await context.SaveChangesAsync();
            return serviceRequestExtra;
        }

        public async Task<ServiceRequest> AddAsync(ServiceRequest sr)
        {
            await context.ServiceRequests.AddAsync(sr);
            await context.SaveChangesAsync();
            return sr;
        }

        public IEnumerable<ServiceRequest> GetAllByUserIdNotCompleted(int UserId)
        {
            return context.ServiceRequests
                   .Include(x => x.ServiceProvider)
                   .Include(x => x.Ratings)
                   .Include(x => x.ServiceRequestAddresses)
                   .Include(x => x.ServiceRequestExtras)
                   .Where  (x => x.Status == 1);
        }

        public Task<IEnumerable<ServiceRequest>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
