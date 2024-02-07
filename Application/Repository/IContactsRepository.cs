using RegistrationSystem.Domain.Models;

namespace RegistrationSystem.Application.Repository
{
    public interface IContactsRepository
    {
        ContactModel ListById(int id);
        //List<ContactModel> ListAllContacts(int UserId);
        List<ContactModel> ListAllContacts(int UserId);
        ContactModel Add(ContactModel contact);
        ContactModel Update(ContactModel contact);
        bool Delete(int id);

    }
}
