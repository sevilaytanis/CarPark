using CarPark.Core.Repository.Abstract;
using CarPark.Entities.Concrete;
using CarPark.User.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarPark.User.Controllers
{
    public class UserController : Controller

    {

        private readonly IStringLocalizer<UserController> _localizer;
        private readonly IRepository<Employee> _employeeRepository;

        public UserController(IStringLocalizer<UserController> localizer, IRepository<Employee> employeeRepository)
        {
            _localizer = localizer;
            _employeeRepository = employeeRepository;

        }

        public IActionResult Index()
        {
            var nameSurnameValue = _localizer["NameSurname"];
            return View();
        }

        public IActionResult Create()
        {

            //var result = _employeeRepository.InsertOne(new Employee
            //{
            //    Email = "sevilaytanis@gmail.com",
            //    Password = "123456789",
            //    CreateDate = DateTime.Now,
            //    Username = "stanis"
            //});

            //var resultAsyn = _employeeRepository.InsertOneAsync(new Employee
            //{
            //    Email = "sevilaytanis@gmail.com",
            //    Password = "123456789",
            //    CreateDate = DateTime.Now,
            //    Username = "stanis"
            //});
            //var resultAsyn = _employeeRepository.InsertMany(new List<Employee>
            //{
            //     new Employee{
            //    Email = "sevilaytanis@gmail.com11",
            //    Password = "123456789",
            //    CreateDate = DateTime.Now,
            //    Username = "stanis"
            //    },
            //     new Employee{
            //    Email = "sevilaytanis@gmail.com22",
            //    Password = "123456789",
            //    CreateDate = DateTime.Now,
            //    Username = "stanis"
            //    },
            //         new Employee{
            //    Email = "sevilaytanis@gmail.com33",
            //    Password = "123456789",
            //    CreateDate = DateTime.Now,
            //    Username = "stanis"
            //    },

            //});

            var result = _employeeRepository.AsQueryable();
            var result2 = _employeeRepository.GetById("634aea39ac3e18b1a1beb609");
            var result3 = _employeeRepository.DeleteOne(x => x.Email.Contains("22"));

            result2.Entity.Username = "mahmut";
            var result4 = _employeeRepository.ReplaceOne(result2.Entity, result2.Entity.Id.ToString());

            return View();
        }

        [HttpPost]
        public IActionResult Create(UserCreateRequestModel request)
        {

            return View();
        }
    }
}
