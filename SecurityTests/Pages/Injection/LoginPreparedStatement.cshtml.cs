using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace SecurityTests.Pages.Injection
{
    public class LoginPreparedStatementModel : PageModel
    {
        public void OnPost(string email, string password)
        {
            var connection = new SqlConnection("Data Source=localhost;Initial Catalog=SecurityTests;Integrated Security=True");
            connection.Open();


            this.SqlQuery = "SELECT * FROM dbo.USERS WHERE email=@email AND password = @password";
            var command = new SqlCommand(this.SqlQuery, connection);
            command.Parameters.AddWithValue("@email", email);
            command.Parameters.AddWithValue("@password", password);
            var reader = command.ExecuteReader();

            // ..

            reader.Close();
            connection.Close();
        }
        public string SqlQuery { get; set; }

    }
}