using GestContact.Models.Global.Data;
using GestContact.Models.Global.Mappers;
using GestContact.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBox;

namespace GestContact.Models.Global.Services
{
    public class AuthService : IAuthService<Utilisateur>
    {
        private Connection _connection;

        public AuthService()
        {
            _connection = new Connection(ConfigurationManager.ConnectionStrings["GestContact"].ConnectionString, SqlClientFactory.Instance);
        }        

        public Utilisateur Login(string email, string passwd)
        {
            Command command = new Command("CheckUser", true);
            command.AddParameter("Email", email);
            command.AddParameter("Passwd", passwd);

            return _connection.ExecuteReader(command, r => r.ToUtilisateur()).SingleOrDefault();
        }

        public void Register(Utilisateur utilisateur)
        {
            Command command = new Command("AddUtilisateur", true);
            command.AddParameter("Nom", utilisateur.Nom);
            command.AddParameter("Prenom", utilisateur.Prenom);
            command.AddParameter("Email", utilisateur.Email);
            command.AddParameter("Passwd", utilisateur.Passwd);
            _connection.ExecuteNonQuery(command);
            utilisateur.Passwd = null;
        }

        public bool EmailIsUsed(string email)
        {
            Connection connection = new Connection(ConfigurationManager.ConnectionStrings["GestContact"].ConnectionString, SqlClientFactory.Instance);

            Command command = new Command("Select count(*) from Utilisateurs where Email = @Email");
            command.AddParameter("Email", email ?? (object)DBNull.Value);

            return 0 == (int)connection.ExecuteScalar(command);
        }
    }
}
