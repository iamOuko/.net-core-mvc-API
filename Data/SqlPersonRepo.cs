using Commander.Models;

namespace Commander.Data
{
    public class SqlPersonRepo : IPersonRepo
    {
        private readonly PersonContext _context;

        public SqlPersonRepo(PersonContext context)
        {
            _context = context;
        }

        public void CreatePerson(Person psn)
        {
            if(psn == null)
            {
                throw new ArgumentNullException(nameof(psn));
            }

            _context.Persons.Add(psn);
        }

        public void DeletePerson(Person psn)
        {
            if (psn == null)
            {
                throw new ArgumentNullException(nameof(psn));
            }

            _context.Persons.Remove(psn);
        }

        public IEnumerable<Person> GetAllPersons()
        {
            return _context.Persons.ToList();
        }

        public Person GetPersonById(int id)
        {
            return _context.Persons.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdatePerson(Person psn)
        {
            // nothing
        }
    }
}
