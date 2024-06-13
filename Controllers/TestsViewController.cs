using Backend_MindWave.ApplicationData;
using Microsoft.AspNetCore.Mvc;

namespace Backend_MindWave.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestsViewController : Controller
    {
        public static MindWaveDbContext context = new MindWaveDbContext();
        [HttpGet]
        [Route("get/{testId}")]
        public ActionResult<IEnumerable<TestsView>> Get(int testId)
        {
            try
            {
                var data = context.TestsViews.Where(x => x.TestId == testId).ToList();
                return data;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ошибка сервера");
            }
        }
    }
}