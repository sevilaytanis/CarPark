using CarPark.Business.Abstract;
using CarPark.Core.Models;
using CarPark.DataAcess.Abstract;
using CarPark.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarPark.Business.Concrete
{
    public class EmployeeManager : IEmployeeService
    {
        private readonly IEmployeeDataAccess _employeeDataAccess;
        public EmployeeManager(IEmployeeDataAccess employeeDataAccess)
        {
            _employeeDataAccess = employeeDataAccess;

        }
        public GetManyResult<Employee> EmployeeByAges()
        {
            var personList = _employeeDataAccess.AsQueryable();

            return personList;

        }
    }
}
