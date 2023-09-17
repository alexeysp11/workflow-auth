using Grpc.Core;
using Google.Protobuf.WellKnownTypes;
using WokflowLib.Authentication.AuthBL;
using WokflowLib.Authentication.AuthGrpcApi;
using WokflowLib.Authentication.Models.Protos;
using UserCredentialsCommon = WokflowLib.Authentication.Models.NetworkParameters.UserCredentials;
using TokenInfoCommon = WokflowLib.Authentication.Models.NetworkParameters.TokenInfo;
using UserUidRequestCommon = WokflowLib.Authentication.Models.NetworkParameters.UserUidRequest;

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
        var response = new AuthResolver().CheckUserExistance(new UserCredentialsCommon
        {
            Login = request.Login,
            Email = request.Email,
            PhoneNumber = request.PhoneNumber,
            Password = request.Password
        });
        return Task.FromResult(new UserExistance
        {
            LoginExists = response.LoginExists,
            EmailExists = response.EmailExists,
            PhoneNumberExists = response.PhoneNumberExists
        });
    }

    /// <summary>
    /// 
    /// </summary>
    public override Task<SessionToken> AddUser(UserCredentials request, ServerCallContext context)
    {
        var response = new AuthResolver().AddUser(new UserCredentialsCommon
        {
            Login = request.Login,
            Email = request.Email,
            PhoneNumber = request.PhoneNumber,
            Password = request.Password
        });
        return Task.FromResult(new SessionToken
        {
            TokenGuid = response.TokenGuid,
            TokenBeginDt = Timestamp.FromDateTimeOffset(response.TokenBeginDt),
            TokenEndDt = Timestamp.FromDateTimeOffset(response.TokenEndDt),
            VerificationCode = response.VerificationCode,
            CodeSendingDt = Timestamp.FromDateTimeOffset(response.CodeSendingDt)
        });
    }

    /// <summary>
    /// 
    /// </summary>
    public override Task<GetCodeInfoResponse> GetCodeInfo(TokenInfo request, ServerCallContext context)
    {
        var response = new AuthResolver().GetCodeInfo(new TokenInfoCommon
        {
            TokenGuid = request.TokenGuid,
            TriesNumber = request.TriesNumber,
            IsDeprecated = request.IsDeprecated,
            IsOverriden = request.IsOverriden,
            SignUpClosingCode = request.SignUpClosingCode
        });
        return Task.FromResult(new GetCodeInfoResponse
        {
            IsSuccessful = response.IsSuccessful
        });
    }

    /// <summary>
    /// 
    /// </summary>
    public override Task<UserUidResponse> VerifyUserCredentials(UserCredentials request, ServerCallContext context)
    {
        var response = new AuthResolver().VerifyUserCredentials(new UserCredentialsCommon
        {
            Login = request.Login,
            Email = request.Email,
            PhoneNumber = request.PhoneNumber,
            Password = request.Password
        });
        return Task.FromResult(new UserUidResponse
        {
            IsVerified = response.IsVerified,
            UserUid = response.UserUid
        });
    }

    /// <summary>
    /// 
    /// </summary>
    public override Task<SessionToken> GetTokenByUserUid(UserUidRequest request, ServerCallContext context)
    {
        var response = new AuthResolver().GetTokenByUserUid(new UserUidRequestCommon
        {
            UserUid = request.UserUid
        });
        return Task.FromResult(new SessionToken
        {
            TokenGuid = response.TokenGuid,
            TokenBeginDt = Timestamp.FromDateTimeOffset(response.TokenBeginDt),
            TokenEndDt = Timestamp.FromDateTimeOffset(response.TokenEndDt),
            VerificationCode = response.VerificationCode,
            CodeSendingDt = Timestamp.FromDateTimeOffset(response.CodeSendingDt)
        });
    }
}
