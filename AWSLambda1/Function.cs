using Amazon.Lambda.Core;
using Microsoft.Data.SqlClient;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.

namespace AWSLambda1;

public class Function
{

    /// <summary>
    /// A simple function that takes a string and does a ToUpper
    /// </summary>
    /// <param name="input">The event for the Lambda function handler to process.</param>
    /// <param name="context">The ILambdaContext that provides methods for logging and describing the Lambda environment.</param>
    /// <returns></returns>
    [LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]
    public string FunctionHandler(ILambdaContext context)
    {
        string connection = "Server=sql.bsite.net\\MSSQL2016;Database=coder123_Learning;User Id=coder123_Learning;Password=admin;TrustServerCertificate=true;";

        string sqlQuery = $"Insert Into Employees Values('Shraddha',1,4,44000,'1-1-2022')";

        try
        {
            using (SqlConnection con = new SqlConnection(connection))
            {
                using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
        catch (Exception ex)
        {
            return $"Error occurred while inserting data to Employees table {ex.Message}";
        }

        return $"Job completed successfull at {DateTime.Now.ToString()}";
    }


}
