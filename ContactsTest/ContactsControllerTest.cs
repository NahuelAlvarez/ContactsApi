

using ContactsApi.Context;
using ContactsApi.Controllers;
using ContactsApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Xunit;

namespace ContactsTest
{

    public class ContactsControllerTest
    {

        private const string CONNECTION_STRING =
            "Data Source=[Your Server Path];Initial Catalog=DB_Contacts;Integrated Security=True;";

        [Fact]
        //IntegrityTest with instantiated SQL Server Data Base
        public async Task AsyncGetContactsTest()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseSqlServer(CONNECTION_STRING)
                .Options;

            using (var context = new DataContext(options))
            {
                await context.Database.EnsureCreatedAsync();
                var controller = new ContactsApiController(context);
                //Act
                var result = await controller.GetContacts();
                ////Assert
                Assert.NotNull(result);
                Assert.IsType<OkObjectResult>(result.Result);
            }
        }

        [Fact]
        public async Task AsyncGetContactByIdTest()
        {
            // Arrange
            var testGuid = new Guid("31b9ba25-d213-44b5-a0ea-1dc7d9ca6300");

            var options = new DbContextOptionsBuilder()
                 .UseSqlServer(CONNECTION_STRING)
                 .Options;

            using (var context = new DataContext(options))
            {
                await context.Database.EnsureCreatedAsync();
            }

            // Act
            using (var context = new DataContext(options))
            {
                var controller = new ContactsApiController(context);
                var result = await controller.GetContactById(testGuid);
                //Assert
                Assert.NotNull(result);
                Assert.IsType<ActionResult<Contact>>(result);
            }

        }

        [Fact]
        // Integrity Test with SqLite Data Base in memory
        public async Task AsyncNewContactTest()
        {
            // Arrange          

            var contact = new Contact()
            {
                Id = new Guid("88888888-8888-8888-8888-888888888888"),
                FirstName = "Pedro",
                LastName = "Rodriguez",
                Company = "ItSystems",
                Email = "pedro@live.com.ar",
                PhoneNumber = "+543794637353"
            };

            using var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            var options = new DbContextOptionsBuilder()
                .UseSqlite(connection)
                .Options;

            using (var context = new DataContext(options))
            {
                await context.Database.EnsureCreatedAsync();
            }

            // Act
            using (var context = new DataContext(options))
            {
                var controller = new ContactsApiController(context);
                var result = await controller.CreateContact(contact);
            }

            using (var context = new DataContext(options))
            {
                var result = await context.Contacts.FirstOrDefaultAsync(t => t.Email == contact.Email);
                //Assert
                Assert.NotNull(result);
                Assert.Equal(result.FirstName, contact.FirstName);
            }
        }

        [Fact]
        public async Task AsyncRemovenOTeExistingContactInBD()
        {
            // Arrange
            var notExistingGuid = Guid.NewGuid();
            var options = new DbContextOptionsBuilder()
                 .UseSqlServer(CONNECTION_STRING)
                 .Options;

            using (var context = new DataContext(options))
            {
                await context.Database.EnsureCreatedAsync();
            }

            // Act

            using (var context = new DataContext(options))
            {
                var controller = new ContactsApiController(context);
                var badResponse = await controller.DeleteContact(notExistingGuid);
                // Assert
                Assert.IsType<NotFoundResult>(badResponse);
            }

        }

        [Fact]
        public async Task AsyncUpdateContactData()
        {
            // Arrange          

            var contact = new Contact()
            {
                Id = new Guid("88888888-8888-8888-8888-888888888889"),
                FirstName = "Nahuel",
                LastName = "Alvarez",
                Company = "ItSystems",
                Email = "nalvarez23@live.com.ar",
                PhoneNumber = "+543794637353"
            };

            using var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            var options = new DbContextOptionsBuilder()
                .UseSqlite(connection)
                .Options;

            using (var context = new DataContext(options))
            {
                await context.Database.EnsureCreatedAsync();
                context.Contacts.Add(contact);
                await context.SaveChangesAsync();
                var controller = new ContactsApiController(context);
                contact.FirstName = "Sebastián";
                await controller.PutContact(contact.Id, contact);
                var result = await context.Contacts.FirstOrDefaultAsync(f => f.Id == contact.Id);
                //Assert
                Assert.NotNull(result);
                Assert.Equal(contact.FirstName, result.FirstName);
            }


        }

        [Fact]
        public async Task AsyncGetContactByCompany()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseSqlServer(CONNECTION_STRING)
                .Options;

            using (var context = new DataContext(options))
            {
                await context.Database.EnsureCreatedAsync();
                var controller = new ContactsApiController(context);
                var contact = await context.Contacts.FirstOrDefaultAsync();
                //Act
                var result = await controller.GetContactFromCompany(contact.Company);
                ////Assert
                Assert.NotNull(result);
                Assert.IsType<OkObjectResult>(result.Result);
            }
        }


    }
}
