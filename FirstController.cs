using Firstapp.entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Firstapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FirstController : ControllerBase
    {
        [HttpGet] 
        public string Myfirstmethod(string Orderitem)
        {
            Kitchen kit = new Kitchen();
            kit.orderitem = Orderitem;
            return kit.breakfast();
        }
    }
}
