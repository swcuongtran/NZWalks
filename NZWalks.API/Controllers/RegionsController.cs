using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTOs;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly IRegionRepository _regionRepository;
        private readonly IMapper _mapper;
        public RegionsController(IRegionRepository regionRepository, IMapper mapper)
        {
            _regionRepository = regionRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var regionsDomain = await _regionRepository.GetAllAsync();
            var regionsDTO = _mapper.Map<List<RegionDTO>>(regionsDomain);
            return Ok(regionsDTO);
        }
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var regionDomain = await _regionRepository.GetById(id);
            var regionsDto = _mapper.Map<RegionDTO>(regionDomain);
            return Ok(regionsDto);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddRegionRequestDTO addRegionRequestDTO)
        {
            var regionDomainModel = _mapper.Map<Region>(addRegionRequestDTO);
            regionDomainModel = await _regionRepository.CreateAsync(regionDomainModel);
            var regionsDTO = _mapper.Map<RegionDTO>(regionDomainModel);
            return CreatedAtAction(nameof(GetById), new { id = regionsDTO.Id }, regionsDTO);
        }
        [HttpPut("{Id:guid}")]
        public async Task<IActionResult> Put([FromRoute] Guid Id, [FromBody] UpdateRegionRequestDTO updateRegionRequestDTO)
        {
            var regionDomain = _mapper.Map<Region>(updateRegionRequestDTO);
            regionDomain = await _regionRepository.UpdateAsync(Id, regionDomain);
            if (regionDomain == null)
            {
                return NotFound();
            }
            var regionDto = _mapper.Map<RegionDTO>(regionDomain);
            return Ok(regionDto);
        }
        [HttpDelete("{Id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid Id)
        {
            var regionDomain = await _regionRepository.DeleteAsync(Id);
            if (regionDomain == null)
            {
                return NotFound();
            }
            var regionDto = _mapper.Map<RegionDTO>(regionDomain);
            return Ok(regionDto);
        }
    }
}
