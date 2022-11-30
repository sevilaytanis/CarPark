using CarPark.Entities.Concrete;
using CarPark.User.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CarPark.User.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IStringLocalizer<HomeController> _localizer;

        private readonly IMongoClient client;
        public HomeController(ILogger<HomeController> logger, IStringLocalizer<HomeController> localizer)
        {
            _logger = logger;
            _localizer = localizer;

            var settings = MongoClientSettings.FromConnectionString("mongodb+srv://apiuser:fener1907@carparkcluster.fvc7erf.mongodb.net/?retryWrites=true&w=majority");
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
             client = new MongoClient(settings);
      

        }

        public IActionResult Index()
        {
            //var database = client.GetDatabase("CarPark");// db ye bağlandık...


            //var jsonString = System.IO.File.ReadAllText("cities.json");
            //var citiesModel = JsonConvert.DeserializeObject<List<City>>(jsonString);

            //var collection = database.GetCollection<City>("City");//tabloya bağlandık..

            //collection.InsertMany(citiesModel);


    



            // collection.InsertOne();

            var sayHello = _localizer["Say_Hello"];

            var cultorInfo = CultureInfo.GetCultureInfo("tr-TR");
            Thread.CurrentThread.CurrentCulture = cultorInfo;
            Thread.CurrentThread.CurrentUICulture = cultorInfo;


             sayHello = _localizer["Say_Hello"];

            var customer = new Customer()
            {
                Name = "sevilay",
                Age = 34

            };

            _logger.LogError("Customer Error: {@customer}", customer);// json formatte kaydeder böyle yaaprsan objecti...

            _logger.LogInformation("first log ...");
            _logger.LogError("first error log ...");

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}
