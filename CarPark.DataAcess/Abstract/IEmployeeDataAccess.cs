using CarPark.Core.Repository.Abstract;
using CarPark.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarPark.DataAcess.Abstract
{
    public interface IEmployeeDataAccess : IRepository<Employee>
    {
        List<Employee> GetEmployeesWithRoles();
    }
}
