using Microsoft.EntityFrameworkCore.Storage;
using RegistrationSystem.Domain.Models;
using RegistrationSystem.Infrastructure.Data;

namespace RegistrationSystem.Application.Repository
{
    public class ContactRepository : IContactsRepository
    {
        private DataBaseContext dataBaseContext;

        public ContactRepository(DataBaseContext dataBaseContext)
        {
            this.dataBaseContext = dataBaseContext;
        }

        public ContactModel ListById(int id)
        {
            return dataBaseContext.Contacts.FirstOrDefault(x => x.Id == id);
        }

        public List<ContactModel> ListAllContacts(int UserId)
        {
            return dataBaseContext.Contacts.Where(x => x.UserId == UserId).ToList();

        }


        public ContactModel Add(ContactModel contact)
        {
            dataBaseContext.Contacts.Add(contact);
            dataBaseContext.SaveChanges();
            return contact;
        }

        public ContactModel Update(ContactModel contact)
        {
            ContactModel contactDB = ListById(contact.Id);
            if (contactDB == null) throw new Exception("Error to update contact");

            contactDB.Name = contact.Name;
            contactDB.Email = contact.Email;
            contactDB.Mobile = contact.Mobile;

            dataBaseContext.Contacts.Update(contactDB);
            dataBaseContext.SaveChanges();
            return contactDB;
        }

        public bool Delete(int id)
        {
            ContactModel contactDB = ListById(id);
            if (contactDB == null) throw new Exception("Error when trying to delete contact");

            dataBaseContext.Contacts.Remove(contactDB);
            dataBaseContext.SaveChanges();
            return true;


        }
    }
}
