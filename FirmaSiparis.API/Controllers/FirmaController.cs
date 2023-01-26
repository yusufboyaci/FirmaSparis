using FirmaSiparis.DATAACCESS.Context;
using FirmaSiparis.DATAACCESS.Repositories.Concrete;
using FirmaSiparis.ENTITIES.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirmaSiparis.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FirmaController : ControllerBase
    {
        FirmaRepository _firmaRepository;
        public FirmaController(AppDbContext context)
        {
            _firmaRepository= new FirmaRepository(context);
        }
        [HttpGet("List")]
        public IActionResult List()
        {
            try
            {
                List<Firma> firmalar = _firmaRepository.GetActives();
                return Ok(firmalar);
            }
            catch 
            {
                return BadRequest("Sistem de hata meydana geldi");
            }
        }
        [HttpGet("Get")]
        public IActionResult Get(Guid id)
        {
            try
            {
                return Ok(_firmaRepository.GetById(id));
            }
            catch 
            {
                return BadRequest("Sistem de hata meydana geldi");
            }
        }
        [HttpPost("Add")]
        public IActionResult Add(Firma firma)
        {
            try
            {
                _firmaRepository.Add(firma);
                return NoContent();
            }
            catch {
                return BadRequest("Sistem de hata meydana geldi");
            }
        }
        [HttpPut("Update")]
        public IActionResult Update(Firma firma)
        {
            try
            {
                _firmaRepository.Update(firma);
                _firmaRepository.Activate(firma.Id);
                return NoContent();
            }
            catch {
                return BadRequest("Sistem de hata meydana geldi");
            }
        }
        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _firmaRepository.Remove(id);
                return NoContent();
            }
            catch {
                return BadRequest("Sistem de hata meydana geldi");
            }
        }

    }
}
