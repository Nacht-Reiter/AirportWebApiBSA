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
    public class PilotServiceTests
    {
        [Test]
        public void GetWhenGivenIdReturnsItemDTO()
        {
            //Arange
            var mockPilotRepository = new Mock<IRepository<Pilot>>();
            mockPilotRepository.Setup(a => a.Get(1))
                .Returns(new Pilot
                {
                    Name = "John",
                    Surname = "Galt",
                    Birthday = new DateTime(1985, 5, 15)
                });

            var mockUOW = new Mock<IUnitOfWork>();
            mockUOW.Setup(a => a.Pilots).Returns(mockPilotRepository.Object);
            var service = new PilotService(mockUOW.Object, new Mapper(new MapperConfiguration((cfg => cfg.AddProfile(new MappingProfile(mockUOW.Object))))));
            //Act
            var Result = service.Get(1);
            //Accept
            Assert.IsTrue(CustomAsserts.AreEqualByJson(Result, new PilotDTO
            {
                Name = "John",
                Surname = "Galt",
                Birthday = new DateTime(1985, 5, 15)
            }));
        }
        [Test]
        public void CreateWhenGivenItemDTOReturnsItem()
        {
            //Arange
            var mockPilotRepository = new Mock<IRepository<Pilot>>();
            Pilot Pilot = new Pilot();
            mockPilotRepository.Setup(a => a.Create(It.IsNotNull<Pilot>())).Callback((Pilot a) => Pilot = a);
            var mockUOW = new Mock<IUnitOfWork>();
            mockUOW.Setup(a => a.Pilots).Returns(mockPilotRepository.Object);
            var service = new PilotService(mockUOW.Object, new Mapper(new MapperConfiguration((cfg => cfg.AddProfile(new MappingProfile(mockUOW.Object))))));
            //Act
            service.Create(new PilotDTO
            {
                Name = "John",
                Surname = "Galt",
                Birthday = new DateTime(1985, 5, 15)
            });
            //Accept
            Assert.IsTrue(CustomAsserts.AreEqualByJson(Pilot, new Pilot
            {
                Name = "John",
                Surname = "Galt",
                Birthday = new DateTime(1985, 5, 15)
            }));
        }
        [Test]
        public void UpdateWhenGivenIdAndItemDTOReturnsItem()
        {
            //Arange
            var mockPilotRepository = new Mock<IRepository<Pilot>>();
            Pilot Pilot = new Pilot
            {
                Id = 1,
                Name = "John",
                Surname = "Galt",
                Birthday = new DateTime(1985, 5, 15)
            };
            mockPilotRepository.Setup(a => a.Update(It.IsNotNull<Pilot>())).Callback((Pilot a) => Pilot = a);
            var mockUOW = new Mock<IUnitOfWork>();
            mockUOW.Setup(a => a.Pilots).Returns(mockPilotRepository.Object);
            var service = new PilotService(mockUOW.Object, new Mapper(new MapperConfiguration((cfg => cfg.AddProfile(new MappingProfile(mockUOW.Object))))));
            //Act
            service.Update(1, new PilotDTO
            {
                Id = 1,
                Name = "John",
                Surname = "Galt",
                Birthday = new DateTime(1989, 5, 15)
            });
            //Accept
            Assert.IsTrue(CustomAsserts.AreEqualByJson(Pilot, new Pilot
            {
                Id = 1,
                Name = "John",
                Surname = "Galt",
                Birthday = new DateTime(1989, 5, 15)
            }));
        }

        [Test]
        public void DeleteWhenGivenIdReturnsNull()
        {
            //Arange
            var mockPilotRepository = new Mock<IRepository<Pilot>>();

            Pilot Pilot = new Pilot
            {
                Name = "John",
                Surname = "Galt",
                Birthday = new DateTime(1985, 5, 15)
            };
            mockPilotRepository.Setup(a => a.Delete(1)).Callback(() => Pilot = null);
            var mockUOW = new Mock<IUnitOfWork>();
            mockUOW.Setup(a => a.Pilots).Returns(mockPilotRepository.Object);
            var service = new PilotService(mockUOW.Object, new Mapper(new MapperConfiguration((cfg => cfg.AddProfile(new MappingProfile(mockUOW.Object))))));
            //Act
            service.Delete(1);
            //Accept
            Assert.IsNull(Pilot);
        }
    }
}