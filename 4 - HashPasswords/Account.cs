using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptographyInDotNet
{
    public class Account
    {
        public void CreateAccount(string username, string password)
        {
            var salt = Hash.GenerateSalt();
            var pw = Hash.HashPasswordWithSalt(Encoding.UTF8.GetBytes(password),salt);
            DBHandler db = new DBHandler();
            string saltString = Convert.ToBase64String(salt);
            db.CreateAccountInDb(username,saltString,pw);

        }
    }
}
