using WokflowLib.Authentication.Models.NetworkParameters;

namespace WokflowLib.Authentication.AuthBL;

public class AuthResolver
{
    public UserExistance CheckUserExistance(UserCredentials request)
    {
        return new UserExistance()
        {
            LoginExists = true,
            EmailExists = true,
            PhoneNumberExists = true
        };
    }

    public SessionToken AddUser(UserCredentials request)
    {
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
        return new GetCodeInfoResponse()
        {
            IsSuccessful = true
        };
    }

    public UserUidResponse VerifyUserCredentials(UserCredentials request)
    {
        return new UserUidResponse()
        {
            IsVerified = true,
            UserUid = ""
        };
    }

    public SessionToken GetTokenByUserUid(UserUidRequest request)
    {
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