using Agenda.Domain.Entities;
using Agenda.Infrastructure.Persistence;
using Agenda.Infrastructure.Persistence.Repository;
using Microsoft.EntityFrameworkCore;

namespace Agenda.Tests.Infrastructure.repository
{
    public class ContactRepositoryTests
    {

        private ContactListDbContext GetInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<ContactListDbContext>()
                .UseInMemoryDatabase(databaseName: $"ContactDb_{System.Guid.NewGuid()}")
                .Options;

            return new ContactListDbContext(options);
        }

        [Fact]
        public async Task Get_Contact_By_Name_Returns_Contact_When_Exists()
        {
            var context = GetInMemoryDbContext();
            var contact = new Contact("John Doe", "john@example.com", "1234567890", 1);
            context.Contact.Add(contact);
            await context.SaveChangesAsync();

            var repository = new ContactRepository(context);
            var result = await repository.GetContactByName("John Doe");

            Assert.NotNull(result);
            Assert.Equal("John Doe", result.Name);
        }

        [Fact]
        public async Task Get_Contact_By_Phone_Returns_Null_When_Not_Exists()
        {
            var context = GetInMemoryDbContext();
            var repository = new ContactRepository(context);

            var result = await repository.GetContactByPhone("0000000000");

            Assert.Null(result);
        }

        [Fact]
        public async Task Get_List_Contact_By_Id_Contact_List_Returns_Correct_List()
        {
            var context = GetInMemoryDbContext();
            context.Contact.AddRange(
                new Contact("A", "a@email.com", "1111111111", 1),
                new Contact("B", "b@email.com", "2222222222", 2),
                new Contact("C", "c@email.com", "3333333333", 1)
            );
            await context.SaveChangesAsync();

            var repository = new ContactRepository(context);
            var result = await repository.GetListContactByIdContactList(1);

            Assert.Equal(2, result.Count);
            Assert.All(result, c => Assert.Equal(1, c.IdContactList));
        }

        [Fact]
        public async Task Get_With_Predicate_Returns_Filtered_Contacts()
        {
            var context = GetInMemoryDbContext();
            context.Contact.AddRange(
                new Contact("Lucas", "lucas@email.com", "9999999999", 3),
                new Contact("Lia", "lia@email.com", "8888888888", 3)
            );
            await context.SaveChangesAsync();

            var repository = new ContactRepository(context);
            var result = await repository.Get(c => c.Name.StartsWith("L"));

            Assert.Equal(2, result.Count);
        }

        [Fact]
        public async Task Add_Contact_Saves_Successfully()
        {
            var context = GetInMemoryDbContext();
            var repository = new ContactRepository(context);

            var contact = new Contact("Alice", "alice@email.com", "1234567890", 1);
            await repository.Add(contact);
            await context.SaveChangesAsync();

            var result = await context.Contact.FirstOrDefaultAsync(c => c.Email == "alice@email.com");

            Assert.NotNull(result);
            Assert.Equal("Alice", result.Name);
        }

        [Fact]
        public async Task Update_Contact_Changes_Are_Persisted()
        {
            var context = GetInMemoryDbContext();
            var contact = new Contact("Bob", "bob@email.com", "1111111111", 1);
            context.Contact.Add(contact);
            await context.SaveChangesAsync();

            var repository = new ContactRepository(context);
            contact.UpdateContact(contact.Id, "Bobby", "bobby@email.com", "9999999999", 2);

            await repository.Update(contact);
            await context.SaveChangesAsync();

            var updated = await context.Contact.FirstOrDefaultAsync(c => c.Id == contact.Id);

            Assert.NotNull(updated);
            Assert.Equal("Bobby", updated.Name);
            Assert.Equal("bobby@email.com", updated.Email);
            Assert.Equal("9999999999", updated.Phone);
            Assert.Equal(2, updated.IdContactList);
        }

        [Fact]
        public async Task Delete_Contact_Removes_From_Database()
        {
            var context = GetInMemoryDbContext();
            var contact = new Contact("Charlie", "charlie@email.com", "2222222222", 1);
            context.Contact.Add(contact);
            await context.SaveChangesAsync();

            var repository = new ContactRepository(context);
            var deleted = await repository.Delete(contact);
            
            Assert.True(deleted);
        }
    }
}