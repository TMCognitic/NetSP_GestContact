using GestContact.Models.Global.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestContact.Models.Global.Mappers
{
    internal static class IDataRecordExtensions
    {
        internal static Utilisateur ToUtilisateur(this IDataRecord dataRecord)
        {
            return new Utilisateur() { Id = (int)dataRecord["Id"], Nom = (string)dataRecord["Nom"], Prenom = (string)dataRecord["Prenom"], Email = (string)dataRecord["Email"] };
        }
    }
}
