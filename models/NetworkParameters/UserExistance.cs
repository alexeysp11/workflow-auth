namespace WokflowLib.Authentication.Models.NetworkParameters;

public class UserExistance
{
    public bool LoginExists { get; set; }
    public bool EmailExists { get; set; }
    public bool PhoneNumberExists { get; set; }
    public string ExceptionMessage { get; set; }
}
