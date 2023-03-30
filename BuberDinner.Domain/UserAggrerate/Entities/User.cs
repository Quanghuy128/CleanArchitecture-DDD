using BuberDinner.Domain.UserAggrerate.ValueObjects;

namespace BuberDinner.Domain.UserAggrerate.Entities
{
    public class User 
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = null;
        public string LastName { get; set; } = null;
        public string Email { get; set; } = null;
        public string Password { get; set; } = null;

        public User(Guid id, string firstName, string lastName, string email, string password)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
        }

        public static User Create(string firstName, string lastName, string email, string password)
        {
            return new(UserId.CreateUnique().Value, firstName, lastName, email, password);
        }
    }
}
