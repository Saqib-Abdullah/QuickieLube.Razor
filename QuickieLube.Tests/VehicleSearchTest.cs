using Microsoft.AspNetCore.Mvc;
using Moq;
using QuickieLube.Application.Vehicles;
using QuickieLube.Domain.Vehicles;
using System;
using System.Collections.Generic;
using Xunit;
using System.Linq;

namespace QuickieLube.Tests
{
    public class VehicleSearchTest
    {
        private readonly VehicleRepository _vehicleRepository;
        private Mock<List<Vehicle>> _mockVehicleList;

        public VehicleSearchTest()
        {
            _mockVehicleList = new Mock<List<Vehicle>>();
            _vehicleRepository = new VehicleRepository(_mockVehicleList.Object);
        }
        [Fact]
        public void GetTest_ReturnsListofVehicles()
        {
            //arrange
            var mockVehicle = new List<Vehicle>()
            {
                new Vehicle(){Id="ON-AVX",Name="Ford",Description="2015 Ford",VIN="5GAK",Fleet="",LastService=DateTime.Now.AddDays(-10)},
                new Vehicle(){Id="TX-K51",Name="BMW",Description="2011 BMW",VIN="5ABC",Fleet="",LastService=DateTime.Now.AddDays(-11)},
                new Vehicle(){Id="TX-H71T",Name="mercedes",Description="2013 mercedes",VIN="6KDE",Fleet="",LastService=DateTime.Now.AddDays(-2)},
                new Vehicle(){Id="TX-511R",Name="BMW",Description="2021 BMW",VIN="9JIF",Fleet="Poland",LastService=DateTime.Now.AddDays(-4)},
                new Vehicle(){Id="TX-122G",Name="Ford",Description="2008 Ford",VIN="25TY",Fleet="Hertz",LastService=DateTime.Now.AddDays(-3)},
                new Vehicle(){Id="TX-2588QW",Name="BMW",Description="2004 BMW",VIN="AA258",Fleet="",LastService=DateTime.Now.AddDays(-20)},
                new Vehicle(){Id="ON-AV12X",Name="mercedes",Description="2007 mercedes",VIN="2GUE",Fleet="",LastService=DateTime.Now.AddDays(-5)},
            };

            _mockVehicleList.Object.AddRange(mockVehicle);

            //act
            var result = _vehicleRepository.SearchVehicle("");

            //assert
            var model = Assert.IsAssignableFrom<IEnumerable<Vehicle>>(result);
            Assert.Equal(7, model.Count());
        }
    }
}
