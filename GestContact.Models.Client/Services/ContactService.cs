using GestContact.Models.Client.Data;
using G = GestContact.Models.Global.Data;
using GS = GestContact.Models.Global.Services;
using GestContact.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestContact.Models.Client.Mappers;

namespace GestContact.Models.Client.Services
{
    public class ContactService : IContactService<Contact>
    {
        private IContactService<G.Contact> _globalService;

        public ContactService()
        {
            _globalService = new GS.ContactService();
        }        

        public IEnumerable<Contact> Get(int userId)
        {
            return _globalService.Get(userId).Select(c => c.ToClient());
        }

        public Contact Get(int userId, int id)
        {
            return _globalService.Get(userId, id)?.ToClient();
        }

        public Contact Insert(Contact contact)
        {
            return _globalService.Insert(contact.ToGlobal()).ToClient();
        }

        public bool Update(int id, Contact contact)
        {
            return _globalService.Update(id, contact.ToGlobal());
        }

        public bool Delete(int userId, int id)
        {
            return _globalService.Delete(userId, id);
        }
    }
}
