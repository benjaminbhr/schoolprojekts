using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptographyInDotNet
{
    public class DBManager
    {
        private DBHandler dbHandler = new DBHandler();

        public string GetPasswordSaltFromDb(string username)
        {
            return dbHandler.GetSaltFromUser(username);
        }

        public string GetHashedPasswordFromDb(string username)
        {
            return dbHandler.GetHashedPasswordFromUser(username);
        }
    }
}
