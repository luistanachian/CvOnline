using Cv.Business.Class;
using Cv.Models;
using Cv.Repository.Interface;
using MongoDB.Driver;
using Moq;
using NUnit.Framework;

namespace Cv.Test
{
    public class TestCandidateModel
    {
        [Test]
        public void Delete()
        {
            string candidateId = "1";
            var mockCandidate = new Mock<ICandidatesRepository>();
            mockCandidate.Setup(c => c.Delete(It.IsAny<string>())).Returns(true);

            var bus = new CandidatesBusiness(mockCandidate.Object);
            var deleted = bus.Delete(candidateId);

            Assert.AreEqual(deleted, true);
            mockCandidate.Verify(c => c.Delete(candidateId));
        }
    }
}