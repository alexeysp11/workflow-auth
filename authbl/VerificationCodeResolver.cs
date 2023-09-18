using System.Data;
using Cims.WorkflowLib.DbConnections;
using WokflowLib.Authentication.Models;
using WokflowLib.Authentication.Models.NetworkParameters;

namespace WokflowLib.Authentication.AuthBL;

public class VerificationCodeResolver
{
    /// <summary>
    /// 
    /// </summary>
    public void GenerateVerificationCode(SessionToken response)
    {
        try
        {
            // Generate verification code 
            response.VerificationCode = "";
            response.CodeSendingDt = System.DateTime.Now;
            string sql = @$"
insert into verification_code (code, sending_dt)
values ('{response.VerificationCode}', {response.CodeSendingDt})
";
            // Execute SQL statement 
            // 
        }
        catch (System.Exception ex)
        {
            response.ExceptionMessage = ex.ToString();
        }
    }
}
