using CarPark.Core.Settings;
using CarPark.DataAcess.Abstract;
using CarPark.DataAcess.Context;
using CarPark.DataAcess.Repository;
using CarPark.Entities.Concrete;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarPark.DataAcess.Concrete
{
    public class EmployeeDataAccess : MongoRepositoryBase<Employee>, IEmployeeDataAccess
    {
        private readonly MongoDBContext _context;
        private readonly IMongoCollection<Employee> _collection;

        public EmployeeDataAccess(IOptions<MongoSettings> settings) : base(settings)
        {
            _context = new MongoDBContext(settings);
            _collection = _context.GetCollection<Employee>();
        }

        public List<Employee> GetEmployeesWithRoles()
        {
            return _collection.AsQueryable().Where(x => x.Password == "12345").ToList();

        }

     
    }
}
