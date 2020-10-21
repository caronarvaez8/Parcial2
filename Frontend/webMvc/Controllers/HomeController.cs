using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using webMvc.Models;
using webMvc.Helper;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;

namespace webMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        UserApi _api = new UserApi();
        [HttpGet]
        public async Task<IActionResult> Login(string username = "", string password = "")
        {

            if (username != "" && password != "")
            {

                List<RespModel> resp = new List<RespModel>();
                HttpClient client = _api.Initial();
                HttpResponseMessage res = await client.GetAsync(username + "/" + password);
                if (res.IsSuccessStatusCode)
                {
                    var result = res.Content.ReadAsStringAsync().Result;
                    resp = JsonConvert.DeserializeObject<List<RespModel>>(result);
                }

                var jsonResp = resp[0];
                if (jsonResp.est == "ok")
                {
                    Console.Write("Redire");
                    ViewBag.Message = "ok";

                }
                //Redireccion a la pagina Bienvenida
            }
            return home();
        }

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Privacy(string username = "", string password = "", string cpassword = "", string email = "")
        {
            if (username != "" && password != "" && email != "" && cpassword != "")
            {
                if (password == cpassword)
                {

                    UserModel userTemp = new UserModel();
                    userTemp.usuario = username;
                    userTemp.pass = password;
                    userTemp.email = email;
                    List<RespModel> resp = new List<RespModel>();
                    HttpClient client = _api.Initial();
                    HttpResponseMessage res = await client.PostAsync("", new StringContent(JsonConvert.SerializeObject(userTemp), Encoding.UTF8, "application/json"));

                    var result = res.Content.ReadAsStringAsync().Result;

                    Console.Write(result);
                    resp = JsonConvert.DeserializeObject<List<RespModel>>(result);

                    var jsonResp = resp[0];
                    ViewBag.Message = jsonResp.msg;
                    if (jsonResp.est == "OK")
                    {
                        //Console.Write("ddddd", jsonResp.msg);
                        ViewBag.Message = jsonResp.msg;
                        return RedirectToAction("Login");
                    }




                }



            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult home()
        {
            return View();
        }
    }
}
