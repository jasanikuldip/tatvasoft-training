using Helperland.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helperland.IServices
{
    public interface IServiceRequestService
    {
        IEnumerable<ServiceRequest> GetAll();

    }
}
