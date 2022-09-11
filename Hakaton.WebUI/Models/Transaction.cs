namespace Hakaton.WebUI.Models
{
    public class Transaction
    {
        public int Id { get; set; }

        public string? FromUserId { get; set; }

        public string? ToUserId { get; set; }

        public decimal Income { get; set; }

        public int EnergyAmount { get; set; }

        public DateTime SaleDate { get; set; }
    }
}
