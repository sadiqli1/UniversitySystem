using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UniversitySystem.Application.DTOs.Specialization;
using UniversitySystem.Application.Interfaces.Repository;
using UniversitySystem.Domain.Entities;
using System.Linq;
using UniversitySystem.Application.Interfaces;

namespace UniversitySystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecializationsController : ControllerBase
    {
        private readonly IUnitOfWork _unit;
        private readonly IMapper _mapper;

        public SpecializationsController(IUnitOfWork unit, IMapper mapper)
        {
            _unit = unit;
            _mapper = mapper;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            Specialization existed = await _unit.SpecializationRepository.GetByIdAsync(id, "Sector", "Section", "Faculty");
            if (existed == null) return StatusCode(StatusCodes.Status404NotFound);
            SpecializationItemDto dto = _mapper.Map<SpecializationItemDto>(existed);
            return StatusCode(StatusCodes.Status200OK, dto);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<Specialization> specializations = await _unit.SpecializationRepository.GetAllAsync(null ,"Sector", "Section", "Faculty");
            if(specializations == null) return StatusCode(StatusCodes.Status404NotFound);
            List<SpecializationItemDto> dtos = _mapper.Map<List<SpecializationItemDto>>(specializations);
            SpecializationItemDto dto = new SpecializationItemDto();
            return StatusCode(StatusCodes.Status200OK, dtos);
        }
        [HttpPost]
        public async Task<IActionResult> Create(SpecializationPostDto dto)
        {
            List<Specialization> existed = await _unit.SpecializationRepository.GetAllAsync(s => s.Name == dto.Name || s.Code == dto.Code);
            if (existed != null) return BadRequest();
            Specialization specialization = _mapper.Map<Specialization>(dto);
            specialization.CreateAt = DateTime.Now;
            await _unit.SpecializationRepository.AddAsync(specialization);
            return StatusCode(StatusCodes.Status201Created, dto);
        }
    }
}
