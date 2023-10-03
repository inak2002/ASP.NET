using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace PurchaseModuleAPI.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class SupplierController : Controller
    {
        [HttpPost]

        public IActionResult saveSupplier(SupplierModel sup)
        { 
            string connStr = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SupplierDatabase;Integrated Security=True;MultipleActiveResultSets=True";
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Connection = connection;
                sqlCommand.CommandText = "PO_spSaveSupplier";
                sqlCommand.Parameters.AddWithValue("@p_name", sup.SupplierName);
                sqlCommand.Connection.Open();
                sqlCommand.ExecuteNonQuery();
            }
            return Ok();
        }
    }
}

