using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModernStore.Domain.Entities;
using ModernStore.Domain.ValueObjects;

namespace ModernStore.Domain.Tests
{
    [TestClass]
    public class OrderTests
    {
        [TestMethod]
        public void Dado_um_produto_fora_de_estoque_retorne_uma_notificacao()
        {
            var User = new User("jorgehenrique", "123456", "123456");
            var Nome = new Name("Jorge", "Henrique");
            var Email = new Email("email@email.com");
            var Document = new Document("01877122556");
            var Customer = new Customer(Nome, DateTime.Now, Email, Document, User);
            var mouse = new Product("Mouse", 100, "mouse.jpg", 0);

            var order = new Order(Customer, 8, 10);
            var item = new OrderItem(mouse, 2);

            item.Validate();
            order.Validate();
            if (item.Valid)
                order.AddItem(item);
            Console.WriteLine(order.Items.Count);
            Assert.AreEqual(0, order.Items.Count);
        }

        [TestMethod]
        public void Dado_um_produto_em_estoque_deve_fazer_um_decremento_em_QuantityOnHand()
        {
            var User = new User("jorgehenrique", "123456", "123456");
            var Nome = new Name("Jorge", "Henrique");
            var Email = new Email("email@email.com");
            var Document = new Document("01877122556");
            var Customer = new Customer(Nome, DateTime.Now, Email, Document, User);
            var mouse = new Product("Mouse", 100, "mouse.jpg", 20);

            var order = new Order(Customer, 8, 10);
            var item = new OrderItem(mouse, 2);

            item.Validate();
            order.Validate();
            if (item.Valid)
                order.AddItem(item);
            Console.WriteLine(order.Items.Count);
            Assert.AreEqual(18, mouse.QuantityOnHand);
        }

    }
}