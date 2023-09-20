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

    public UserCreationResult AddUser(UserCredentials request)
    {
        var response = new UserCreationResult();
        try
        {
            if (string.IsNullOrWhiteSpace(request.Login))
                throw new System.Exception("Parameter 'Login' could not be null or empty");
            if (string.IsNullOrWhiteSpace(request.Email))
                throw new System.Exception("Parameter 'Email' could not be null or empty");
            if (string.IsNullOrWhiteSpace(request.PhoneNumber))
                throw new System.Exception("Parameter 'PhoneNumber' could not be null or empty");
            if (string.IsNullOrWhiteSpace(request.Password))
                throw new System.Exception("Parameter 'Password' could not be null or empty");
            // 
            new UserHelper().AddUser(request, response);
            new VerificationCodeResolver().GenerateVerificationCode(response);
        }
        catch (System.Exception ex)
        {
            response.ExceptionMessage = ex.ToString();
        }
        return response;
    }

    public VerifySignUpResponse VerifySignUp(VerifySignUpRequest request)
    {
        var response = new VerifySignUpResponse();
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

    public VUCResponse VerifyUserCredentials(UserCredentials request)
    {
        var response = new VUCResponse();
        try
        {
            if (string.IsNullOrWhiteSpace(request.Login))
                throw new System.Exception("Parameter 'Login' could not be null or empty");
            if (string.IsNullOrWhiteSpace(request.Password))
                throw new System.Exception("Parameter 'Password' could not be null or empty");
            // 
            new UserHelper().VerifyUserCredentials(request, response);
        }
        catch (System.Exception ex)
        {
            response.ExceptionMessage = ex.ToString();
        }
        return response;
    }

    public SessionToken GetTokenByUserUid(TokenRequest request)
    {
        var response = new SessionToken();
        try
        {
            if (string.IsNullOrWhiteSpace(request.UserUid))
                throw new System.Exception("Parameter 'UserUid' could not be null or empty");
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