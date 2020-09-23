namespace EnSek.API.Entity
{
    public class Customer
    {
        public int Id { get; private set; }

        public string FirstName { get; private set; }

        public string Surname { get; private set; }

        public Customer(int id, string firstName, string surname)
        {
            Id = id;

            if (string.IsNullOrEmpty(firstName))
            {
                throw new System.Exception("First Name can not be null");
            }
            else
            {
                FirstName = firstName;
            }

            if (string.IsNullOrEmpty(surname))
            {
                throw new System.Exception("Surname can not be null");
            }
            else
            {
                Surname = surname;
            }
        }
    }
}
