using MediatR;
using Microsoft.AspNetCore.Mvc;
using UniversitySystem.Application.DTOs.Point;
using UniversitySystem.Application.Features.Commands.PointListCommand;

namespace UniversitySystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PointListsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PointListsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPut("sdf1")]
        public async Task<IActionResult> SDF1Create(int studentId, int lessonId, PointPostDto dto)
        {
            SDF1CreateCommand command = new SDF1CreateCommand() {StudentId = studentId, LessonId = lessonId, Point = dto.Point};
            int value = await _mediator.Send(command);
            if (value == 0) return NotFound();
            return StatusCode(StatusCodes.Status201Created, value);
        }
        [HttpPut("sdf2")]
        public async Task<IActionResult> SDF2Create(int studentId, int lessonId, PointPostDto dto)
        {
            SDF2CreateCommand command = new SDF2CreateCommand() {StudentId = studentId, LessonId = lessonId, Point = dto.Point };
            int value = await _mediator.Send(command);
            if (value == 0) return NotFound();
            return StatusCode(StatusCodes.Status201Created, value);
        }
        [HttpPut("sdf3")]
        public async Task<IActionResult> SDF3Create(int studentId, int lessonId, PointPostDto dto)
        {
            SDF3CreateCommand command = new SDF3CreateCommand() {StudentId = studentId, LessonId = lessonId, Point = dto.Point };
            int value = await _mediator.Send(command);
            if (value == 0) return NotFound();
            return StatusCode(StatusCodes.Status201Created, value);
        }
        [HttpPut("tsi")]
        public async Task<IActionResult> TSICreate(int studentId, int lessonId, PointPostDto dto)
        {
            TSICreateCommand command = new TSICreateCommand() {StudentId = studentId, LessonId = lessonId, Point = dto.Point };
            int value = await _mediator.Send(command);
            if (value == 0) return NotFound();
            return StatusCode(StatusCodes.Status201Created, value);
        }
        [HttpPut("ssi")]
        public async Task<IActionResult> SSICreate(int studentId, int lessonId, PointPostDto dto)
        {
            SSICreateCommand command = new SSICreateCommand() { StudentId = studentId, LessonId = lessonId, Point = dto.Point };
            int value = await _mediator.Send(command);
            if (value == 0) return NotFound();
            return StatusCode(StatusCodes.Status201Created, value);
        }
        [HttpPut("reexam")]
        public async Task<IActionResult> ReExamCreate(int studentId, int lessonId, PointPostDto dto)
        {
            ReExamCreateCommand command = new ReExamCreateCommand() { StudentId = studentId, LessonId = lessonId, Point = dto.Point };
            int value = await _mediator.Send(command);
            if (value == 0) return NotFound();
            return StatusCode(StatusCodes.Status201Created, value);
        }
        [HttpPut("addtionalexam")]
        public async Task<IActionResult> AdditionalExamCreate(int studentId, int lessonId, PointPostDto dto)
        {
            AdditionalExamCreateCommand command = new AdditionalExamCreateCommand() { StudentId = studentId, LessonId = lessonId, Point = dto.Point };
            int value = await _mediator.Send(command);
            if (value == 0) return NotFound();
            return StatusCode(StatusCodes.Status201Created, value);
        }
    }
}