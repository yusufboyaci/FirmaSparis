using FirmaSiparis.API.ViewModels;
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
            catch(Exception ex) 
            {
              //  return BadRequest("Sistem de hata meydana geldi");
                return BadRequest(ex.Message);
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
        public IActionResult Add(FirmaVM firmaVM)
        {
            Firma firma = new Firma();
            firma.FirmaAdi = firmaVM.FirmaAdi;
            firma.OnayDurumu = firmaVM.OnayDurumu;
            firma.SiparisIzinBasSaati = TimeSpan.Parse(firmaVM.SiparisIzinBasSaati ?? "10:00");
            firma.SiparisIzinBitisSaati = TimeSpan.Parse(firmaVM.SiparisIzinBitisSaati ?? "22:00");
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
        [HttpDelete("Delete")]
        public IActionResult Delete(Firma firma)
        {
            try
            {
                _firmaRepository.Remove(firma);
                return NoContent();
            }
            catch {
                return BadRequest("Sistem de hata meydana geldi");
            }
        }

    }
}
