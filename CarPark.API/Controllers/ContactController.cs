﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarPark.User.Controllers
{
    public class ContactController : Controller
    {
        private IStringLocalizer<SharedResource> _localizer;

        public ContactController(IStringLocalizer<SharedResource> localizer)
        {
            _localizer = localizer;
        }
        public IActionResult Index()
        {
            var welcomeValue = _localizer["Welcome"];
            return View();
        }
    }
}
