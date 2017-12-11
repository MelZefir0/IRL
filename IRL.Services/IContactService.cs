using IRL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRL.Services
{
    public interface IContactService
    {
        bool CreateContact(ContactCreate model);
        IEnumerable<ContactListItem> GetContacts();
        ContactDetail GetContactById(int contactId);
        bool UpdateContact(ContactEdit model);
        bool DeleteContact(int contactId);
    }
}
