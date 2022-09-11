namespace Hakaton.WebUI.Models
{
    public class SellEnergyViewModel
    {
        public MainStorage MainStorage { get; set; }

        public int TotalEnergyAmount { get; set; }

        public int SellAmount { get; set; }

        public decimal Income { get; set; }
    }
}
