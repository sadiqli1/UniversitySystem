using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniversitySystem.Application.DTOs.Sector;
using UniversitySystem.Application.Interfaces;
using UniversitySystem.Application.Interfaces.Repository;
using UniversitySystem.Domain.Entities;

namespace UniversitySystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SectorsController : ControllerBase
    {
        private readonly IUnitOfWork _unit;
        private readonly IMapper _mapper;

        public SectorsController(IUnitOfWork unit, IMapper mapper)
        {
            _unit = unit;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<Sector> sectors = await _unit.SectorRepository.GetAllAsync(null);
            List<SectorGetItemDto> dtos = _mapper.Map<List<SectorGetItemDto>>(sectors);
            return Ok(sectors);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            Sector sector = await _unit.SectorRepository.GetByIdAsync(id);
            if(sector == null) return NotFound();
            SectorGetItemDto dto = _mapper.Map<SectorGetItemDto>(sector);
            return Ok(dto);
        }
        [HttpPost]
        public async Task<IActionResult> Create(SectorPostDto dto)
        {
            List<Sector> sectors = await _unit.SectorRepository.GetAllAsync(null);
            foreach (var item in sectors)
            {
                if (item.Name == dto.Name) return StatusCode(StatusCodes.Status400BadRequest);
            }
            Sector sector = _mapper.Map<Sector>(dto);
            await _unit.SectorRepository.AddAsync(sector);
            return StatusCode(StatusCodes.Status201Created, dto);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, SectorPostDto dto)
        {
            Sector existed = await _unit.SectorRepository.GetByIdAsync(id);
            if (existed == null) return NotFound();
            List<Sector> sectors = await _unit.SectorRepository.GetAllAsync(null);
            foreach (var item in sectors)
            {
                if (item.Name == dto.Name && existed.Name != dto.Name) return StatusCode(StatusCodes.Status400BadRequest);
            }
            await _unit.SectorRepository.UpdateAsync(existed);
            existed.Name = dto.Name;
            await _unit.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK, dto);
        }
        [HttpDelete]    
        public async Task<IActionResult> Delete(int id)
        {
            Sector existed = await _unit.SectorRepository.GetByIdAsync(id);
            if (existed == null) return StatusCode(StatusCodes.Status404NotFound); ;
            await _unit.SectorRepository.DeleteAsync(existed);
            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}