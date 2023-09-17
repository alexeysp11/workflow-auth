using WokflowLib.Authentication.Models.NetworkParameters;

namespace WokflowLib.Authentication.AuthBL;

public class AuthResolver
{
    public UserExistance CheckUserExistance(UserCredentials request)
    {
        // Execute SQL query to get if a user with specified credentials exists in the DB 
        //
        return new UserExistance()
        {
            LoginExists = true,
            EmailExists = true,
            PhoneNumberExists = true
        };
    }

    public SessionToken AddUser(UserCredentials request)
    {
        // Execute SQL query to add the user with specified qredentials to the DB 
        //   
        return new SessionToken()
        {
            TokenGuid = "",
            TokenBeginDt = System.DateTime.Now,
            TokenEndDt = System.DateTime.Now,
            VerificationCode = "",
            CodeSendingDt = System.DateTime.Now
        };
    }

    public GetCodeInfoResponse GetCodeInfo(TokenInfo request)
    {
        // Decide if the verification was successful based on the token info from reuqest 
        // Notify other services, that are specified in a config file, about the status of token (verified, not verified)
        // 
        return new GetCodeInfoResponse()
        {
            IsSuccessful = true
        };
    }

    public UserUidResponse VerifyUserCredentials(UserCredentials request)
    {
        // Executes SQL query to get user credentials are correct
        // 
        return new UserUidResponse()
        {
            IsVerified = true,
            UserUid = ""
        };
    }

    public SessionToken GetTokenByUserUid(UserUidRequest request)
    {
        // Update session token for the specified user 
        //
        return new SessionToken()
        {
            TokenGuid = "",
            TokenBeginDt = System.DateTime.Now,
            TokenEndDt = System.DateTime.Now,
            VerificationCode = "",
            CodeSendingDt = System.DateTime.Now
        };
    }
}