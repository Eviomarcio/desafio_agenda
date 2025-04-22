using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agenda.Domain.Entities;
using Agenda.Domain.Exceptions;
using Xunit;

namespace Agenda.Tests.Domain.Entities
{
    public class ContactEntityTests
    {
        [Fact]
        public void Should_Not_Save_Contact_Without_Name()
        {
            // Arrange
            var name = "";
            var email = "pedro@gmail.com";
            var phone = "1234567890";
            var idContactList = 1;

            // Act & Assert
            var exception = Assert.Throws<DomainException>(() =>
                new Contact(name, email, phone, idContactList)
            );

            Assert.Equal("Name cannot be empty.", exception.Message);
        }

        [Fact]
        public void Should_Not_Save_Contact_Without_Phone_Number()
        {
            // Arrange
            var name = "Henrique";
            var email = "henrique@email.com";
            var phone = "";
            var idContactList = 1;

            // Act & Assert
            var exception = Assert.Throws<DomainException>(() =>
                new Contact(name, email, phone, idContactList)
            );

            Assert.Equal("Phone number must be between 10 and 15 digits.", exception.Message);
        }

        [Fact]
        public void Should_Create_Valid_Contact()
        {
            // Arrange & Act
            var contact = new Contact("Carlos Santos", "carlos.santos@email.com", "1234567890", 1);

            // Assert
            Assert.Equal("Carlos Santos", contact.Name);
            Assert.Equal("carlos.santos@email.com", contact.Email);
            Assert.Equal("1234567890", contact.Phone);
            Assert.Equal(1, contact.IdContactList);
        }

        [Fact]
        public void Should_Not_Create_Contact_Without_Name()
        {
            // Act & Assert
            var ex = Assert.Throws<DomainException>(() =>
                new Contact("", "carlos.santos@email.com", "1234567890", 1)
            );

            Assert.Equal("Name cannot be empty.", ex.Message);
        }

        [Theory]
        [InlineData("invalid-email")]
        [InlineData("email@")]
        [InlineData("@domain.com")]
        public void Should_Not_Create_Contact_With_Invalid_Email(string invalidEmail)
        {
            var ex = Assert.Throws<DomainException>(() =>
                new Contact("João", invalidEmail, "1234567890", 1)
            );

            Assert.Equal("Invalid email format.", ex.Message);
        }

        [Theory]
        [InlineData("123")]
        [InlineData("abc1234567")]
        [InlineData("1234567890123456")]
        [InlineData("")]                   
        public void Should_Not_Create_Contact_With_Invalid_Phone(string invalidPhone)
        {
            var ex = Assert.Throws<DomainException>(() =>
                new Contact("João", "joao@gmail.com", invalidPhone, 1)
            );

            Assert.Equal("Phone number must be between 10 and 15 digits.", ex.Message);
        }

        [Fact]
        public void Should_Detect_Duplicate_By_Email()
        {
            var contact1 = new Contact("Renata", "patricia@gmail.com", "1234567890", 1);
            var contact2 = new Contact("Patricia", "PATRICIA@gmail.com", "0987654321", 1);

            Assert.True(contact1.IsDuplicate(contact2));
        }

        [Fact]
        public void Should_Detect_Duplicate_By_Phone()
        {
            var contact1 = new Contact("Renata", "renata@gmail.com", "1234567890", 1);
            var contact2 = new Contact("Patricia", "patricia@gmail.com", "1234567890", 1);

            Assert.True(contact1.IsDuplicate(contact2));
        }

        [Fact]
        public void Should_Not_Detect_Duplicate_When_Different_Email_And_Phone()
        {
            var contact1 = new Contact("Renata", "renata@gmail.com", "1234567890", 1);
            var contact2 = new Contact("Patricia", "patricia@gmail.com", "0987654321", 1);

            Assert.False(contact1.IsDuplicate(contact2));
        }

        [Fact]
        public void Should_Update_Contact_Properly()
        {
            var contact = new Contact("Patrícia", "patricia@gmail.com", "1111111111", 1);

            // Act
            contact.UpdateContact(99, "Patrícia Goés", "patricia.goes@gmail.com", "2222222222", 2);

            // Assert
            Assert.Equal(99, contact.Id);
            Assert.Equal("Patrícia Goés", contact.Name);
            Assert.Equal("patricia.goes@gmail.com", contact.Email);
            Assert.Equal("2222222222", contact.Phone);
            Assert.Equal(2, contact.IdContactList);
        }
    }
}