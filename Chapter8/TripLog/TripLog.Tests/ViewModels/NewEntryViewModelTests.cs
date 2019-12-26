using System;
using NUnit.Framework;
using Moq;
using TripLog.Models;
using TripLog.Services;
using TripLog.ViewModels;

namespace TripLog.Tests.ViewModels
{
    [TestFixture]
    public class NewEntryViewModelTests
    {
        NewEntryViewModel _vm;
        Mock<INavService> _navMock;
        Mock<ITripLogDataService> _dataMock;
        Mock<ILocationService> _locMock;

        [SetUp]
        public void Setup()
        {
            _navMock = new Mock<INavService>();
            _dataMock = new Mock<ITripLogDataService>();
            _locMock = new Mock<ILocationService>();

            _navMock.Setup(x => x.GoBack())
                .Verifiable();

            _dataMock.Setup(x => x.AddEntryAsync(It.Is<TripLogEntry>(entry => entry.Title == "Mock Entry")))
                .Verifiable();

            _locMock.Setup(x => x.GetGeoCoordinatesAsync())
                .ReturnsAsync(new GeoCoords
                {
                    Latitude = 123,
                    Longitude = 321
                });

            _vm = new NewEntryViewModel(_navMock.Object, _locMock.Object, _dataMock.Object);
        }

        [Test]
        public void Init_EntryIsSetWithGeoCoordinates()
        {
            // Arrange
            _vm.Latitude = 0.0;
            _vm.Longitude = 0.0;

            // Act
            _vm.Init();

            // Assert
            Assert.AreEqual(123, _vm.Latitude);
            Assert.AreEqual(321, _vm.Longitude);
        }

        [Test]
        public void SaveCommand_TitleIsEmpty_CanExecuteReturnsFalse()
        {
            // Arrange
            _vm.Title = "";

            // Act
            var canSave = _vm.SaveCommand.CanExecute(null);

            // Assert
            Assert.IsFalse(canSave);
        }

        [Test]
        public void SaveCommand_AddsEntryToTripLogBackend()
        {
            // Arrange
            _vm.Title = "Mock Entry";

            // Act
            _vm.SaveCommand.Execute(null);

            // Assert
            _dataMock.Verify(x => x.AddEntryAsync(It.Is<TripLogEntry>(entry => entry.Title == "Mock Entry")), Times.Once);
        }

        [Test]
        public void SaveCommand_NavigatesBack()
        {
            // Arrange
            _vm.Title = "Mock Entry";

            // Act
            _vm.SaveCommand.Execute(null);

            // Assert
            _navMock.Verify(x => x.GoBack(), Times.Once);
        }
    }
}
