using Flunt.Notifications;
using Flunt.Validations;

namespace ModernStore.Domain.ValueObjects
{
    public class Document : Notifiable, IValidatable
    {
        public Document(string number)
        {
            Number = number;
        }

        public string Number { get; private set; }
        public void Validate()
        {
            bool cpfValido;

            var multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            var multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            var cpf = Number.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
            {
                cpfValido = false;
            }
            else
            {
                var tempCpf = cpf.Substring(0, 9);
                var soma = 0;

                for (var i = 0; i < 9; i++)
                    soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
                var resto = soma % 11;
                if (resto < 2)
                    resto = 0;
                else
                    resto = 11 - resto;
                var digito = resto.ToString();
                tempCpf = tempCpf + digito;
                soma = 0;
                for (var i = 0; i < 10; i++)
                    soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
                resto = soma % 11;
                if (resto < 2)
                    resto = 0;
                else
                    resto = 11 - resto;
                digito = digito + resto.ToString();
                cpfValido = cpf.EndsWith(digito);
            }


            AddNotifications(
                     new Contract()
                         .Requires()
                         .IsTrue(cpfValido, "Number", "CPF Invalido!")
                 );
        }
    }
}