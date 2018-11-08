using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Data.SqlClient;
using System.Net.Http;
using System.Web;

public static HttpResponseMessage Run(HttpRequest req, ILogger log)
{
    string date = req.Query["d"];

    if (String.IsNullOrEmpty(date)) 
    {
        return new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest);
    }

    var json = new StringBuilder();
    var cs = Environment.GetEnvironmentVariable("DBCS");
    var sql = $"select Msg from dbo.Tasks where Updated between '{date}' and '{date} 23:59:59' for json path";
        
    using (SqlConnection conn = new SqlConnection(cs))
    {
        conn.Open();

        //log.LogInformation("connected to DB");

        using (SqlCommand cmd = new SqlCommand(sql, conn))
        {
            SqlDataReader r = cmd.ExecuteReader();

            if (!r.HasRows)
            {
                json.Append("[]");
            }
            else
            {
                while (r.Read())
                {
                    json.Append(r.GetString(0));
                }
            }
        }
    }

    var response = new HttpResponseMessage(System.Net.HttpStatusCode.OK);
    response.Content = new StringContent(json.ToString(), Encoding.UTF8, "application/json");
    
    return response;
}
