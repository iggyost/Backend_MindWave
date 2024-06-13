using Backend_MindWave.ApplicationData;
using Microsoft.AspNetCore.Mvc;

namespace Backend_MindWave.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersResultController : Controller
    {
        public static MindWaveDbContext context = new MindWaveDbContext();
        [HttpGet]
        [Route("set/{userId}/{characteristicId}/{percent}")]
        public ActionResult<IEnumerable<UsersResult>> Set(int userId, int characteristicId, int percent)
        {
            try
            {
                var selectedUserResult = context.UsersResults.Where(x => x.UserId == userId && x.CharacteristicId == characteristicId).FirstOrDefault();
                if (selectedUserResult != null)
                {
                    int userPercent = selectedUserResult.Rating;
                    int newPercent;
                    if (userPercent == 0  && percent == 0)
                    {
                        newPercent = 0;
                    }
                    else
                    {
                        newPercent = (userPercent + percent) / 2;
                    }
                    var selectedUser = context.UsersResults.Where(x => x.UserId == userId && x.CharacteristicId == characteristicId).FirstOrDefault();
                    selectedUser.Rating = newPercent;
                    context.UsersResults.Update(selectedUser);
                    context.SaveChanges();
                    return Ok();
                }
                else
                {
                    UsersResult newUsersResult = new UsersResult()
                    {
                        UserId = userId,
                        CharacteristicId = characteristicId,
                        Rating = percent
                    };
                    context.UsersResults.Add(newUsersResult);
                    context.SaveChanges();
                    return Ok();
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ошибка сервера");
            }
        }
        [HttpGet]
        [Route("get/{userId}")]
        public ActionResult<IEnumerable<UsersResult>> Get(int userId)
        {
            try
            {
                var data = context.UsersResults.Where(x => x.UserId == userId).ToList();
                if (data != null)
                {
                    return data;
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ошибка сервера");
            }
        }
    }
}