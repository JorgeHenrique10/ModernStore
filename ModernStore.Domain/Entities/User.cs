using System;
using System.Text;
using Flunt.Validations;
using ModernStore.Shared.Entities;

namespace ModernStore.Domain.Entities
{
    public class User : Entity
    {
        private readonly string _confirmPassword;
        protected User()
        {

        }
        public User(string userName, string password, string confirmPassword)
        {
            UserName = userName;
            Password = EncryptPassword(password);
            Active = true;

            _confirmPassword = EncryptPassword(confirmPassword);
        }

        public string UserName { get; private set; }
        public string Password { get; private set; }
        public bool Active { get; private set; }

        public void Activate()
        {
            Active = true;
        }
        public void Desactivate()
        {
            Active = false;
        }

        private string EncryptPassword(string pass)
        {
            if (string.IsNullOrEmpty(pass)) return "";
            var password = (pass += "|2d331cca-f6c0-40c0-bb43-6e32989c2881");
            var md5 = System.Security.Cryptography.MD5.Create();
            var data = md5.ComputeHash(Encoding.GetEncoding("UTF-8").GetBytes(password));
            var sbString = new StringBuilder();
            foreach (var t in data)
                sbString.Append(t.ToString("x2"));

            return sbString.ToString();
        }
    }
}