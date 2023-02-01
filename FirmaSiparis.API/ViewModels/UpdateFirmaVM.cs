namespace FirmaSiparis.API.ViewModels
{
    public class UpdateFirmaVM
    {
        public Guid Id { get; set; }
        public string? FirmaAdi { get; set; }
        public bool OnayDurumu { get; set; }
        public string? SiparisIzinBasSaati { get; set; }
        public string? SiparisIzinBitisSaati { get; set; }
    }
}
