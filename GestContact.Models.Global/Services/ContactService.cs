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
    public class ContactService : IContactService<Contact>
    {
        private Connection _connection;

        public ContactService()
        {
            _connection = new Connection(ConfigurationManager.ConnectionStrings["GestContact"].ConnectionString, SqlClientFactory.Instance);
        }

        public IEnumerable<Contact> Get(int userId)
        {
            Command command = new Command("Select Id, Nom, Prenom, Email, Tel, UtilisateurId from Contacts where UtilisateurId = @UtilisateurId;");
            command.AddParameter("UtilisateurId", userId);

            return _connection.ExecuteReader(command, r => r.ToContact());
        }

        public Contact Get(int userId, int id)
        {
            Command command = new Command("Select Id, Nom, Prenom, Email, Tel, UtilisateurId from Contacts where Id = @Id and UtilisateurId = @UtilisateurId;");
            command.AddParameter("Id", id);
            command.AddParameter("UtilisateurId", userId);

            return _connection.ExecuteReader(command, r => r.ToContact()).SingleOrDefault();
        }

        public Contact Insert(Contact contact)
        {
            Command command = new Command("insert into Contacts (Nom, Prenom, Email, Tel, UtilisateurId) output inserted.Id values (@Nom, @Prenom, @Email, @Tel, @UtilisateurId);");
            command.AddParameter("Nom", contact.Nom);
            command.AddParameter("Prenom", contact.Prenom);
            command.AddParameter("Email", contact.Email);
            command.AddParameter("Tel", contact.Tel);
            command.AddParameter("UtilisateurId", contact.UtilisateurId);
            contact.Id = (int)_connection.ExecuteScalar(command);

            return contact;
        }

        public bool Update(int id, Contact contact)
        {
            Command command = new Command("update Contacts Set Nom = @Nom, Prenom = @Prenom, Email = @Email, Tel = @Tel where Id = @Id and UtilisateurId = @UtilisateurId;");
            command.AddParameter("Id", id);
            command.AddParameter("Nom", contact.Nom);
            command.AddParameter("Prenom", contact.Prenom);
            command.AddParameter("Email", contact.Email);
            command.AddParameter("Tel", contact.Tel);
            command.AddParameter("UtilisateurId", contact.UtilisateurId);

            return _connection.ExecuteNonQuery(command) == 1;
        }

        public bool Delete(int userId, int id)
        {
            Command command = new Command("Delete from Contacts where Id = @Id and UtilisateurId = @UtilisateurId;");
            command.AddParameter("Id", id);
            command.AddParameter("UtilisateurId", userId);

            return _connection.ExecuteNonQuery(command) == 1;
        }

    }
}
