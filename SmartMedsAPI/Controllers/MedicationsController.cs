using Microsoft.AspNetCore.Mvc;
using SmartMedsAPI.Models.Domain;
using SmartMedsAPI.Models.DTOs;
using SmartMedsAPI.Repositories.Interfaces;

namespace SmartMedsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicationsController : ControllerBase
    {
        private readonly IMedicationRepos medicationRepos;
        public MedicationsController(IMedicationRepos medicationRepos)
        {
            this.medicationRepos = medicationRepos;
        }


        [HttpGet]
        public async Task<ActionResult<List<MedicationViewDTO>>> GetAll()
        {
            var medsDomainModel = await medicationRepos.GetAllAsync();

            var medsDTO = new List<MedicationViewDTO>();

            foreach (var med in medsDomainModel)
            {
                var dto = new MedicationViewDTO
                {
                    Id = med.Id,
                    Name = med.Name,
                    Quantity = med.Quantity,
                    CreatedAt = med.CreatedAt
                };
                medsDTO.Add(dto);
            }
            return Ok(medsDTO);
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MedicationCreateDTO dto)
        {
            //mapping
            var entity = new Medication
            {
                Name = dto.Name,
                Quantity = dto.Quantity,
                CreatedAt = DateTime.UtcNow
            };

            //repository call
            var created = await medicationRepos.CreateAsync(entity);

            if (created == null)//avoids Null Reference
            {
                return Conflict($"Medication with name '{dto.Name}' already exists.");
            }

            //mapping it back
            var view = new MedicationViewDTO
            {
                Id = created.Id,
                Name = created.Name,
                Quantity = created.Quantity,
                CreatedAt = created.CreatedAt
            };

            return Created($"/api/medications/{view.Id}", view);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            try
            {
                await medicationRepos.DeleteAsync(id);
                return NoContent();                                     //204 test
            }

            catch (KeyNotFoundException) { return NotFound(); }         //404
        }

    }
}
