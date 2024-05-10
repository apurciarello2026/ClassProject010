namespace ClassProject010;

class Program
{
    // Patient class representing a patient
    public class Patient
    {
        public string PatientFirstName { get; set; }
        public string PatientLastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }

    // Main method to start the program
    static void Main(string[] args)
    {
        Console.WriteLine("Loading...");
        
        // Example usage of the Patient class
        Patient patient1 = new Patient();
        patient1.PatientFirstName = "John";
        patient1.PatientLastName = "Doe";
        patient1.Username = "johndoe";
        patient1.Password = "password";
        Console.WriteLine($"Patient Name: {patient1.PatientFirstName} {patient1.PatientLastName}");
        Console.WriteLine($"Username: {patient1.Username}");
    }
}
