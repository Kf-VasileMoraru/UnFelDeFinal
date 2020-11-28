using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UnFelDeFinal.Controllers;
using UnFelDeFinal.Domain;
using UnFelDeFinal.Extern.Dtos;
using UnFelDeFinal.Services;
using UnFelDeFinal.Models;

namespace WebApi_UnitTestProject1
{
    [TestClass]
    public class EServiceControllerTest
    {
        private Mock<IMapper> mockMapper;
        private Mock<IEServiceService> mockEServiceService;
        private EserviceController eServiceController;
        private List<ElectronicService> eServiceList;

        [TestInitialize]
        public void Initializer()
        {
            mockMapper = new Mock<IMapper>();
            mockEServiceService = new Mock<IEServiceService>();
            eServiceController = new EserviceController(mockEServiceService.Object, mockMapper.Object);

            mockMapper.Setup(m => m.Map<ElectronicServiceDto>(It.IsAny<ElectronicService>())).Returns((ElectronicService e) => new ElectronicServiceDto()
            {
                Id = e.Id,
                Name = e.Name,
                Amount= e.Amount,
                TreasureAccount = e.TreasureAccount
            });

            eServiceList = new List<ElectronicService>
            {
                new ElectronicService
                {
                    Id = 1,
                    Name = "test 1 service",
                    Amount = 11.22m,
                    TreasureAccount = "Treasure1"
                },
                new ElectronicService
                {
                    Id = 2,
                    Name = "test 2 service",
                    Amount = 22.22m,
                    TreasureAccount = "Treasure2"
                },
            };

        }

        [TestMethod]
        [DataRow(2)]
        public void GetElectronicServiceById_ReturnElectronicServiceById(int id)
        {
            //Arrange
            ElectronicService expected = eServiceList.First(s => s.Id == id);
            mockEServiceService.Setup(m => m.GetEserviceById(It.IsAny<int>())).Returns(expected);

            //Act
            var eService = eServiceController.Get(id) as OkObjectResult;
            var result = eService.Value as ElectronicServiceDto;

            //Assert
            Assert.AreEqual("test 2 service", result.Name);
            Assert.AreEqual((int)HttpStatusCode.OK, eService.StatusCode);
        }


        [TestMethod]
        public void GetAllElectronicService_ReturnCountElectronicService()
        {
            //Arrange
            var expected = eServiceList.Count;
            mockEServiceService.Setup(m => m.GetEservice(It.IsAny<FilterOptions>())).Returns(eServiceList);

            var eService = eServiceController.Get(new FilterOptions()) as OkObjectResult;

            //Act
            var result = eService.Value; //as List<ElectronicServiceDto>;  IEnumerable<ElectronicServiceDto>


            //Assert
            //Console.WriteLine(result.Capacity);
            //Assert.AreEqual(expected,  result.count   );
            //result.PrintDump();
            //ToDo: mihai
            Assert.AreEqual((int)HttpStatusCode.OK, eService.StatusCode);
        }

        [TestMethod]
        public void CreateElectronicService_ReturnElectronicService()
        {
            //Arrange
            CreateElectronicServiceDto dto = new CreateElectronicServiceDto()
            {
                Name = "dtodto",
                Amount = 10,
                TreasureAccount = "dtodto"
            };

            mockEServiceService.Setup(m=> m.AddNewEservice(It.IsAny<CreateElectronicServiceDto>())).Returns((CreateElectronicServiceDto dto) => new ElectronicService
            {
                Name = dto.Name,
                Amount = dto.Amount,
                TreasureAccount = dto.TreasureAccount
            });

            //Act
            var result = eServiceController.Post(dto) as CreatedAtActionResult;

            //Assert
            Assert.AreEqual(HttpStatusCode.Created, (HttpStatusCode)result.StatusCode);
            Assert.AreEqual("dtodto", (result.Value as ElectronicServiceDto).Name);
        }
    }
}