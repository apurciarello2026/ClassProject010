namespace ClassProject010;

public class Patient
{
     // Field to generate unique IDs
    private static int autoIncrement = 0;

    // Properties
    public int Id {get;} // Unique identifier for the patient
    public string Username {get; set;} // Get username for patient login.
    public string Password {get; set;} // Get password for patient login.
    public string FirstName {get; set;} // Get first name of patient
    public string LastName {get; set;} // Get last name of patient.

    // Constructor
    public Patient()
    {
        autoIncrement++;
        Id = autoIncrement;
    }

}
