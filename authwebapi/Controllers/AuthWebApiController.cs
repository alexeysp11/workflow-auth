using Microsoft.AspNetCore.Mvc;
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
        return new UserExistance()
        {
            //
        };
    }

    public SessionToken AddUser(UserCredentials request)
    {
        return new SessionToken()
        {
            //
        };
    }

    public GetCodeInfoResponse GetCodeInfo(TokenInfo request)
    {
        return new GetCodeInfoResponse()
        {
            //
        };
    }

    public UserUidResponse VerifyUserCredentials(UserCredentials request)
    {
        return new UserUidResponse()
        {
            //
        };
    }

    public SessionToken GetTokenByUserUid(UserUidRequest request)
    {
        return new SessionToken()
        {
            //
        };
    }
}
