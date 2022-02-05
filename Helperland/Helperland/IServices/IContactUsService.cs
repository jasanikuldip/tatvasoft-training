using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Helperland.Models;

namespace Helperland.Data
{
    public interface IContactUsService
    {
        Task<ContactU> CreateAsync(ContactU contact);
    }
}
