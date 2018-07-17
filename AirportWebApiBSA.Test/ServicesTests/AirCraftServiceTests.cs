using AirportWebApiBSA.DAL.Models;
using NUnit.Framework;
using System;
using Moq;
using AirportWebApiBSA.DAL.Repositories;
using AutoMapper;
using AirportWebApiBSA.Shared.DTOs;
using AirportWebApiBSA.DAL.Interfaces;
using AirportWebApiBSA.BLL.Services;
using AirportWebApiBSA.BLL;
using AirportWebApiBSA.Test;

namespace AirportWebApiBSA.Test.ServicesTests
{
    [TestFixture]
    public class AirCraftServiceTests
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
            //Act
            var Result = service.Get(1);
            //Accept
            Assert.IsTrue(CustomAsserts.AreEqualByJson(Result, new AirCraftDTO
            {
                Id = 1,
                Name = "DF-23",
                AirCraftTypeId = 1,
                Manufactured = new DateTime(1990, 12, 01),
                Age = mockAirCraftRepository.Object.Get(1).Age
            }));
        }
        [Test]
        public void CreateWhenGivenItemDTOReturnsItem()
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
            //Act
            service.Create(new AirCraftDTO
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
                AirCraftType  = mockAirCraftTypeRepository.Object.Get(1),
                Manufactured = new DateTime(1990, 12, 01),
                Age = airCraft.Age
            }));
        }
        [Test]
        public void UpdateWhenGivenIdAndItemDTOReturnsItem()
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
                AirCraftTypeId = 1,
                Name = "DF-23",
                AirCraftType = mockAirCraftTypeRepository.Object.Get(1),
                Manufactured = new DateTime(1990, 12, 01),
                Age = DateTime.Now - new DateTime(1990, 12, 01)
            };
            mockAirCraftRepository.Setup(a => a.Update(It.IsNotNull<AirCraft>())).Callback((AirCraft a) => airCraft = a);
            var mockUOW = new Mock<IUnitOfWork>();
            mockUOW.Setup(a => a.AirCrafts).Returns(mockAirCraftRepository.Object);
            mockUOW.Setup(a => a.AirCraftTypes).Returns(mockAirCraftTypeRepository.Object);
            var service = new AirCraftService(mockUOW.Object, new Mapper(new MapperConfiguration((cfg => cfg.AddProfile(new MappingProfile(mockUOW.Object))))));
            //Act
            service.Update(1, new AirCraftDTO
            {
                Id = 1,
                Name = "DF-24",
                AirCraftTypeId = 1,
                Manufactured = new DateTime(1991, 12, 01),
                Age = DateTime.Now - new DateTime(1990, 12, 01)
            });
            //Accept
            Assert.IsTrue(CustomAsserts.AreEqualByJson(airCraft, new AirCraft
            {
                Id = 1,
                AirCraftTypeId = 1,
                Name = "DF-24",
                AirCraftType = mockAirCraftTypeRepository.Object.Get(1),
                Manufactured = new DateTime(1991, 12, 01),
                Age = airCraft.Age
            }));
        }
        [Test]
        public void DeleteWhenGivenIdReturnsNull()
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
                AirCraftTypeId = 1,
                Name = "DF-23",
                AirCraftType = mockAirCraftTypeRepository.Object.Get(1),
                Manufactured = new DateTime(1990, 12, 01),
                Age = DateTime.Now - new DateTime(1990, 12, 01)
            };
            mockAirCraftRepository.Setup(a => a.Delete(1)).Callback(() => airCraft = null);
            var mockUOW = new Mock<IUnitOfWork>();
            mockUOW.Setup(a => a.AirCrafts).Returns(mockAirCraftRepository.Object);
            mockUOW.Setup(a => a.AirCraftTypes).Returns(mockAirCraftTypeRepository.Object);
            var service = new AirCraftService(mockUOW.Object, new Mapper(new MapperConfiguration((cfg => cfg.AddProfile(new MappingProfile(mockUOW.Object))))));
            //Act
            service.Delete(1);
            //Accept
            Assert.IsNull(airCraft);
        }
    }
}
