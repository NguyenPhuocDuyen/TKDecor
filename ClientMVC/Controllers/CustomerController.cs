using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;

namespace ClientMVC.Controllers
{
    [SessionCheck]
    public class CustomerController : Controller
    {
        HttpResponseMessage response;
        string responseString;

        public IActionResult Cart()
        {
            try
            {
                response = GobalVariables.WebAPIClient.GetAsync($"Carts/GetCartsUser").Result;
                if (response.IsSuccessStatusCode)
                {
                    responseString = response.Content.ReadAsStringAsync().Result;
                    List<Cart> products = JsonConvert.DeserializeObject<List<Cart>>(responseString);
                    return View(products);
                }
            }
            catch { }

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Details()
        {
            try
            {
                response = GobalVariables.WebAPIClient.GetAsync("Users/GetUserInfo").Result;
                if (response.IsSuccessStatusCode)
                {
                    responseString = response.Content.ReadAsStringAsync().Result;
                    User user = JsonConvert.DeserializeObject<User>(responseString);
                    user.Password = "";
                    return View(user);
                }
            }
            catch { }

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Orders()
        {
            try
            {
                response = GobalVariables.WebAPIClient.GetAsync("Orders/GetOrdersOfUser").Result;
                if (response.IsSuccessStatusCode)
                {
                    responseString = response.Content.ReadAsStringAsync().Result;
                    List<Order> orders = JsonConvert.DeserializeObject<List<Order>>(responseString);
                    return View(orders);
                }
            }
            catch { }

            return RedirectToAction("Index", "Home");
        }

        public IActionResult OrderDetail(int id)
        {
            try
            {
                response = GobalVariables.WebAPIClient.GetAsync($"OrderDetails/{id}").Result;
                if (response.IsSuccessStatusCode)
                {
                    responseString = response.Content.ReadAsStringAsync().Result;
                    List<OrderDetail> orderDetail = JsonConvert.DeserializeObject<List<OrderDetail>>(responseString);
                    ViewBag.Order = orderDetail[0].Order;
                    return View(orderDetail);
                }
            }
            catch { }

            return RedirectToAction("Index", "Home");
        }
    }
}
