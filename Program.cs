class Program
{
  

   public class Appointment  // Appointment class representing an appointment.
   {
       private static int autoIncrement;
       public int AppointmentId { get; }
       public DateTime DateTime { get; set; }


       public Appointment() //This creates an appointment ID that is identifiable for each appointment. 
       {
           autoIncrement++;
           AppointmentId = autoIncrement;
       }
   }


   public class PatientAppointment // PatientAppointment class associating a customer with an appointment.
   {
       public Patient Patient { get; set; }
       public Appointment Appointment { get; set; }


       public PatientAppointment(Patient patient, Appointment appointment)
       {
           Patient = patient;
           Appointment = appointment;
       }
   }



   static void Initialize() //This method houses all the login info for each patient.
   {
       var c1 = new Patient
       {
           PatientFirstName = "Anthony", //Each of these methods holds the patient last name, first name, username, and password.
           PatientLastName = "Purciarello",
           Username = "apurciarello",
           Password = "marquette2026",
       };


       var c2 = new Patient //c2 is the reference variable for each new patient. 
       {
           PatientFirstName = "Guy",
           PatientLastName = "Alvizu",
           Username = "Vizuuu",
           Password = "CalebtoRomefor6",
       };


       var c3 = new Patient
       {
           PatientFirstName = "Ayan",
           PatientLastName = "Shazada",
           Username = "KingShazada",
           Password = "Lebron23GOAT",
       };


       var c4 = new Patient
       {
           PatientFirstName = "Lex",
           PatientLastName = "Wallace",
           Username = "Wallace123",
           Password = "54321"
       };


       var a1 = new Appointment(); //Each var is a specific appointment that a patient will make. 
       var a2 = new Appointment();
       var a3 = new Appointment();
       var a4 = new Appointment();


       var ca1 = new PatientAppointment(c1, a1);
       var ca2 = new PatientAppointment(c2, a2);
       var ca3 = new PatientAppointment(c3, a3);
       var ca4 = new PatientAppointment(c4, a4);


       patients = new Patients();
       patients.patientList.Add(c1); // Adds each invidual appointment to the list. 
       patients.patientList.Add(c2);
       patients.patientList.Add(c3);
       patients.patientList.Add(c4);


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

