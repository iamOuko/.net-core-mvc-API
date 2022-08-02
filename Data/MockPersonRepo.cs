using Commander.Models;

namespace Commander.Data
{
    public class MockPersonRepo : IPersonRepo
    {
        public void CreatePerson(Person psn)
        {
            throw new NotImplementedException();
        }

        public void DeletePerson(Person psn)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Person> GetAllPersons()
        {
            var persons = new List<Person>
            {
                new Person { Id = 0, FullNames = "ouko ezra", Email = "ouko@gmail.com", MobileNumber = 0712348598 },
                new Person { Id = 1, FullNames = "ouko shee", Email = "oukosh@gmail.com", MobileNumber = 0784879374 },
                new Person { Id = 2, FullNames = "ouko mart", Email = "oukoma@gmail.com", MobileNumber = 0788767574 }

            };

            return persons;
        }

        public Person GetPersonById(int id)
        {
            return new Person { Id = 0, FullNames = "ouko ezra", Email = "ouko@gmail.com", MobileNumber = 07882345};
            
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void UpdatePerson(Person psn)
        {
            throw new NotImplementedException();
        }
    }
}
