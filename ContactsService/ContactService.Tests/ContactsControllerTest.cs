using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactsService.Contexts;
using ContactsService.Controllers;
using ContactsService.Models;
using ContactsService.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace ContactService.Tests
{
    public class ContactsControllerTest
    {
        [Fact]
        public void  GetAll_ReturnsResult()
        {
            //Arrange
            Mock<IContactsRepository> repositoryMock = new Mock<IContactsRepository>();
            Mock<ContactsDbContext> contextMock = new Mock<ContactsDbContext>();
            var contact = new Contact()
            {
                FirstName = "Akshay",
                LastName = "Sawwashere",
                PhoneNumber = "9090909090",
                Address = new Address()
                {
                    Region = new Region()
                    {
                        City = "Pune",
                        Country = "India",
                        PostalCode = "411014",
                        RegionId = 1,
                        State = "MH"
                    },
                    AddId = 1,
                    AddressLine = "Address 1"
                }
            };
            var contacts = new List<Contact> {contact};
            repositoryMock.Setup(x => x.GetAll()).Returns(Task.FromResult(contacts.Cast<Contact>()));
            ContactsController controller = new ContactsController(repositoryMock.Object);

            //Act
            var result  = controller.GetAll();

            //Assert
            Assert.NotNull(result);
            var okObjectResult = result.Result as OkObjectResult;
            Assert.NotNull(okObjectResult);
            var model = okObjectResult.Value as List<Contact>;
            Assert.NotNull(model);
            Assert.Single(model);
        }
    }
}
