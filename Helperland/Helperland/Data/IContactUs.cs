using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Helperland.Models;

namespace Helperland.Data
{
    public interface IContactUs
    {
        public ContactU Create(ContactU contact);
    }
}
