namespace App.Models
{
    /// <summary>
    /// Seller object
    /// </summary>
    public class User
    {
        public User()
        {
        }
        public User(string email, string name, string id, string password)
        {
            Email = email;
            Name = name;
            Id = id;
            Password = password;
        }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Id { get; set; }
        public string Password { get; set; }
    }
}