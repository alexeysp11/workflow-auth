using System.Data;
using Cims.WorkflowLib.DbConnections;
using WokflowLib.Authentication.Models;
using WokflowLib.Authentication.Models.NetworkParameters;

namespace WokflowLib.Authentication.AuthBL;

public class TokenResolver
{
    private PgDbConnection PgDbConnection { get; }
    private string ConnectionString { get; }
    private int HoursToAdd { get; }

    public TokenResolver()
    {
        ConnectionString = "Server=127.0.0.1;Port=5432;Userid=postgres;Password=postgres;Database=postgres";
        PgDbConnection = new PgDbConnection(ConnectionString);
        HoursToAdd = 5;
    }

    /// <summary>
    /// 
    /// </summary>
    public void CreateToken(SessionToken response)
    {
        try
        {
            response.TokenGuid = System.Guid.NewGuid().ToString();
            response.TokenBeginDt = System.DateTime.Now;
            response.TokenEndDt = response.TokenBeginDt.AddHours(HoursToAdd);
            PgDbConnection.ExecuteSqlCommand(@$"-- 
    insert into public.deliveryservice_auth_token(session_token_guid,begin_datetime,end_datetime)
    values ('{response.TokenGuid}','{response.TokenBeginDt}','{response.TokenEndDt}');");
        }
        catch (System.Exception ex)
        {
            response.ExceptionMessage = ex.ToString();
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public void GetTokenByGuid(System.Guid guid)
    {
//         var dataTable = PgDbConnection.ExecuteSqlCommand(@$"
// select
// 	at.deliveryservice_auth_token_id,
// 	at.session_token_guid,
// 	at.begin_datetime,
// 	at.end_datetime
// from public.deliveryservice_auth_token at
// where at.session_token_guid = '{guid}';");
        // TODO: check the number of rows and columns' names
        // for example, the number of rows is correct if only one record was returned
        // var dt1 = (System.DateTime)dataTable.Rows[0][2];
        // var dt2 = (System.DateTime)dataTable.Rows[0][3];
        // return new SessionVerifySignUpRequest
        // {
        //     SessionTokenGuid = guid,
        //     TokenActivityBegin = dt1,
        //     TokenActivityEnd = dt2
        // }; 
    }
}
