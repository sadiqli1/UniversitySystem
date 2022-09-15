using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniversitySystem.Application.DTOs.Section;
using UniversitySystem.Application.Interfaces;
using UniversitySystem.Application.Interfaces.Repository;
using UniversitySystem.Domain.Entities;

namespace UniversitySystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SectionsController : ControllerBase
    {
        private readonly IUnitOfWork _unit;
        private readonly IMapper _mapper;

        public SectionsController(IUnitOfWork unit, IMapper mapper)
        {
            _unit = unit;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<Section> sections = await _unit.SectionRepository.GetAllAsync(null);
            List<SectionItemDto> dtos = _mapper.Map<List<SectionItemDto>>(sections);
            return Ok(dtos);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            Section section = await _unit.SectionRepository.GetByIdAsync(id);
            if (section == null) return NotFound();
            SectionItemDto dto = _mapper.Map<SectionItemDto>(section);
            return Ok(dto);
        }
        [HttpPost]
        public async Task<IActionResult> Create(SectionPostDto dto)
        {
            List<Section> sections = await _unit.SectionRepository.GetAllAsync(null);
            foreach (var item in sections)
            {
                if (item.Name == dto.Name || item.Code == dto.Code) return StatusCode(StatusCodes.Status400BadRequest);
            }
            Section section = _mapper.Map<Section>(dto);
            await _unit.SectionRepository.AddAsync(section);
            return StatusCode(StatusCodes.Status201Created, dto);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, SectionPostDto dto)
        {
            Section existed = await _unit.SectionRepository.GetByIdAsync(id);
            if (existed == null) return NotFound();
            List<Section> sections = await _unit.SectionRepository.GetAllAsync(null);
            foreach (var item in sections)
            {
                if (item.Name == dto.Name && existed.Name != dto.Name || item.Code == dto.Code && existed.Code != dto.Code) return StatusCode(StatusCodes.Status400BadRequest);
            }
            await _unit.SectionRepository.UpdateAsync(existed);
            existed.Name = dto.Name;
            existed.Code = dto.Code;
            await _unit.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK, dto);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            Section existed = await _unit.SectionRepository.GetByIdAsync(id);
            if (existed == null) return StatusCode(StatusCodes.Status404NotFound); ;
            await _unit.SectionRepository.DeleteAsync(existed);
            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}