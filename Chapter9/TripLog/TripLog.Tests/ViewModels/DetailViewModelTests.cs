using System;
using Moq;
using NUnit.Framework;
using TripLog.Exceptions;
using TripLog.Models;
using TripLog.Services;
using TripLog.ViewModels;

namespace TripLog.Tests.ViewModels
{
    [TestFixture]
    public class DetailViewModelTests
    {
        DetailViewModel _vm;

        [SetUp]
        public void Setup()
        {
            var navMock = new Mock<INavService>().Object;
            var analyticsMock = new Mock<IAnalyticsService>().Object;

            _vm = new DetailViewModel(navMock, analyticsMock);
        }

        [Test]
        public void Init_ParameterProvided_EntryIsSet()
        {
            // Arrange
            var mockEntry = new Mock<TripLogEntry>().Object;
            _vm.Entry = null;

            // Act
            _vm.Init(mockEntry);

            // Assert
            Assert.IsNotNull(_vm.Entry, "Entry is null after being initialized with a valid TripLogEntry object");
        }

        [Test]
        public void Init_ParameterNotProvided_ThrowsEntryNotProvidedException()
        {
            // Assert
            Assert.Throws(typeof(EntryNotProvidedException), () => _vm.Init());
        }
    }
}
