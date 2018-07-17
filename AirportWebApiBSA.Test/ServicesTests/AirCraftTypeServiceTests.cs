using AirportWebApiBSA.BLL;
using AirportWebApiBSA.BLL.Services;
using AirportWebApiBSA.DAL.Interfaces;
using AirportWebApiBSA.DAL.Models;
using AirportWebApiBSA.Shared.DTOs;
using AutoMapper;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AirportWebApiBSA.Test.ServicesTests
{
    [TestFixture]
    public class AirCraftTypeServiceTests
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

            var mockUOW = new Mock<IUnitOfWork>();
            mockUOW.Setup(a => a.AirCraftTypes).Returns(mockAirCraftTypeRepository.Object);
            var service = new AirCraftTypeService(mockUOW.Object, new Mapper(new MapperConfiguration((cfg => cfg.AddProfile(new MappingProfile(mockUOW.Object))))));
            //Act
            var Result = service.Get(1);
            //Accept
            Assert.IsTrue(CustomAsserts.AreEqualByJson(Result, new AirCraftTypeDTO
            {
                Id = 1,
                Model = "Concord",
                PassengersCapacity = 75,
                CargoCapacity = 300
            }));
        }
        [Test]
        public void CreateWhenGivenItemDTOReturnsItem()
        {
            //Arange
            var mockAirCraftTypeRepository = new Mock<IRepository<AirCraftType>>();
            AirCraftType airCraftType = new AirCraftType();
            mockAirCraftTypeRepository.Setup(a => a.Create(It.IsNotNull<AirCraftType>())).Callback((AirCraftType a) => airCraftType = a);
            var mockUOW = new Mock<IUnitOfWork>();
            mockUOW.Setup(a => a.AirCraftTypes).Returns(mockAirCraftTypeRepository.Object);
            var service = new AirCraftTypeService(mockUOW.Object, new Mapper(new MapperConfiguration((cfg => cfg.AddProfile(new MappingProfile(mockUOW.Object))))));
            //Act
            service.Create(new AirCraftTypeDTO
            {
                Id = 1,
                Model = "Concord",
                PassengersCapacity = 75,
                CargoCapacity = 300
            });
            //Accept
            Assert.IsTrue(CustomAsserts.AreEqualByJson(airCraftType, new AirCraftType
            {
                Id = 1,
                Model = "Concord",
                PassengersCapacity = 75,
                CargoCapacity = 300
            }));
        }
        [Test]
        public void UpdateWhenGivenIdAndItemDTOReturnsItem()
        {
            //Arange
            var mockAirCraftTypeRepository = new Mock<IRepository<AirCraftType>>();
            AirCraftType airCraftType = new AirCraftType
            {
                Id = 1,
                Model = "Concord",
                PassengersCapacity = 75,
                CargoCapacity = 300
            };
            mockAirCraftTypeRepository.Setup(a => a.Update(It.IsNotNull<AirCraftType>())).Callback((AirCraftType a) => airCraftType = a);
            var mockUOW = new Mock<IUnitOfWork>();
            mockUOW.Setup(a => a.AirCraftTypes).Returns(mockAirCraftTypeRepository.Object);
            var service = new AirCraftTypeService(mockUOW.Object, new Mapper(new MapperConfiguration((cfg => cfg.AddProfile(new MappingProfile(mockUOW.Object))))));
            //Act
            service.Update(1, new AirCraftTypeDTO
            {
                Id = 1,
                Model = "Concord",
                PassengersCapacity = 120,
                CargoCapacity = 300
            });
            //Accept
            Assert.IsTrue(CustomAsserts.AreEqualByJson(airCraftType, new AirCraftType
            {
                Id = 1,
                Model = "Concord",
                PassengersCapacity = 120,
                CargoCapacity = 300
            }));
        }
    
        [Test]
        public void DeleteWhenGivenIdReturnsNull()
        {
            //Arange
            var mockAirCraftTypeRepository = new Mock<IRepository<AirCraftType>>();

            AirCraftType airCraftType = new AirCraftType
            {
                Id = 1,
                Model = "Concord",
                PassengersCapacity = 120,
                CargoCapacity = 300
            };
            mockAirCraftTypeRepository.Setup(a => a.Delete(1)).Callback(() => airCraftType = null);
            var mockUOW = new Mock<IUnitOfWork>();
            mockUOW.Setup(a => a.AirCraftTypes).Returns(mockAirCraftTypeRepository.Object);
            var service = new AirCraftTypeService(mockUOW.Object, new Mapper(new MapperConfiguration((cfg => cfg.AddProfile(new MappingProfile(mockUOW.Object))))));
            //Act
            service.Delete(1);
            //Accept
            Assert.IsNull(airCraftType);
        }
    }
}