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

        public IEnumerable<ServiceRequest> GetAllByUserIdNotCompletedCancelled(int UserId)
        {
            return context.ServiceRequests
                   .Include(x => x.ServiceProvider)
                   .ThenInclude(x => x.RatingRatingToNavigations).AsSplitQuery()
                   .Where(x => x.UserId == UserId && (x.Status == 1 || x.Status == 2))
                   .Select(s => new ServiceRequest
                   {
                       ServiceRequestId = s.ServiceRequestId,
                       TotalCost = s.TotalCost,
                       ServiceProviderId = s.ServiceProviderId,
                       ServiceStartDate = s.ServiceStartDate,
                       ServiceHours = s.ServiceHours,
                       ServiceProvider = s.ServiceProvider,
                       Ratings = s.ServiceProvider.RatingRatingToNavigations,
                       Status = s.Status
                   });
        }

        public IEnumerable<ServiceRequest> GetAllByUserIdCompletedCancelled(int UserId)
        {
            return context.ServiceRequests
                   .Include(x => x.ServiceProvider)
                   .ThenInclude(x => x.RatingRatingToNavigations).AsSplitQuery()
                   .Where(x => x.UserId == UserId && (x.Status == 3 || x.Status == 4))
                   .Select(s => new ServiceRequest
                   {
                       ServiceRequestId = s.ServiceRequestId,
                       TotalCost = s.TotalCost,
                       ServiceProviderId = s.ServiceProviderId,
                       ServiceStartDate = s.ServiceStartDate,
                       ServiceHours = s.ServiceHours,
                       ServiceProvider = s.ServiceProvider,
                       Ratings = s.ServiceProvider.RatingRatingToNavigations,
                       Status = s.Status
                   });
        }

        public Task<IEnumerable<ServiceRequest>> GetAll()
        {
            throw new NotImplementedException();
        }

        public ServiceRequest GetById(int id)
        {
            return context.ServiceRequests
                   .Include(x => x.ServiceRequestAddresses)
                   .Include(x => x.ServiceRequestExtras)
                   .Include(x => x.ServiceProvider)
                   .Include(x => x.User)
                   .FirstOrDefault(x => x.ServiceRequestId == id);
        }

        public IEnumerable<ServiceRequest> GetBySPId(int SPId)
        {
            return context.ServiceRequests.Where(x => x.ServiceProviderId == SPId);
        }

        public async Task<ServiceRequest> UpdateAsync(ServiceRequest serviceRequestChange)
        {
            var serviceRequest = context.ServiceRequests.Attach(serviceRequestChange);
            serviceRequest.State = EntityState.Modified;
            await context.SaveChangesAsync();
            return serviceRequestChange;
        }

        public async Task<Rating> AddRatingAsync(Rating rating)
        {
            await context.Ratings.AddAsync(rating);
            await context.SaveChangesAsync();
            return rating;
        }

        public async Task<Rating> UpdateRatingAsync(Rating ratingChange)
        {
            try
            {
                var rating = context.Ratings.Attach(ratingChange);
                rating.State = EntityState.Modified;
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

            }
            return ratingChange;
        }

        public IEnumerable<Rating> GetAllRating()
        {
            return context.Ratings;
        }

        public IEnumerable<ServiceRequest> GetAllNotAssignedSP()
        {
            return context.ServiceRequests
                   .Include(x => x.ServiceRequestAddresses)
                   .Include(x => x.User)
                   .Where(x => x.Status == 1);
        }
    }
}
