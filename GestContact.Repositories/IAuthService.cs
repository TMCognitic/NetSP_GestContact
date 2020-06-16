using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestContact.Repositories
{
    public interface IAuthService<TUtilisateur>
    {
        void Register(TUtilisateur utilisateur);
        TUtilisateur Login(string email, string passwd);
        bool EmailIsUsed(string email);
    }
}
