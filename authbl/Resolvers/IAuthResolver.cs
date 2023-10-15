using WokflowLib.Authentication.Models.NetworkParameters;

namespace WokflowLib.Authentication.AuthBL;

/// <summary>
/// 
/// </summary>
public interface IAuthResolver
{
    UserExistance CheckUserExistance(UserCredentials request);
    UserCreationResult AddUser(UserCredentials request);
    VSUResponse VerifySignUp(VSURequest request);

    VUCResponse VerifyUserCredentials(UserCredentials request);
    SessionToken GetTokenByUserUid(TokenRequest request);
}