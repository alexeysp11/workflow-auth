using System.Data;
using Cims.WorkflowLib.DbConnections;
using Cims.WorkflowLib.Models.ErrorHandling;
using WokflowLib.Authentication.Models;
using WokflowLib.Authentication.Models.NetworkParameters;

namespace WokflowLib.Authentication.AuthBL;

/// <summary>
/// The class that resolves verification code.
/// </summary>
public class VerificationCodeResolver
{
    /// <summary>
    /// Method for generating verification code.
    /// </summary>
    public void GenerateVerificationCode(UserCreationResult response)
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
            response.WorkflowException = new WorkflowException
            {
                Message = ex.Message,
                StackTrace = ex.StackTrace,
                FullMessage = ex.ToString()
            };
        }
    }
}
