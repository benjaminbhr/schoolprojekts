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
            //Clean byte arr
            byte[] salt = Hash.GenerateSalt();
            string saltString = Convert.ToBase64String(salt);
            string pw = Hash.HashPasswordWithSalt(Encoding.UTF8.GetBytes(password),salt);
            DBHandler db = new DBHandler();
            //Salt ligger som base 64 string
            db.CreateAccountInDb(username,saltString,pw);

        }
    }
}
