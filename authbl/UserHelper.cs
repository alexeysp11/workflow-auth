using System.Data;
using Cims.WorkflowLib.DbConnections;
using WokflowLib.Authentication.Models;
using WokflowLib.Authentication.Models.NetworkParameters;

namespace WokflowLib.Authentication.AuthBL;

public class UserHelper
{
    private PgDbConnection PgDbConnection { get; }
    private string ConnectionString { get; }

    public UserHelper()
    {
        ConnectionString = "Server=127.0.0.1;Port=5432;Userid=postgres;Password=postgres;Database=postgres";
        PgDbConnection = new PgDbConnection(ConnectionString);
    }

    /// <summary>
    /// Execute SQL query to get if a user with specified credentials exists in the DB
    /// </summary>
    public void CheckUserExistance(UserCredentials request, UserExistance response)
    {
        try
        {
            string sql = @$"-- 
select 1 as credentials_type, count(*) as qty from users where login = {request.Login}
union 
select 2 as credentials_type, count(*) as qty from users where email = {request.Email}
union
select 2 as credentials_type, count(*) as qty from users where phone_number = {request.PhoneNumber}
;";
            // Execute SQL statement 
            // 
            response.LoginExists = true;
            response.EmailExists = true;
            response.PhoneNumberExists = true;
        }
        catch (System.Exception ex)
        {
            response.ExceptionMessage = ex.ToString();
        }
    }

    /// <summary>
    /// Execute SQL query to add the user with specified qredentials to the DB 
    /// </summary>
    public void AddUser(UserCredentials request, SessionToken response)
    {
        try
        {
            // Add new user to the DB
            string sql = @$"insert into users (login, email, phone_number) values ({request.Login}, {request.Email}, {request.PhoneNumber});";
            // Execute SQL statement 
            // 
            // Generate session token
            response.TokenGuid = "";
            response.TokenBeginDt = System.DateTime.Now;
            response.TokenEndDt = System.DateTime.Now;
            sql = @$"insert into session_token (guid, begin_dt, end_dt) values ({response.TokenGuid}, {response.TokenBeginDt}, {response.TokenEndDt});";
            // Execute SQL statement 
            // 
            // Generate verification code 
            response.VerificationCode = "";
            response.CodeSendingDt = System.DateTime.Now;
            // Execute SQL statement 
            // 
        }
        catch (System.Exception ex)
        {
            response.ExceptionMessage = ex.ToString();
        }
    }
}