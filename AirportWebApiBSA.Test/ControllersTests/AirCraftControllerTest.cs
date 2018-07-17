using AirportWebApiBSA.BLL;
using AirportWebApiBSA.BLL.Services;
using AirportWebApiBSA.DAL.Interfaces;
using AirportWebApiBSA.DAL.Models;
using AirportWebApiBSA.Shared.DTOs;
using AirportWebApiBSA.WEB.Controllers;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace AirportWebApiBSA.Test.ControllersTests
{

    [TestFixture]
    public class AirCraftControllerTest
    {
        [Test]
        public void GetWhenGivenIdReturnsItemDTO()
        {
            //Arange
            var mockAirCraftTypeRepository = new Mock<IRepository<AirCraftType>>();
            mockAirCraftTypeRepository.Setup(a => a.Get(1))
                .Returns(new AirCraftType
                {
                    Id = 1,
                    Model = "Concord",
                    PassengersCapacity = 75,
                    CargoCapacity = 300
                });
            var mockAirCraftRepository = new Mock<IRepository<AirCraft>>();
            mockAirCraftRepository.Setup(a => a.Get(1))
                .Returns(new AirCraft()
                {
                    Id = 1,
                    Name = "DF-23",
                    AirCraftType = mockAirCraftTypeRepository.Object.Get(1),
                    Manufactured = new DateTime(1990, 12, 01),
                    Age = DateTime.Now - new DateTime(1990, 12, 01)
                });
            var mockUOW = new Mock<IUnitOfWork>();
            mockUOW.Setup(a => a.AirCrafts).Returns(mockAirCraftRepository.Object);
            mockUOW.Setup(a => a.AirCraftTypes).Returns(mockAirCraftTypeRepository.Object);
            var service = new AirCraftService(mockUOW.Object, new Mapper(new MapperConfiguration((cfg => cfg.AddProfile(new MappingProfile(mockUOW.Object))))));
            var controller = new AirCraftController(service);
            //Act
            var Result = controller.Get(1);
            //Accept
            Assert.IsTrue(CustomAsserts.AreEqualByJson(Result, new JsonResult((new AirCraftDTO
            {
                Id = 1,
                Name = "DF-23",
                AirCraftTypeId = 1,
                Manufactured = new DateTime(1990, 12, 01),
                Age = mockAirCraftRepository.Object.Get(1).Age
            }))));
        }
        [Test]
        public void PostWhenGivenIdReturnsItemDTO()
        {
            //Arange
            var mockAirCraftTypeRepository = new Mock<IRepository<AirCraftType>>();
            mockAirCraftTypeRepository.Setup(a => a.Get(1))
                .Returns(new AirCraftType
                {
                    Id = 1,
                    Model = "Concord",
                    PassengersCapacity = 75,
                    CargoCapacity = 300
                });
            var mockAirCraftRepository = new Mock<IRepository<AirCraft>>();
            AirCraft airCraft = new AirCraft();
            mockAirCraftRepository.Setup(a => a.Create(It.IsNotNull<AirCraft>())).Callback((AirCraft a) => airCraft = a);
            var mockUOW = new Mock<IUnitOfWork>();
            mockUOW.Setup(a => a.AirCrafts).Returns(mockAirCraftRepository.Object);
            mockUOW.Setup(a => a.AirCraftTypes).Returns(mockAirCraftTypeRepository.Object);
            var service = new AirCraftService(mockUOW.Object, new Mapper(new MapperConfiguration((cfg => cfg.AddProfile(new MappingProfile(mockUOW.Object))))));
            var controller = new AirCraftController(service);
            //Act
            controller.Post(new AirCraftDTO
            {
                Id = 1,
                Name = "DF-23",
                AirCraftTypeId = 1,
                Manufactured = new DateTime(1990, 12, 01),
                Age = DateTime.Now - new DateTime(1990, 12, 01)
            });
            //Accept
            Assert.IsTrue(CustomAsserts.AreEqualByJson(airCraft, new AirCraft
            {
                Id = 1,
                AirCraftTypeId = 1,
                Name = "DF-23",
                AirCraftType = mockAirCraftTypeRepository.Object.Get(1),
                Manufactured = new DateTime(1990, 12, 01),
                Age = airCraft.Age
            }));
        }
        [Test]
        public void PutWhenGivenIdReturnsItemDTO()
        {
            //Arange
            var mockAirCraftTypeRepository = new Mock<IRepository<AirCraftType>>();
            mockAirCraftTypeRepository.Setup(a => a.Get(1))
                .Returns(new AirCraftType
                {
                    Id = 1,
                    Model = "Concord",
                    PassengersCapacity = 75,
                    CargoCapacity = 300
                });
            var mockAirCraftRepository = new Mock<IRepository<AirCraft>>();
            AirCraft airCraft = new AirCraft
            {
                Id = 1,
                Name = "DF-24",
                AirCraftTypeId = 1,
                Manufactured = new DateTime(1990, 12, 01),
                Age = DateTime.Now - new DateTime(1990, 12, 01)
            };
            mockAirCraftRepository.Setup(a => a.Update(It.IsNotNull<AirCraft>())).Callback((AirCraft a) => airCraft = a);
            var mockUOW = new Mock<IUnitOfWork>();
            mockUOW.Setup(a => a.AirCrafts).Returns(mockAirCraftRepository.Object);
            mockUOW.Setup(a => a.AirCraftTypes).Returns(mockAirCraftTypeRepository.Object);
            var service = new AirCraftService(mockUOW.Object, new Mapper(new MapperConfiguration((cfg => cfg.AddProfile(new MappingProfile(mockUOW.Object))))));
            var controller = new AirCraftController(service);
            //Act
            controller.Put(1, new AirCraftDTO
            {
                Id = 1,
                Name = "DF-23",
                AirCraftTypeId = 1,
                Manufactured = new DateTime(1990, 12, 01),
                Age = DateTime.Now - new DateTime(1990, 12, 01)
            });
            //Accept
            Assert.IsTrue(CustomAsserts.AreEqualByJson(airCraft, new AirCraft
            {
                Id = 1,
                AirCraftTypeId = 1,
                Name = "DF-23",
                AirCraftType = mockAirCraftTypeRepository.Object.Get(1),
                Manufactured = new DateTime(1990, 12, 01),
                Age = airCraft.Age
            }));
        }
        [Test]
        public void DeleteWhenGivenIdReturnsItemDTO()
        {
            //Arange
            var mockAirCraftTypeRepository = new Mock<IRepository<AirCraftType>>();
            mockAirCraftTypeRepository.Setup(a => a.Get(1))
                .Returns(new AirCraftType
                {
                    Id = 1,
                    Model = "Concord",
                    PassengersCapacity = 75,
                    CargoCapacity = 300
                });
            var mockAirCraftRepository = new Mock<IRepository<AirCraft>>();
            AirCraft airCraft = new AirCraft
            {
                Id = 1,
                Name = "DF-24",
                AirCraftTypeId = 1,
                Manufactured = new DateTime(1990, 12, 01),
                Age = DateTime.Now - new DateTime(1990, 12, 01)
            };
            mockAirCraftRepository.Setup(a => a.Delete(1)).Callback(() => airCraft = null);
            var mockUOW = new Mock<IUnitOfWork>();
            mockUOW.Setup(a => a.AirCrafts).Returns(mockAirCraftRepository.Object);
            mockUOW.Setup(a => a.AirCraftTypes).Returns(mockAirCraftTypeRepository.Object);
            var service = new AirCraftService(mockUOW.Object, new Mapper(new MapperConfiguration((cfg => cfg.AddProfile(new MappingProfile(mockUOW.Object))))));
            var controller = new AirCraftController(service);
            //Act
            controller.Delete(1);
            //Accept
            Assert.IsNull(airCraft);
        }
    }
}
