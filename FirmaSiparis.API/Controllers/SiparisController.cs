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
        public SiparisController(AppDbContext context)
        {
            _siparisRepository = new SiparisRepository(context);
        }
        [HttpPost("Add")]
        public IActionResult Add(Siparis siparis)
        {
            try
            {
                if (siparis.Firma != null)
                {
                    if (siparis.Firma.OnayDurumu == true)
                    {
                        if (TimeSpan.Compare(siparis.Firma.SiparisIzinBasSaati, TimeSpan.Parse("8:30")) == -1 && TimeSpan.Compare(siparis.Firma.SiparisIzinBitisSaati, TimeSpan.Parse("11:00")) == 1)
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
