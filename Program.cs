class Program
{
   public class Patient //Ayan did this method.
   
   //This is the class that creates the patient object.
   {
       public string PatientFirstName { get; set; } //The gets and sets are what allows the variables to be referenced in other methods.
       public string PatientLastName { get; set; }
       public string Username { get; set; }
       public string Password { get; set; }
   }

   public class Appointment //Ayan and Anthony did this method.
   // Appointment constructor class.
   {
       private static int autoIncrement;
       public int AppointmentId { get; }
       public DateTime DateTime { get; set; }


       public Appointment() 
       //This creates an appointment ID that is identifiable for each appointment.
       {
           autoIncrement++;
           AppointmentId = autoIncrement;
       }
   }

   public class PatientAppointment //Anthony did this method.
   // PatientAppointment class associating a customer with an appointment.
   {
       public Patient Patient { get; set; }
       public Appointment Appointment { get; set; }


       public PatientAppointment(Patient patient, Appointment appointment)
       {
           Patient = patient;
           Appointment = appointment;
       }
   }


   public class Patients //Ayan did this method.   
   // Patients class managing a list of patients that have created appointments.

   {
       public List<Patient> patientList { get; set; }


       public Patients()
       {
           patientList = new List<Patient>();
       }

       public Patient Authenticate(string username, string password)
       {
           return patientList.FirstOrDefault(c => c.Username == username && c.Password == password);
           
           //This line of code makes sure that the username and password is correct to authenticate the patient.
       }
   }

   private static Patients patients;
   private static List<Appointment> appointments; //Both the List<Appointment> and List<PatientAppointment> keep track of patients.
   private static List<PatientAppointment> patientAppointments;
   private static Patient authenticatedPatient;


   // Main method to start the program interface.
   static void Main(string[] args) // Anthony did this method.
   {
       Console.WriteLine("Loading..."); //This is the start of the program which takes you to the menu.
       Initialize();
       while (true)
       {
           Menu();
       }
   }

   static void Initialize() // Anthony did this method.
   
   //This method houses all the login info for each patient.
   {
       var c1 = new Patient
       {
           PatientFirstName = "Anthony", //Each of these methods holds the patient last name, first name, username, and password.
           PatientLastName = "Purciarello",
           Username = "apurciarello",
           Password = "marquette2026",
       };

       var c2 = new Patient //Var c is the reference variable for each new patient.
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


       var ca1 = new PatientAppointment(c1, a1); //These represent a specific appointment for each patient. 
       var ca2 = new PatientAppointment(c2, a2);
       var ca3 = new PatientAppointment(c3, a3);
       var ca4 = new PatientAppointment(c4, a4);


       patients = new Patients();
       patients.patientList.Add(c1); // Adds each invidual appointment to the list.
       patients.patientList.Add(c2);
       patients.patientList.Add(c3);
       patients.patientList.Add(c4);


       patientAppointments = new List<PatientAppointment>(); //Adds each appointment to the list. 
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

   // Method to display the main menu.
   static void Menu() //Lex did this method.
   
   //This menu allows the patient to log in and make an appointment with a doctor.
   {
       Console.WriteLine("Menu:");
       Console.WriteLine("1. Log in");
       Console.WriteLine("2. Meet with a doctor");
       Console.WriteLine("3. Exit");
       Console.Write("Enter your choice: ");
       int choice = Convert.ToInt32(Console.ReadLine()); //This line allows the patient to select on of the three options.


       switch (choice) //This method confirms if the user is an actual authenticated patient. 
       {
           case 1:
               Login();
               break;
           case 2:
               if (authenticatedPatient == null)
               {
                   Console.WriteLine("Please log in first!");
               }
               else
               {
                   MeetDoctorMenu();
               }
               break;
           case 3:
               Console.WriteLine("Exiting program...");
               Environment.Exit(0);
               break;
           default:
               Console.WriteLine("Invalid choice. Please try again.");
               break;
       }
   }

   // Method to handle user login.
   static void Login() //Lex did this method.
   {
       Console.Write("Enter username: "); //This method confirms that the names, username, and passwords are correct.
       string username = Console.ReadLine();
       Console.Write("Enter password: ");
       string password = Console.ReadLine();

       authenticatedPatient = patients.Authenticate(username, password);

       if (authenticatedPatient != null)
       {
           Console.WriteLine($"Welcome, {authenticatedPatient.PatientFirstName}!");
       }
       else
       {
           Console.WriteLine("Invalid username or password.");
       }
   }


   // Method to select a doctor and for each specialization.
   static void MeetDoctorMenu() // Guy did this method. 
   {
       Console.WriteLine("Select a doctor to meet with:");
       //Assuming you have a list of doctors or a way to retrieve available doctors
       //Example:These are the doctors that you can choose from. 
       //forming the project, for all parts of code used from chat gpt this was the prompt: Can you help me write a method where a patient can meet with a doctor about their symptoms.
       //the code was used to help me to fix errors, fix build failure errors, and to help me work through difficult parts of the code. 
       //OpenAi. (2024). ChatGPT (3.5 version)[Large language model]. https://chatgpt.com/?model=text-davinci-002-render&oai-dm=1

       Console.WriteLine("1. Dr. Ow (Cardiologist)");
       Console.WriteLine("2. Dr. Lee (Dermatologist)");
       Console.WriteLine("3. Dr. Saffarizadeh (Surgeon)");
       Console.Write("Enter doctor's number: ");
       string doctorChoice = Console.ReadLine();

       switch (doctorChoice)
       {
           case "1": //This is the scenario for typing 1,2, or 3.
               Console.WriteLine("You are meeting with Dr. Ow (Cardiologist)"); 
               ScheduleAppointment();
               break;
           case "2":
               Console.WriteLine("You are meeting with Dr. Lee (Dermatologist)");
               ScheduleAppointment();
               break;
           case "3":
               Console.WriteLine("You are meeting with Dr. Saffarizadeh (Surgeon)");
               ScheduleAppointment();
               break;
           default:
               Console.WriteLine("Invalid doctor selection."); //This happens if you type a number other than 1,2, or 3.
               break;
       }
   }

   static void ScheduleAppointment() // Anthony and Ayan did this method.    
   
   // Method to schedule an appointment and at which date and time.
   {

    Console.WriteLine("Please describe your symptoms:"); //This acts as the records for whatever symptoms the patient has.
    string symptoms = Console.ReadLine();

    // Process the symptoms, such as saving them to a file or database.
    Console.WriteLine("Symptoms recorded. Thank you!");

    Console.Write("Enter the date for the appointment (MM/DD/YYYY): "); 
    DateTime date;  
    //OpenAI. (2023). ChatGPT (Mar 14 version) [Large language model]. https://chat.openai.com/chat
    //Prompt: can you make a method that allows patients to schedule an appointment with a specific date and time?

    //We just combined what chatGPT gave us with what we had.
    //How this code works is the readlines prompt the user to put in a date in the form of MM/DD/YYYY.
    //The user can then put in their date and time for the appointment.
    //The while line allows the user to put the specific time and date.
    //The TryParse lines is what actually allows the number be recorded as a date or time. 
    //We combined these two lines with what we had and formed the method from there.
    //DateTime appointmentDateTime = new DateTime(date.Year, date.Month, date.Day, time.Hour, time.Minute, 0);
    //This is what compliles the values given into a date and time and then prints it. 
    // while (!DateTime.TryParse(Console.ReadLine(), out date))

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



  