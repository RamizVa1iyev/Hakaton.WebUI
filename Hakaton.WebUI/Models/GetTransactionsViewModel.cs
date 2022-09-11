namespace Hakaton.WebUI.Models
{
    public class GetTransactionsViewModel
    {
        public List<Transaction> BuyTransactions { get; set; }
        public List<Transaction> SellTransactions { get; set; }

        public decimal TotalIncome
        {
            get; set;
        }
    }
}
