using Backend_MindWave.ApplicationData;
using Microsoft.AspNetCore.Mvc;

namespace Backend_MindWave.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        public static MindWaveDbContext context = new MindWaveDbContext();

        [HttpGet]
        [Route("enter/{phone}/{password}")]
        public ActionResult<IEnumerable<User>> Enter(string phone, string password)
        {
            try
            {
                var user = context.Users.Where(x => x.Phone == phone && x.Password == password).FirstOrDefault();
                if (user != null)
                {
                    return Ok(user);
                }
                else
                {
                    return BadRequest("Неверный пароль!");
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ошибка сервера");
            }
        }
        [HttpGet]
        [Route("phone/{phone}")]
        public ActionResult<IEnumerable<User>> ValidatePhone(string phone)
        {
            try
            {
                var user = context.Users.Where(x => x.Phone == phone).FirstOrDefault();
                if (user != null)
                {
                    return Ok();
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
        [HttpGet]
        [Route("reg/{name}/{phone}/{password}")]
        public ActionResult<IEnumerable<User>> RegUser(string name, string phone, string password)
        {
            try
            {
                var checkAvail = context.Users.Where(x => x.Phone == phone).FirstOrDefault();
                if (checkAvail == null)
                {
                    User user = new User()
                    {
                        Password = password,
                        Phone = phone,
                        Name = name,
                    };
                    context.Users.Add(user);
                    context.SaveChanges();
                    return Ok(user);
                }
                else
                {
                    return BadRequest("Пользователь с таким номером уже есть");
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ошибка сервера");
            }
        }
    }
}