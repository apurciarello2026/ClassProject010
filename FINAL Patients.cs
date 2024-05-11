namespace ClassProject010;

public class FINAL_Patients
//This is the class that creates the patient object.
{
    public string PatientFirstName { get; set; } //The gets and sets are what allows the variables to be referenced in other methods.
    public string PatientLastName { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
}

public class Patients //Ayan did this method.   
// Patients class managing a list of patients that have created appointments.

{
    public List<FINAL_Patients> patientList { get; set; } //FIXED: Changed "PATIENT" to "FINAL_Patients"

    public Patients()
    {
        patientList = new List<FINAL_Patients>(); //FIXED: Changed "PATIENT" to "FINAL_Patients"
    }

    public FINAL_Patients Authenticate(string username, string password) //FIXED: Changed "PATIENT" to "FINAL_Patients"
    {
        return patientList.FirstOrDefault(c => c.Username == username && c.Password == password);
        //This line of code makes sure that the username and password is correct to authenticate the patient.
    }
}
