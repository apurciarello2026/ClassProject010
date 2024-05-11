namespace ClassProject010;
using System;
using System.Collections.Generic;
using System.Linq;
//forming the project, for all parts of code used from chat gpt this was the prompt: Can you help me write a method where a patient can meet with a doctor about their symptoms. 
//the code was used to help me to fix errors, fix build failure erros, and to help me work through difficult parts of the code. 
//OpenAi. (2024). ChatGPT (3.5 version)[Large language model]. https://chatgpt.com/?model=text-davinci-002-render&oai-dm=1
public class Patient

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
