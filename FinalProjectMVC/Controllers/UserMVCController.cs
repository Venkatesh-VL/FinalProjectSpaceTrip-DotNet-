using FinalProjectMVC.Helper;
using FinalProjectWEBAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectMVC.Controllers
{
    public class UserMVCController : Controller
    {
        


        

            private readonly ILogger<Controller> _logger;
            private readonly SpaceTripContext _context;

            public UserMVCController(ILogger<HomeController> logger, SpaceTripContext context)
            {
                _logger = logger;
                _context = context;
            }

            SpaceAPI _api = new SpaceAPI();

        public IActionResult Index()
        {
            return View();
        }



        public IActionResult Homepage()
            {
                return View();
            }

           

            public async Task<IActionResult> ViewUsers()
            {
                List<Userinfo> data = new List<Userinfo>();
                HttpClient cli = _api.Initial();
                HttpResponseMessage result = await cli.GetAsync("api/Userinfoes");
                if (result.IsSuccessStatusCode)
                {
                    var res = result.Content.ReadAsStringAsync().Result;
                    data = JsonConvert.DeserializeObject<List<Userinfo>>(res);
                }


                return View(data);
            }


            public IActionResult Create()
            {
                ViewBag.year = new SelectList(_context.Years, "Years", "Years");

                return View();

            }


            [HttpPost]
            public async Task<IActionResult> Create(Userinfo user)
            {
                HttpClient cli = _api.Initial();
                string newuser = JsonConvert.SerializeObject(user);
                StringContent content = new StringContent(newuser, Encoding.UTF8, "application/json");
                HttpResponseMessage response = cli.PostAsync(cli.BaseAddress + "api/Userinfoes", content).Result;
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("ViewUsers");
                }
                return View();

            }
        }
}
