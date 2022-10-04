using System.Threading.Tasks;
using MediatR;
using NUnit.Framework;
using UniversitySystem.Application.DTOs.Sector;
using UniversitySystem.Application.Features.Queries.SectorQueries;
using Moq;
using UniversitySystem.WebApi.Controllers;
using System.Threading;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bogus;
using UniversitySystem.Application.Features.Commands.SectorCommands;

namespace UniversitySystem.UnitTest.Controllers
{
    public class SectorsControllerUnitTest
    {
        private readonly Mock<IMediator> _mockMediatr;
        private readonly SectorsController _sut;
        private readonly List<SectorGetItemDto> _listResponse;
        private readonly SectorGetItemDto _response;
        public SectorsControllerUnitTest()
        {
            _mockMediatr = new Mock<IMediator>();
            _sut = new SectorsController(_mockMediatr.Object);
            _listResponse = new Faker<SectorGetItemDto>()
                .RuleFor(x => x.Id, y => y.Random.Int())
                .RuleFor(x => x.Name, x => x.Lorem.Letter(20))
                .GenerateBetween(1, 10);
            _response = new Faker<SectorGetItemDto>()
                .RuleFor(x => x.Id, y => y.Random.Int())
                .RuleFor(x => x.Name, x => x.Lorem.Letter(20))
                .Generate();
        }
        [Test]
        public async Task GetAll_IfNotEmpty_ReturnsListOfSectorGetItemDto()
        {
            // Arrange
            _mockMediatr.Setup(x => x.Send(It.IsAny<SectorGetAllQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(_listResponse);

            // Action

            IActionResult result = await _sut.GetAll();

            // Assert

            Assert.AreNotEqual(result, null);
            //Assert.IsFalse(String.IsNullOrEmpty(result.ToString()));
        }
        [Test]
        public async Task GetById_IfNotEmpty_ReturnsSectorGetItemDto()
        {
            // Arrange
            _mockMediatr.Setup(x => x.Send(It.IsAny<SectorGetQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(_response);

            // Action

            IActionResult result = await _sut.GetById(It.IsAny<int>());

            // Assert

            Assert.AreNotEqual(result, null);
        }
        [Test]
        public async Task Create_IfNotNull_ReturnsIntTypeValue()
        {
            // Arrange

            _mockMediatr.Setup(x => x.Send(It.IsAny<SectorCreateCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(new int());

            // Action

            SectorPostDto dto = new SectorPostDto(){ Name = "aa"};

            IActionResult result = await _sut.Create(dto);

            // Assert

            Assert.AreNotEqual(result, null);
        }
        [Test]
        public async Task Update_IfNotNull_ReturnsIntTypeValue()
        {
            // Arrange

            _mockMediatr.Setup(x => x.Send(It.IsAny<SectorUpdateCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(new int());

            // Action

            SectorPostDto dto = new SectorPostDto() { Name = "aa" };

            IActionResult result = await _sut.Update(It.IsAny<int>(), dto);

            // Assert

            Assert.AreNotEqual(result, null);
        }
        [Test]
        public async Task Delete_IfNotNull_ReturnsIntTypeValue()
        {
            // Arrange

            _mockMediatr.Setup(x => x.Send(It.IsAny<SectorDeleteCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(new int());

            // Action

            IActionResult result = await _sut.Delete(It.IsAny<int>());

            // Assert

            Assert.AreNotEqual(result, null);
        }
    }
}