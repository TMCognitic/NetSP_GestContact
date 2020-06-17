using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestContact.Repositories
{
    public interface IContactService<TContact>
    {
        IEnumerable<TContact> Get(int userId);
        TContact Get(int userId, int id);
        TContact Insert(TContact contact);
        bool Update(int id, TContact contact);
        bool Delete(int userId, int id);
    }
}
