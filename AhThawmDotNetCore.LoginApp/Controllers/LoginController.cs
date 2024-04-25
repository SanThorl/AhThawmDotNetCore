using AhThawmDotNetCore.LoginApp.EFDbContext;
using Microsoft.AspNetCore.Mvc;

namespace AhThawmDotNetCore.LoginApp.Controllers
{
    public class LoginController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public LoginController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        
        public async Task<IActionResult> Index(UsersModel user)
        {
            var item =_appDbContext.Users.FirstOrDefault(x => x.UserName == user.UserName && x.Password == user.Password);
            if (item is null) return View();

            string sessionId = Guid.NewGuid().ToString();
            DateTime sessionExpired = DateTime.Now.AddSeconds(30);

            CookieOptions cookie = new CookieOptions();
            cookie.Expires = DateTime.Now.AddMinutes(1);
            Response.Cookies.Append("UserId", item.UserId, cookie);
            Response.Cookies.Append("SessionId", sessionId, cookie);

            await _appDbContext.Login.AddAsync(new LoginModel
            {
                SessionId = sessionId,
                UserId = item.UserId,
                SessionExpired = sessionExpired
            });

            await _appDbContext.SaveChangesAsync();

            return Redirect("/Home");
        }
    }
}
