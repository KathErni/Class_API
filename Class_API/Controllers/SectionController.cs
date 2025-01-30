using AutoMapper;
using Class_API.Model.Contracts;
using Class_API.Model.Entity;
using Class_API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Class_API.Controllers
{
        [ApiController]
        [Route("api/")]
        public class SectionController : ControllerBase
        {
            private readonly IBaseRepository<Section> _sectionRepository;
            private readonly IMapper _mapper;


            public SectionController(IBaseRepository<Section> sectionRepository, IMapper mapper)
            {
                _sectionRepository = sectionRepository;
                _mapper = mapper;
            }

            [HttpGet("sections")]
            public async Task<IActionResult> GetAllSections()
            {
                //Get all the data input by the user
                var sections = await _sectionRepository.GetAll(a => a.Students);
                var allSectionDto = _mapper.Map<List<SectionDTO>>(sections);
                return Ok(allSectionDto);
            }

            [HttpGet("section/{id}")]
            public async Task<IActionResult> GetOneSection(int id)
            {
                //Gets a data input by user using number. If id number is not found it will prompt an error
                var section = await _sectionRepository.Get(id, a => a.Students);
                if (section == null)
                {
                    return NotFound();
                }
                var oneSectionDto = _mapper.Map<SectionDTO>(section);
                return Ok(oneSectionDto);
            }
            [HttpPost("section")]
            public async Task<IActionResult> CreateASection([FromBody] CreateSection createSct)
            {
                //Maps first the section then add. Creates a new section.
                var section = _mapper.Map<Section>(createSct);
                var createdSct = await _sectionRepository.Add(section);
                var sectionDto_created = _mapper.Map<SectionDTO>(createdSct);
                return CreatedAtAction(nameof(GetOneSection), new { id = sectionDto_created.Id }, sectionDto_created);
            }

            [HttpPut("section/{id}")]
            public async Task<IActionResult> UpdateSection(int id, [FromBody] UpdateSection updateSct)
            {
                //Updates a Section. If Id number is not found, it will prompt an error.
                var section = await _sectionRepository.Get(id);
                if (section == null)
                {
                    return NotFound();
                }
            _mapper.Map(updateSct, section);
            var updatedSection = await _sectionRepository.Update(section);
                var sectionDto_updated = _mapper.Map<SectionDTO>(updatedSection);
                return Ok(sectionDto_updated);
            }

            [HttpDelete("section/{id}")]
            public async Task<IActionResult> DeleteSection(int id)
            {
                //Deletes the section. If Id number is not fount, it will prompt an erro message
                var section = await _sectionRepository.Get(id);
                if (section == null)
                {
                    return NotFound();

                }

                var deletedSection = await _sectionRepository.Delete(id);
                var sectionDto_deleted = _mapper.Map<SectionDTO>(deletedSection);
                return Ok(sectionDto_deleted);
            }
        }
    }
