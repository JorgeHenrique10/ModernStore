using System;

namespace ModernStore.Domain.Entities
{
    public class User
    {
        public User(string userName, string password)
        {
            Id = Guid.NewGuid();
            UserName = userName;
            Password = password;
            Active = true;
        }

        public Guid Id { get; private set; }
        public string UserName { get; private set; }
        public string Password { get; private set; }
        public bool Active { get; private set; }

        public void Activate()
        {
            Active = true;
        }
        public void Deactivate()
        {
            Active = false;
        }
    }
}