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

    public SessionToken AddUser(UserCredentials request)
    {
        return new AuthResolver().AddUser(request);
    }

    public GetCodeInfoResponse GetCodeInfo(TokenInfo request)
    {
        return new AuthResolver().GetCodeInfo(request);
    }

    public UserUidResponse VerifyUserCredentials(UserCredentials request)
    {
        return new AuthResolver().VerifyUserCredentials(request);
    }

    public SessionToken GetTokenByUserUid(UserUidRequest request)
    {
        return new AuthResolver().GetTokenByUserUid(request);
    }
}
