namespace ClassProject010;

public class Doctor
{
// Properties
        public string Name { get; set; }
        public string Specialization { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        // Constructor
        public Doctor(string name, string specialization, string username, string password)
        {
            Name = name;
            Specialization = specialization;
            Username = username;
            Password = password;
        }

        // Method to authenticate doctor
        public bool Authenticate(string username, string password)
        {
            return Username == username && Password == password;
        }
}

