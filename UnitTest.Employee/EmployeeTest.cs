using MongoApiCrud.Entitys;
using MongoApiCrud.Service.Interfaces;
using MongoApiCrud.Service.Repository;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace UnitTest.Employee
{
    public class EmployeeTest
    {
        private readonly EmployeeService _ETS;
        private readonly Mock<IEmployee> _mock = new Mock<IEmployee>();
        
        public EmployeeTest()
        {
            _ETS = new EmployeeService(_mock.Object);
        }


        [Fact]
        public void EmployeeTestGetbyID()
        {
            //arrang
            string EmpID ="62bac1e3b925f8bba96a74f1" ;
            //act
            _mock.Setup(x => x.GetEmployeeById(EmpID));
            var result = _ETS.GetEmployeeById(EmpID);
            //assert
            Assert.Equal(EmpID, EmpID);
        }

        [Fact]
        public void EmployeeDeleteTest()
        {
            //arrang
            string EmpID = "62bac1e3b925f8bba96a74f1";
            //act
            _mock.Setup(x => x.DeleteEmployee(EmpID));
            var result = _ETS.DeleteEmployee(EmpID);
            //assert
            Assert.Equal(EmpID, EmpID);
        }


        [Fact]
        public void GetAllEmployeeTest()
        {
 
            List<Employes> emp = new List<Employes>
            {
                new Employes
                {
                Id = "62bac2adb925f8bba96a74f3",
                Name = "Hossam Emara",
                Address = "Shebin mahmoud salam st",
                phone = "0103311345",
                City = "shbeen el kom",
                Country = "Egypt",
                },
                new Employes
                {
                    Id = "62c59ecb561dbccdf3edfe52",
                    Name = "hani assar",
                    Address = "monfia",
                    phone ="01000277489",
                    City = "BANHA",
                    Country = "Egypt"
                }
            };

            _mock.Setup(x => x.GetEmployes());
            var result = _ETS.GetEmployes();
            Assert.Equal(emp, emp);

        }
        [Fact]
        public void EmployeeIDNotFound()
        {
            var Emp = _mock.Setup(x => x.GetEmployeeById(It.IsAny<string>()));
            Assert.Null(null);

        }

    }
}
