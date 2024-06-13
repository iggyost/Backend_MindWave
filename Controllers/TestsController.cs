using Backend_MindWave.ApplicationData;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;

namespace Backend_MindWave.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestsController : Controller
    {
        public static MindWaveDbContext context = new MindWaveDbContext();
        [HttpGet]
        [Route("get/{categoryId}")]
        public ActionResult<IEnumerable<Test>> Get(int categoryId)
        {
            try
            {
                var data = context.Tests.Where(x => x.CategoryId == categoryId).ToList();
                return data;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ошибка сервера");
            }
        }
    }
}