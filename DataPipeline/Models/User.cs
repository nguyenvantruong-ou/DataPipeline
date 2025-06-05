namespace DataPipeline.Models
{
    public class User
    {
        public User() { }

        public User(string fullName, string email, string age, string country, string city)
        {
            FullName = fullName;
            Email = email;
            Age = age;
            Country = country;
            City = city;
            CreatedAt = DateTime.Now.ToString();  // lỡ set là string, nhát sửa type =))
        }

        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Age { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string CreatedAt { get; set; }

    }
}
