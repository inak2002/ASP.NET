using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace Firstapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DBController : ControllerBase
    {
        [HttpPost]
        public string pname()
        {
            DataTable dt = new DataTable();

            SqlConnection con = new SqlConnection();
            con.ConnectionString= "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;MultipleActiveResultSets=True";
            con.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "pname";
            cmd.Parameters.Add("@empname", SqlDbType.VarChar, 10).Value = "chacha";
            cmd.Parameters.Add("@salary", SqlDbType.Int).Value = 70000;

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            con.Close();

            return dt.Rows[0]["empid"].ToString();

        }
    }
}
