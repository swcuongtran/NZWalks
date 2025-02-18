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
    public class WalksController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IWalkRepository _walkRepository;
        public WalksController(IMapper mapper,IWalkRepository walkRepository)
        {
            _mapper = mapper;
            _walkRepository = walkRepository;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddWalkRequestDTO addWalkRequestDTO)
        {
            var walkDomainModel = _mapper.Map<Walk>(addWalkRequestDTO);
            await _walkRepository.CreateAsync(walkDomainModel);
            return Ok(_mapper.Map<WalkDTO>(walkDomainModel));
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var walkDomain = await _walkRepository.GetAllAsync();
            var walkDto = _mapper.Map<List<WalkDTO>>(walkDomain);
            return Ok(walkDto);
        }
    }
}
