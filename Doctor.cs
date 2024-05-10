namespace ClassProject010;
using System;
using System.Collections.Generic;
using System.Linq;
//forming the project, for all parts of code used from chat gpt this was the prompt: Can you help me write a method where a patient can meet with a doctor about their symptoms. 
//the code was used to help me to fix errors, fix build failure erros, and to help me work through difficult parts of the code. 
//OpenAi. (2024). ChatGPT (3.5 version)[Large language model]. https://chatgpt.com/?model=text-davinci-002-render&oai-dm=1
public class Patient
// Assinging variables and their names, with getters and setters
{
    public string PatientFirstName { get; set; }
    public string PatientLastName { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
}

// Appointment class representing an appointment. With the dates and times, asked chat gpt for part of the code.
public class Appointment
{
    private static int autoIncrement;
    public int AppointmentId { get; }
    public DateTime DateTime { get; set; }

    public Appointment()
    {
        autoIncrement++;
        AppointmentId = autoIncrement;
    }
}

// PatientAppointment class associating a patient with an appointment, refered to chatgpt to help with the solution. 
public class PatientAppointment
{
    public Patient Patient { get; set; }
    public Appointment Appointment { get; set; }

    public PatientAppointment(Patient patient, Appointment appointment)
    {
        Patient = patient;
        Appointment = appointment;
    }
}

// Patients class managing a list of patients. Refered 
public class Patients
{
    public List<Patient> PatientList { get; set; }

    public Patients()
    {
        PatientList = new List<Patient>();
    }
    //setting up user name and passwords for the system
    public Patient Authenticate(string username, string password)
    {
        return PatientList.FirstOrDefault(c => c.Username == username && c.Password == password);
    }
}

class Program
//coding the patients and appointments
{
    private static Patients patients;
    private static List<Appointment> appointments;
    private static List<PatientAppointment> patientAppointments;
    private static Patient authenticatedPatient;

    // Main method to start the program
    static void Main(string[] args)
    {
        Console.WriteLine("Loading...");
        Initialize();
        MeetDoctorMenu();
    }

    // Initialize method to set up initial data
    static void Initialize()
    {
        //All for patients with their respected usernames and passwords
        var c1 = new Patient
        {
            PatientFirstName = "Anthony",
            PatientLastName = "Purciarello",
            Username = "apurciarello",
            Password = "marquette2026",
        };

        var c2 = new Patient
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
            Password= "54321"
        };
    //Shows how the patients will match up with their possible doctors
        var a1 = new Appointment();
        var a2 = new Appointment();
        var a3 = new Appointment();
        var a4 = new Appointment();

        var ca1 = new PatientAppointment(c1, a1);
        var ca2 = new PatientAppointment(c2, a2);
        var ca3 = new PatientAppointment(c2, a3);

        patients = new Patients();
        patients.PatientList.Add(c1);
        patients.PatientList.Add(c2);

        patientAppointments = new List<PatientAppointment>();
        patientAppointments.Add(ca1);
        patientAppointments.Add(ca2);
        patientAppointments.Add(ca3);

        appointments = new List<Appointment>();
        appointments.Add(a1);
        appointments.Add(a2);
        appointments.Add(a3);
    }

    static void MeetDoctorMenu()
    {
        if (authenticatedPatient == null)
        {
            //Asks patient to log into their account to start the process
            Console.WriteLine("Please log in first!");
            return;
        }

        Console.WriteLine("Select a doctor to meet with:");
        // list of doctors and their names
        Console.WriteLine("1. Dr. Ow (Cardiologist)");
        Console.WriteLine("2. Dr. Lee (Dermatologist)");
        Console.WriteLine("3. Dr. Saffarizadeh (Surgeon)");
        Console.Write("Enter doctor's number: ");
        string doctorChoice = Console.ReadLine();

        // Responese according to the choice of doctor
        switch (doctorChoice)
        {
            case "1":
                Console.WriteLine("You are meeting with Dr. Ow (Cardiologist)");
                DescribeSymptoms();
                break;
            case "2":
                Console.WriteLine("You are meeting with Dr. Lee (Dermatologist)");
                DescribeSymptoms();
                break;

            case "3":
                Console.WriteLine("You are meeting with Dr. Saffarizadeh (Surgeon)");
                DescribeSymptoms();
                break;
            default:
                Console.WriteLine("Invalid doctor selection.");
                break;
        }
    }
}