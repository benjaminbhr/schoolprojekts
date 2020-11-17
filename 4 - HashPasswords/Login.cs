using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace CryptographyInDotNet
{
    public class Login
    {
        public string TryLogin(string username, string password)
        {
            try
            {
                DBManager dbmanager = new DBManager();
                string usersalt = dbmanager.GetPasswordSaltFromDb(username);
                byte[] temp = Convert.FromBase64String(usersalt);
                //Convert.ToBase64String(usersalt);
                string userpwhashed = dbmanager.GetHashedPasswordFromDb(username).Replace(" ", "");
                var userinputHashed = Hash.HashPasswordWithSalt(Encoding.UTF8.GetBytes(password), temp);
                if (userinputHashed == "" && userpwhashed == "")
                {
                    return $"Login was not successful, [{username}] does not exist";
                }
                else if (userinputHashed == userpwhashed)
                {
                    return $"Login was successful! Welcome {username}";
                }
                else
                {
                    return "Password is wrong, try again!";
                }
            }
            catch (Exception e)
            {
                return "Something went wrong, please try again!";
            }

            return null;
        }
    }
}
