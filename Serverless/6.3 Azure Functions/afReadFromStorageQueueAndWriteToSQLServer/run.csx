using System;
using System.Data.SqlClient;

public static async Task Run(string myQueueItem, ILogger log)
{
    //log.LogInformation($"C# Queue trigger function processed: {myQueueItem}");

    var cs = Environment.GetEnvironmentVariable("DBCS");
    
    using (SqlConnection conn = new SqlConnection(cs))
    {
        conn.Open();

        var sql = $"Insert into Tasks (Msg, Updated) values ('{myQueueItem}', '{DateTime.UtcNow}')";

        //log.LogInformation("connected to DB");

        using (SqlCommand cmd = new SqlCommand(sql, conn))
        {
            int insertedCnt= 0;

            try
            {
                insertedCnt = await cmd.ExecuteNonQueryAsync();
            }
            catch (Exception e)
            {
                log.LogError(e.Message);
            }
            
            if (insertedCnt > 0)
            {
                log.LogInformation($"{insertedCnt} rows inserted");
            }
            else
            {
                log.LogWarning($"No rows updated");
            }
        }
    }
}
