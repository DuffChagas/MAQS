using CognizantSoftvision.Maqs.BaseDatabaseTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;


namespace Tests
{
    [TestClass]
    public class HW4_DatabaseTest : BaseDatabaseTest
    {
        //HW 4 Run atleast 1 query
        //Get User Id
        [TestMethod]
        public void GetUserIdWithFirstnameAndLastNameTest()
        {
            string firstname = "Jeff";
            string lastname = "Xiong";

            //Write a query test and get the result back as an object
            var userId = DatabaseDriver.Query<User>($"SELECT Id FROM 'users' where FirstName='{firstname}' and LastName='{lastname}'");
            Assert.AreEqual(3, userId.First().Id);
        }

        [TestMethod]
        public void CreateNewOrderTest()
        {
            int expectedCountAfterInsert = DatabaseDriver.Query<Order>("SELECT Id FROM 'orders' where OrderName='My New House'").ToList().Count + 1;

            Order newOrder = new Order
            {
                OrderId = 100,
                OrderName = "My New House",
                ProductId = 4,
                UserId = 10
            };

            DatabaseDriver.Insert(newOrder);

            int currentOrderCount = DatabaseDriver.Query<Order>("SELECT Id FROM 'orders' where OrderName='My New House'").ToList().Count;

            Assert.AreEqual(expectedCountAfterInsert, currentOrderCount);
        }

        [TestMethod]
        public void EditOrderTest()
        {
            var order = DatabaseDriver.Query<Order>("SELECT * from 'orders' where OrderId='6'").First();
            order.OrderName = "My revised order";
            bool isOrderUpdated = DatabaseDriver.Update(order);

            Assert.AreEqual(true, isOrderUpdated, "Expected record to be updated.");
        }

        [TestMethod]
        public void RemoveOrderTest()
        {
            int orderCountBeforeDelete = DatabaseDriver.Query<Order>("SELECT * from 'orders' where OrderId='2378'").ToList().Count;
            var order = DatabaseDriver.Query<Order>("SELECT Id from 'orders' where OrderId='2378'");

            DatabaseDriver.Delete(order.First());

            int orderCountAfterDelete = DatabaseDriver.Query<Order>("SELECT Id from 'orders' where OrderId='2378'").ToList().Count;
            Assert.AreEqual(orderCountBeforeDelete - 1, orderCountAfterDelete);
        }

        [TestMethod]
        public void ExecuteTest()
        {
            int result = DatabaseDriver.Execute("DELETE FROM 'orders' where OrderName='JeffsOrder'");
            Assert.AreEqual(2, result);
        }

    }
}
