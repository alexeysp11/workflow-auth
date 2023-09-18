using WokflowLib.Authentication.Models.NetworkParameters;

namespace WokflowLib.Authentication.AuthBL;

public class AuthResolver
{
    public UserExistance CheckUserExistance(UserCredentials request)
    {
        var response = new UserExistance();
        try
        {
            if (string.IsNullOrWhiteSpace(request.Login))
                throw new System.Exception("Parameter 'Login' could not be null or empty");
            if (string.IsNullOrWhiteSpace(request.Email))
                throw new System.Exception("Parameter 'Email' could not be null or empty");
            if (string.IsNullOrWhiteSpace(request.PhoneNumber))
                throw new System.Exception("Parameter 'PhoneNumber' could not be null or empty"); 
            // 
            new UserHelper().CheckUserExistance(request, response);
        }
        catch (System.Exception ex)
        {
            response.ExceptionMessage = ex.ToString();
        }
        return response;
    }

    public SessionToken AddUser(UserCredentials request)
    {
        var response = new SessionToken();
        try
        {
            if (string.IsNullOrWhiteSpace(request.Login))
                response.ExceptionMessage = "Parameter 'Login' could not be null or empty";
            if (string.IsNullOrWhiteSpace(request.Email))
                response.ExceptionMessage = "Parameter 'Email' could not be null or empty";
            if (string.IsNullOrWhiteSpace(request.PhoneNumber))
                response.ExceptionMessage = "Parameter 'PhoneNumber' could not be null or empty";
            if (string.IsNullOrWhiteSpace(request.Password))
                response.ExceptionMessage = "Parameter 'Password' could not be null or empty";
            // 
            new UserHelper().AddUser(request, response);
            new TokenHelper().CreateToken(response);
            new VerificationCodeResolver().GenerateVerificationCode(response);
        }
        catch (System.Exception ex)
        {
            response.ExceptionMessage = ex.ToString();
        }
        return response;
    }

    public GetCodeInfoResponse GetCodeInfo(TokenInfo request)
    {
        var response = new GetCodeInfoResponse();
        try
        {
            // Decide if the verification was successful based on the token info from request 
            // Notify other services, that are specified in a config file, about the status of token (verified, not verified)
            // 
            response.IsSuccessful = true;
        }
        catch (System.Exception ex)
        {
            response.ExceptionMessage = ex.ToString();
        }
        return response;
    }

    public UserUidResponse VerifyUserCredentials(UserCredentials request)
    {
        var response = new UserUidResponse();
        try
        {
            // Executes SQL query to get user credentials are correct
            // 
            response.IsVerified = true;
            response.UserUid = "";
        }
        catch (System.Exception ex)
        {
            response.ExceptionMessage = ex.ToString();
        }
        return response;
    }

    public SessionToken GetTokenByUserUid(UserUidRequest request)
    {
        var response = new SessionToken();
        try
        {
            // Update session token for the specified user 
            //
        }
        catch (System.Exception ex)
        {
            response.ExceptionMessage = ex.ToString();
        }
        return response;
    }
}