using Cv.Business.Class;
using Cv.Models;
using Cv.Repository.Interface;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Cv.Test
{
    public class Test_StatesBusiness
    {
        [Test]
        public void GetAllByCountryId_Ok()
        {
            var list = new List<StateModel>
            {
                new StateModel{ id = 6587 },
                new StateModel{ id = 98123 }
            };
            var mock = new Mock<IStatesRepository>();
            mock.Setup(c => c.GetAllByCountryId(1)).Returns(list);
            var bus = new StatesBusiness(mock.Object);
            var result = bus.GetAllByCountryId(1);
            Assert.AreEqual(true, result.Ok);
            mock.Verify(c => c.GetAllByCountryId(1));
        }
        [Test]
        public void GetAllByCountryId_Empty_False()
        {
            var mock = new Mock<IStatesRepository>();
            mock.Setup(c => c.GetAllByCountryId(1)).Returns(new List<StateModel>());
            var bus = new StatesBusiness(mock.Object);
            var result = bus.GetAllByCountryId(1);
            Assert.AreEqual(false, result.Ok);
            mock.Verify(c => c.GetAllByCountryId(1));
        }
        [Test]
        public void GetAllByCountryId_Null_False()
        {
            List<StateModel> list = null;
            var mock = new Mock<IStatesRepository>();
            mock.Setup(c => c.GetAllByCountryId(1)).Returns(list);
            var bus = new StatesBusiness(mock.Object);
            var result = bus.GetAllByCountryId(1);
            Assert.AreEqual(false, result.Ok);
            mock.Verify(c => c.GetAllByCountryId(1));
        }
        [Test]
        public void GetById_Ok()
        {
            var mock = new Mock<IStatesRepository>();
            mock.Setup(c => c.GetByIdStateId(1)).Returns(new StateModel());
            var bus = new StatesBusiness(mock.Object);
            var result = bus.GetByIdStateId(1);
            Assert.AreEqual(true, result.Ok);
            mock.Verify(c => c.GetByIdStateId(1));
        }
        [Test]
        public void GetById_Null_False()
        {
            StateModel state = null;
            var mock = new Mock<IStatesRepository>();
            mock.Setup(c => c.GetByIdStateId(1)).Returns(state);
            var bus = new StatesBusiness(mock.Object);
            var result = bus.GetByIdStateId(1);
            Assert.AreEqual(false, result.Ok);
            mock.Verify(c => c.GetByIdStateId(1));
        }
    }
}
