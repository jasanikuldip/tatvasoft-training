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
        Task<ServiceRequestExtra> AddExtrasAsync(ServiceRequestExtra serviceRequestExtra);
        IEnumerable<ServiceRequest> GetAllByUserIdNotCompletedCancelled(int UserId);
        IEnumerable<ServiceRequest> GetAllByUserIdCompletedCancelled(int UserId);
        ServiceRequest GetById(int id);
        IEnumerable<ServiceRequest> GetBySPId(int SPId);
        Task<ServiceRequest> UpdateAsync(ServiceRequest serviceRequestChange);
        Task<Rating> AddRatingAsync(Rating rating);
        Task<Rating> UpdateRatingAsync(Rating ratingChange);
        IEnumerable<Rating> GetAllRating();
        IEnumerable<ServiceRequest> GetAllNotAssignedService(int SPId);
        IEnumerable<ServiceRequest> UpcomingServicesForSP(int SPId);
        IEnumerable<ServiceRequest> ServiceHistorySP(int SPId);
        IEnumerable<Rating> MyRatingsList(int SPId);
    }
}
