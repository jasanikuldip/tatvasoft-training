using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Helperland.Models;

namespace Helperland.Data
{
    public class ContactUsService : IContactUsService
    {
        private readonly HelperlandContext context;

        public ContactUsService(HelperlandContext context)
        {
            this.context = context;
        }
        public async Task<ContactU> CreateAsync(ContactU contact)
        {
            await context.ContactUs.AddAsync(contact);
            await context.SaveChangesAsync();
            return contact;
        }
    }
}
