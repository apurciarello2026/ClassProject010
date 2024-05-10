class Program
{
    private static Customers customers;
    private static List<Appointment> appointments;
    private static List<CustomerAppointment> customerAppointments;
    private static Customer authenticatedCustomer;

    static void Main(string[] args)
    {
        Console.WriteLine("Initializing...");
        Initialize();
        Menu();
    }

    static void Initialize()
    {
        var c1 = new Customer
        {
            FirstName = "Kambiz",
            LastName = "Saffari",
            Username = "kambiz",
            Password = "1234"
        };

        var c2 = new Customer
        {
            FirstName = "Jeremy",
            LastName = "Lee",
            Username = "jlee",
            Password = "9876"
        };

        var a1 = new Appointment();
        var a2 = new Appointment();
        var a3 = new Appointment();

        var ca1 = new CustomerAppointment(c1, a1);
        var ca2 = new CustomerAppointment(c1, a2);
        var ca3 = new CustomerAppointment(c2, a3);

        customers = new Customers();
        customers.customerList.Add(c1);
        customers.customerList.Add(c2);

       patientAppointments = new List<PatientAppointment>();
       patientAppointments.Add(ca1);
       patientAppointments.Add(ca2);
       patientAppointments.Add(ca3);
       patientAppointments.Add(ca4);


       appointments = new List<Appointment>();
       appointments.Add(a1);
       appointments.Add(a2);
       appointments.Add(a3);
       appointments.Add(a4);
   }

   static void ScheduleAppointment()   // Method to schedule an appointment and at which date and time.

   {

    Console.WriteLine("Please describe your symptoms:"); //This acts as the system that records whatever symptoms the patient records.
    string symptoms = Console.ReadLine();

    // Process the symptoms, such as saving them to a file or database.
    Console.WriteLine("Symptoms recorded. Thank you!");

    Console.Write("Enter the date for the appointment (MM/DD/YYYY): ");
    DateTime date;
    while (!DateTime.TryParse(Console.ReadLine(), out date)) 
    {
        Console.WriteLine("Invalid date entry. Please try again.");
        Console.Write("Enter the date for the appointment (MM/DD/YYYY): ");
    }


    Console.Write("Enter the time for the appointment (HH:MM AM/PM): ");
    DateTime time;
    while (!DateTime.TryParse(Console.ReadLine(), out time))
    {
        Console.WriteLine("Invalid time format. Please try again.");
        Console.Write("Enter the time for the appointment (HH:MM AM/PM): ");
    }


    DateTime appointmentDateTime = new DateTime(date.Year, date.Month, date.Day, time.Hour, time.Minute, 0);
    Console.WriteLine($"Appointment scheduled successfully for {appointmentDateTime.ToString("MM/dd/yyyy hh:mm tt")}");
    
   }

       

}

