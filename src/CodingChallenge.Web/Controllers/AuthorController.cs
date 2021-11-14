using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CodingChallenge.Web.Controllers
{
    [Route("[controller]")]
    public class BookController : Controller
    {
        // GET
        public async Task<IActionResult> Index()
        {
            await Task.CompletedTask;
            return Ok();
        }
    }
}