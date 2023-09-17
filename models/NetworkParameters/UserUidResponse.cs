namespace WokflowLib.Authentication.Models.NetworkParameters;

public class UserUidResponse
{
    public bool IsVerified { get; set; }
    public string? UserUid { get; set; }
    public string? ExceptionMessage { get; set; }
}
