using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using webApi.Services;
using webApi.Models;
using webApi.Contexts;

namespace webApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        LoginService _loginService;
        private readonly DataBaseContext ctx;
        public LoginController(LoginService loginService, DataBaseContext ctx)
        {
            this._loginService = loginService;
            this.ctx = ctx;
        }
        [HttpGet("{id}/{pass}")]
        public ActionResult Get(string id, string pass)
        {

            List<Login> Respon = new List<Login>();
            Login aux = new Login();
            User user = ctx.users.FirstOrDefault(p => p.usuario == id && p.pass == pass);

            if (user != null)
            {
                aux.est = "ok";
                aux.msg = "usuario valido";

            }
            else
            {
                aux.est = "error";
                aux.msg = "contraseña o usuario no valido";

            }
            Respon.Add(aux);

            return Ok(Respon);
        }

        [HttpPost]
        public ActionResult Post(User usu)
        {
            List<Login> Respon = new List<Login>();
            Login aux = new Login();
            try
            {
                ctx.users.Add(usu);
                ctx.SaveChanges();
                aux.est = "ok";
                aux.msg = "Usuario Creado Correctamente";

            }
            catch (Exception e)
            {
                aux.est = "Error";
                aux.msg = "Error al Insertar Usuario";



            }

            Respon.Add(aux);
            return Ok(Respon);
        }
    }
}
