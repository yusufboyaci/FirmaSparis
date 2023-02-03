using FirmaSiparis.DATAACCESS.Context;
using FirmaSiparis.DATAACCESS.Repositories.Concrete;
using FirmaSiparis.ENTITIES.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirmaSiparis.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SiparisController : ControllerBase
    {
        SiparisRepository _siparisRepository;
        FirmaRepository _firmaRepository;
        public SiparisController(AppDbContext context)
        {
            _siparisRepository = new SiparisRepository(context);
            _firmaRepository= new FirmaRepository(context);
        }
        [HttpPost("Add")]
        public IActionResult Add(Siparis siparis)
        {
            try
            {
                if (siparis.FirmaId != Guid.Empty)
                {
                    Firma firma = _firmaRepository.GetById(siparis.FirmaId);
                    if (firma.OnayDurumu == true)
                    {
                        if (TimeSpan.Compare(TimeSpan.Parse("8:30"), firma.SiparisIzinBasSaati) == -1 && TimeSpan.Compare(TimeSpan.Parse("11:00"), firma.SiparisIzinBitisSaati) == 1)
                        {
                            _siparisRepository.Add(siparis);
                            return NoContent();
                        }
                        return Ok("Firma şuan sipariş almıyor");
                    }
                    else
                    {
                        return Ok("Firma Onaylı Değil");
                    }
                }
                return Ok("Böyle bir sipariş bulunamadı.");
            }
            catch
            {
                return BadRequest("Sistem de hata meydana geldi");
            }
        }
    }
}
