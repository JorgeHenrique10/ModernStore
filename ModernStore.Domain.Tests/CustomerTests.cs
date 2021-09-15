using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModernStore.Domain.Entities;
using ModernStore.Domain.ValueObjects;

namespace ModernStore.Domain.Tests
{
    [TestClass]
    public class CustomerTests
    {
        [TestMethod]
        // [TestCategory("Customer - New Customer")]
        public void Dado_um_FirstName_invalido_deve_retornar_uma_notificacao()
        {
            var User = new User("jorgehenrique", "123456", "123456");
            var Nome = new Name("a", "henrique");
            var Email = new Email("email@email.com");
            var Document = new Document("01877122556");
            var Customer = new Customer(Nome, DateTime.Now, Email, Document, User);

            Customer.Validate();

            foreach (var item in Customer.Notifications)
            {
                Console.WriteLine(item.Message);
            }

            Assert.AreEqual(false, Customer.Valid);
        }
        [TestMethod]
        public void Dado_um_LastName_invalido_deve_retornar_uma_notificacao()
        {
            var User = new User("jorgehenrique", "123456", "123456");
            var Nome = new Name("jorgehenrique", "h");
            var Email = new Email("email@email.com");
            var Document = new Document("01877122556");
            var Customer = new Customer(Nome, DateTime.Now, Email, Document, User);

            Customer.Validate();

            Assert.AreEqual(false, Customer.Valid);
        }
        [TestMethod]
        public void Dado_um_Email_invalido_deve_retornar_uma_notificacao()
        {
            var User = new User("jorgehenrique", "123456", "123456");
            var Nome = new Name("jorgehenrique", "henrique");
            var Email = new Email("e");
            var Document = new Document("01877122556");
            var Customer = new Customer(Nome, DateTime.Now, Email, Document, User);

            Customer.Validate();

            Assert.AreEqual(false, Customer.Valid);
        }
    }
}
