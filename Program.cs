﻿using ClassProject010;

namespace ClassProject003;

class Program
{
    private static Customers customers;
    private static List<Appointment> appointments;
    private static List<CustomerAppointment> customerAppointments;
    private static Customer authenticatedCustomer;

    private static List<Doctor> doctors;

    private static Doctor authenticatedDoctor;

    //added doctor variable and authenticated doc 

    static void Main(string[] args)
    {
        Console.WriteLine("Initializing.....");
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

        var d1 = new Doctor("Dr. Smith", "Cardiologist", "drsmith", "doctor123");
        var d2 = new Doctor("Dr. Johnson", "Pediatrician", "drjohnson", "pass123");
//added cardiologist and pediatrician

        var a1 = new Appointment();
        var a2 = new Appointment();
        var a3 = new Appointment();

        var ca1 = new CustomerAppointment(c1, a1);
        var ca2 = new CustomerAppointment(c1, a2);
        var ca3 = new CustomerAppointment(c2, a3);

        customers = new Customers();
        customers.customerList.Add(c1);
        customers.customerList.Add(c2);

        customerAppointments = new List<CustomerAppointment>();
        customerAppointments.Add(ca1);
        customerAppointments.Add(ca2);
        customerAppointments.Add(ca3);

        appointments = new List<Appointment>();
        appointments.Add(a1);
        appointments.Add(a2);
        appointments.Add(a3);

        doctors = new List<Doctor>();
        doctors.doctorList.Add(d1);
        doctors.doctorList.Add(d2);

    }

    static void Menu()
    {
        bool done = false;

        while (!done)
        {
            Console.WriteLine("Options: Login: 1, Doctor Login: 2, Sign Up: 3, Appointments: 4, Logout: 5, Quit: q");
            Console.Write("Choice: ");
            string choice = Console.ReadLine();

            switch(choice)
            {
                case "1":
                    CustomerLoginMenu();
                    break;
                case "2":
                    DoctorLoginMenu();
                    break;
                case "3":
                    SignUpMenu();
                    break;
                case "4":
                    if(authenticatedCustomer != null || authenticatedDoctor != null)
                    //makes sure customer or doctor is authenticated
                    {
                        if(authenticatedCustomer != null)
                        {
                            CustomerAppointmentsMenu();
                        }
                        else
                        {
                            DocotorAppointmentsMenu();
                        }
                        //determines whether it is customer or doc
                    }
                    else
                    {
                        Console.WriteLine("Please log in first!");
                        //if they are not authenticated, prompts user to log in
                    }
                    break;
                case "5":
                    Logout();
                    break;    
                case "q":
                    done = true;
                    break;
                default:
                    Console.WriteLine("Invalid command!");
                    break;
            }

        }


    }

    static void CustomerLoginMenu()
    {
        if(authenticatedCustomer == null)
        {
            Console.Write("Enter your username: ");
            string username = Console.ReadLine();
            Console.Write("Enter your password: ");
            string password = Console.ReadLine();

            authenticatedCustomer = customers.Authenticate(username, password);
            if (authenticatedCustomer != null)
            {
                Console.WriteLine($"Welcome {authenticatedCustomer.FirstName}");
            }
            else
            {
                Console.WriteLine("Invalid username or password");
            }
        }


    }
 static void DoctorLoginMenu()
        {
            if (authenticatedDoctor == null)
            {
                Console.Write("Enter your username: ");
                string username = Console.ReadLine();
                Console.Write("Enter your password: ");
                string password = Console.ReadLine();

                authenticatedDoctor = doctors.FirstOrDefault(doc => doc.Authenticate(username, password));
                //finds doctor in list instead of using instance of doctor class
                if (authenticatedDoctor != null)
                {
                    Console.WriteLine($"Welcome Dr. {authenticatedDoctor.Name}");
                }
                else
                {
                    Console.WriteLine("Invalid username or password");
                }
            }
        }

        //added doctor log in menu
    static void LogOutMenu()
    {
        authenticatedCustomer = null;
        authenticatedDoctor = null;
        //added doctor signout 
        Console.WriteLine("Logged out!");
    }

    static void SignUpMenu()
    {
        Console.Write("First Name: ");
        string firstname = Console.ReadLine();
        Console.Write("Last Name: ");
        string lastname = Console.ReadLine();
        Console.Write("Username: ");
        string username = Console.ReadLine();
        Console.Write("Password: ");
        string password = Console.ReadLine();

        var newCustomer = new Customer
        {
            FirstName = firstname,
            LastName = lastname,
            Username = username,
            Password = password
        };
        customers.customerList.Add(newCustomer);
        Console.WriteLine("Profile created!");
        
    }

    static void CustomerAppointmentsMenu()
    {
        if (authenticatedCustomer == null)
        {
            Console.WriteLine("Please log in first!");
            return;
        }

        var appointmentList = customerAppointments.Where(o => o.c.Username == authenticatedCustomer.Username);

        if(appointmentList.Count() == 0)
        {
            Console.WriteLine("0 appointments found.");
        }
        else
        {
            foreach(var appointment in appointmentList)
            {
                Console.WriteLine(appointment.a.dateTime);
            }
        }
        
    }
     static void DoctorAppointmentsMenu()
        {
            if (authenticatedDoctor == null)
            {
                Console.WriteLine("Please log in first!");
                return;
            }

            //doctor appointment menu
        }

}

