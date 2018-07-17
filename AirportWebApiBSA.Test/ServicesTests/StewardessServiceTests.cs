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
    public class StewardessServiceTests
    {
        [Test]
        public void GetWhenGivenIdReturnsItemDTO()
        {
            //Arange
            var mockStewardessRepository = new Mock<IRepository<Stewardess>>();
            mockStewardessRepository.Setup(a => a.Get(1))
                .Returns(new Stewardess
                {
                    Name = "John",
                    Surname = "Galt",
                    Birthday = new DateTime(1985, 5, 15)
                });

            var mockUOW = new Mock<IUnitOfWork>();
            mockUOW.Setup(a => a.Stewardesses).Returns(mockStewardessRepository.Object);
            var service = new StewardessService(mockUOW.Object, new Mapper(new MapperConfiguration((cfg => cfg.AddProfile(new MappingProfile(mockUOW.Object))))));
            //Act
            var Result = service.Get(1);
            //Accept
            Assert.IsTrue(CustomAsserts.AreEqualByJson(Result, new StewardessDTO
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
            var mockStewardessRepository = new Mock<IRepository<Stewardess>>();
            Stewardess Stewardess = new Stewardess();
            mockStewardessRepository.Setup(a => a.Create(It.IsNotNull<Stewardess>())).Callback((Stewardess a) => Stewardess = a);
            var mockUOW = new Mock<IUnitOfWork>();
            mockUOW.Setup(a => a.Stewardesses).Returns(mockStewardessRepository.Object);
            var service = new StewardessService(mockUOW.Object, new Mapper(new MapperConfiguration((cfg => cfg.AddProfile(new MappingProfile(mockUOW.Object))))));
            //Act
            service.Create(new StewardessDTO
            {
                Name = "John",
                Surname = "Galt",
                Birthday = new DateTime(1985, 5, 15)
            });
            //Accept
            Assert.IsTrue(CustomAsserts.AreEqualByJson(Stewardess, new Stewardess
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
            var mockStewardessRepository = new Mock<IRepository<Stewardess>>();
            Stewardess Stewardess = new Stewardess
            {
                Id = 1,
                Name = "John",
                Surname = "Galt",
                Birthday = new DateTime(1985, 5, 15)
            };
            mockStewardessRepository.Setup(a => a.Update(It.IsNotNull<Stewardess>())).Callback((Stewardess a) => Stewardess = a);
            var mockUOW = new Mock<IUnitOfWork>();
            mockUOW.Setup(a => a.Stewardesses).Returns(mockStewardessRepository.Object);
            var service = new StewardessService(mockUOW.Object, new Mapper(new MapperConfiguration((cfg => cfg.AddProfile(new MappingProfile(mockUOW.Object))))));
            //Act
            service.Update(1, new StewardessDTO
            {
                Id = 1,
                Name = "John",
                Surname = "Galt",
                Birthday = new DateTime(1989, 5, 15)
            });
            //Accept
            Assert.IsTrue(CustomAsserts.AreEqualByJson(Stewardess, new Stewardess
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
            var mockStewardessRepository = new Mock<IRepository<Stewardess>>();

            Stewardess Stewardess = new Stewardess
            {
                Name = "John",
                Surname = "Galt",
                Birthday = new DateTime(1985, 5, 15)
            };
            mockStewardessRepository.Setup(a => a.Delete(1)).Callback(() => Stewardess = null);
            var mockUOW = new Mock<IUnitOfWork>();
            mockUOW.Setup(a => a.Stewardesses).Returns(mockStewardessRepository.Object);
            var service = new StewardessService(mockUOW.Object, new Mapper(new MapperConfiguration((cfg => cfg.AddProfile(new MappingProfile(mockUOW.Object))))));
            //Act
            service.Delete(1);
            //Accept
            Assert.IsNull(Stewardess);
        }
    }
}