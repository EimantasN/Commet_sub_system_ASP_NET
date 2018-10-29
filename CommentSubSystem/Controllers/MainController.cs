using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Library;
using Microsoft.AspNetCore.Mvc;
using T120B143.Models;

namespace T120B143.Controllers
{
    public class MainController : Controller
    {
        private readonly IDb _service;

        public MainController(IDb service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _service.GetComments();

            if (data != null && data.Count != 0)
            {
                return View(new CommentModel
                {
                    Comments = data
                });
            }
            else
            {
                return View(new CommentModel());
            }
        }
    }
}
