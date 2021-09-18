namespace ModernStore.Domain.Commands.Queries
{
    public class CustomerComandQueries
    {
        public CustomerComandQueries(string nome, string documento, string email, string userName, string password, bool active)
        {
            Nome = nome;
            Documento = documento;
            Email = email;
            UserName = userName;
            Password = password;
            Active = active;
        }

        public string Nome { get; set; }
        public string Documento { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool Active { get; set; }
    }
}