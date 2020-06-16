using GestContact.Models.Client.Data;
using GestContact.Models.Client.Mappers;
using GestContact.Repositories;

using G = GestContact.Models.Global.Data;
using GS = GestContact.Models.Global.Services;

namespace GestContact.Models.Client.Services
{
    public class AuthService : IAuthService<Utilisateur>
    {
        IAuthService<G.Utilisateur> _globalService;
        public AuthService()
        {
            _globalService = new GS.AuthService();
        }

        public Utilisateur Login(string email, string passwd)
        {
            return _globalService.Login(email, passwd)?.ToClient();
        }

        public void Register(Utilisateur utilisateur)
        {
            _globalService.Register(utilisateur.ToGlobal());
        }

        public bool EmailIsUsed(string email)
        {
            return _globalService.EmailIsUsed(email);
        }
    }
}
