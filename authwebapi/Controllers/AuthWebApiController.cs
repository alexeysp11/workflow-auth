using Microsoft.AspNetCore.Mvc;
using WokflowLib.Authentication.AuthBL;
using WokflowLib.Authentication.Models.NetworkParameters;

namespace WokflowLib.Authentication.AuthWebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthWebApiController : ControllerBase
{
    private readonly ILogger<AuthWebApiController> _logger;

    public AuthWebApiController(ILogger<AuthWebApiController> logger)
    {
        _logger = logger;
    }

    public UserExistance CheckUserExistance(UserCredentials request)
    {
        return new AuthResolver().CheckUserExistance(request);
    }

    public UserCreationResult AddUser(UserCredentials request)
    {
        return new AuthResolver().AddUser(request);
    }

    public VSUResponse VerifySignUp(VSURequest request)
    {
        return new AuthResolver().VerifySignUp(request);
    }

    public VUCResponse VerifyUserCredentials(UserCredentials request)
    {
        return new AuthResolver().VerifyUserCredentials(request);
    }

    public SessionToken GetTokenByUserUid(TokenRequest request)
    {
        return new AuthResolver().GetTokenByUserUid(request);
    }
}
