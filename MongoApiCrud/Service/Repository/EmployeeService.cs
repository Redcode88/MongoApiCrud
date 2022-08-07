using Microsoft.Extensions.Configuration;
using MongoApiCrud.Entitys;
using MongoApiCrud.Service.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using Microsoft.Extensions.Options;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace MongoApiCrud.Service.Repository
{
    public class EmployeeService : IEmployee
    {
        private readonly IEmployee _Iemployee;

        public EmployeeService()
        {
        }

        public EmployeeService(IEmployee Iemployee)
        {
            _Iemployee = Iemployee;
        }

        
       

        public object AddEmployee(Employes ObjVm)
        {
            var Client = new MongoClient("mongodb://localhost:27017");
            var Db = Client.GetDatabase("EmployeeDB");
            var collection = Db.GetCollection<Employes>("Employee");
            if (ObjVm.Id == null )
            {

                collection.InsertOne(ObjVm);
                return new String("Insert Done");
            }
            else
            {
                var update = collection.FindOneAndUpdateAsync(Builders<Employes>.Filter.Eq("Id", ObjVm.Id), 
                    Builders<Employes>.Update
                    .Set("Name", ObjVm.Name)
                    .Set("phone", ObjVm.phone)
                    .Set("Address", ObjVm.Address)
                    .Set("City", ObjVm.City)
                    .Set("Country", ObjVm.Country));
            }
            //upsert code here 
            return new String("Update Done");
        }

        public object DeleteEmployee(string id)
        {
            var Client = new MongoClient("mongodb://localhost:27017");
            var Db = Client.GetDatabase("EmployeeDB");
            var collection = Db.GetCollection<Employes>("Employee");
            var DeletedRecored = collection.DeleteOne(Builders<Employes>.Filter.Eq("Id", id));
            return DeletedRecored.DeletedCount;
        }

        public object GetEmployeeById(string Id)
        {
            var Client = new MongoClient("mongodb://localhost:27017");
            var Db = Client.GetDatabase("EmployeeDB");
            var collection = Db.GetCollection<Employes>("Employee");
            var SelectedEmployee = collection.Find(Builders<Employes>.Filter.Where(e => e.Id == Id)).FirstOrDefault();
            return SelectedEmployee;
        }

        public  object GetEmployes()
        {
            var Client = new MongoClient("mongodb://localhost:27017");
            var Db = Client.GetDatabase("EmployeeDB");
            var collection = Db.GetCollection<Employes>("Employee").Find(new BsonDocument()).ToList();
            return collection;

        }
    }
}
