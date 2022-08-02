using Commander.Models;

namespace Commander.Data
{
    public interface IPersonRepo
    {
        bool SaveChanges();
        IEnumerable<Person> GetAllPersons();
        Person GetPersonById(int id);
        void CreatePerson(Person psn);
        void UpdatePerson(Person psn);
        void DeletePerson(Person psn);
    }
}
