using Grpc.Core;
using Google.Protobuf.WellKnownTypes;
using WokflowLib.Authentication.AuthBL;
using WokflowLib.Authentication.AuthGrpcApi;
using WokflowLib.Authentication.Models.Protos;

namespace WokflowLib.Authentication.AuthGrpcApi.Services;

public class AuthGrpcApiService : WokflowLib.Authentication.Models.Protos.AuthGrpcApi.AuthGrpcApiBase
{
    private readonly ILogger<AuthGrpcApiService> _logger;
    public AuthGrpcApiService(ILogger<AuthGrpcApiService> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// 
    /// </summary>
    public override Task<UserExistance> CheckUserExistance(UserCredentials request, ServerCallContext context)
    {
        return Task.FromResult(new UserExistance
        {
            LoginExists = true,
            EmailExists = true,
            PhoneNumberExists = true
        });
    }

    /// <summary>
    /// 
    /// </summary>
    public override Task<SessionToken> AddUser(UserCredentials request, ServerCallContext context)
    {
        return Task.FromResult(new SessionToken
        {
            TokenGuid = "",
            TokenBeginDt = Timestamp.FromDateTimeOffset(System.DateTime.Now),
            TokenEndDt = Timestamp.FromDateTimeOffset(System.DateTime.Now),
            VerificationCode = "",
            CodeSendingDt = Timestamp.FromDateTimeOffset(System.DateTime.Now)
        });
    }

    /// <summary>
    /// 
    /// </summary>
    public override Task<GetCodeInfoResponse> GetCodeInfo(TokenInfo request, ServerCallContext context)
    {
        return Task.FromResult(new GetCodeInfoResponse
        {
            IsSuccessful = true
        });
    }

    /// <summary>
    /// 
    /// </summary>
    public override Task<UserUidResponse> VerifyUserCredentials(UserCredentials request, ServerCallContext context)
    {
        return Task.FromResult(new UserUidResponse
        {
            IsVerified = true,
            UserUid = ""
        });
    }

    /// <summary>
    /// 
    /// </summary>
    public override Task<SessionToken> GetTokenByUserUid(UserUidRequest request, ServerCallContext context)
    {
        return Task.FromResult(new SessionToken
        {
            TokenGuid = "",
            TokenBeginDt = Timestamp.FromDateTimeOffset(System.DateTime.Now),
            TokenEndDt = Timestamp.FromDateTimeOffset(System.DateTime.Now),
            VerificationCode = "",
            CodeSendingDt = Timestamp.FromDateTimeOffset(System.DateTime.Now)
        });
    }
}
