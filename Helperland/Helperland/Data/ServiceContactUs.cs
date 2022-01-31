using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Helperland.Models;

namespace Helperland.Data
{
    public class ServiceContactUs : IContactUs
    {
        private readonly HelperlandContext context;

        public ServiceContactUs(HelperlandContext context)
        {
            this.context = context;
        }
        public ContactU Create(ContactU contact)
        {
            context.ContactUs.Add(contact);
            context.SaveChanges();
            return contact;
        }
    }
}
