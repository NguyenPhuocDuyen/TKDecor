using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.ViewModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Net.Http.Json;


namespace ClientMVC.Controllers
{
    public class AccountController : Controller
    {
        HttpResponseMessage response;
        string responseString;

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(UserLogin userLogin)
        {
            if (!ModelState.IsValid)
            {
                return View(userLogin);
            }

            try
            {
                User userTemp = new()
                {
                    Email = userLogin.Email,
                    Password = userLogin.Password
                };
                response = GobalVariables.WebAPIClient.PostAsJsonAsync("Users/Login", userTemp).Result;
                if (response.IsSuccessStatusCode)
                {
                    responseString = response.Content.ReadAsStringAsync().Result;
                    User user = JsonConvert.DeserializeObject<User>(responseString);

                    HttpContext.Session.Set("IsLoggedIn", BitConverter.GetBytes(true));

                    HttpContext.Session.SetString("role", user.Role.Description);
                    HttpContext.Session.SetString("fullname", user.FullName);

                    //set token by password becasue password = token return from api
                    HttpContext.Session.SetString("token", user.Password);
                    GobalVariables.WebAPIClient.AddAuthorizationHeader(user.Password);

                    // Lưu trữ token vào cookie
                    Response.Cookies.Append("access_token", user.Password, new CookieOptions
                    {
                        HttpOnly = false,
                        SameSite = SameSiteMode.None,
                        Secure = true,
                        Expires = DateTimeOffset.UtcNow.AddDays(1)
                    });

                    return RedirectToAction("Index", "Home");
                }
            }
            catch { }

            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(UserRegister userRegister)
        {
            if (!ModelState.IsValid)
            {
                return View(userRegister);
            }

            try
            {
                User user = new()
                {
                    Email = userRegister.Email,
                    FullName = userRegister.FullName,
                    Phone = userRegister.Phone,
                    Password = userRegister.Password,
                    Address = userRegister.Address
                };
                response = GobalVariables.WebAPIClient.PostAsJsonAsync("Users/PostUser", user).Result;
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Login));
                }
            }
            catch { }

            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
