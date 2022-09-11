using Hakaton.WebUI.Data;
using Hakaton.WebUI.Models;
using Microsoft.EntityFrameworkCore;

namespace Hakaton.WebUI.Services
{
    public class UserService
    {
        private readonly ApplicationDbContext _context;
        public UserService( ApplicationDbContext context)
        {
            _context = context;
        }
        public List<Panel> GetUserPanels(string userId)
        {

            var list = _context.Panels.Where(x => x.UserId == userId).ToList();
            return list;
        }

        public Batery GetUserBatery(string userId)
        {
            var data = _context.Bateries.FirstOrDefault(b => b.UserId == userId);
            return data;
        }

        public MainStorage GetMainStorage() 
        {
            return _context.MainStorages.FirstOrDefault();
        }

        public void SellAmount(string userId,decimal amount)
        {
            decimal income = amount * 0.07M;
            var batery = GetUserBatery(userId);
            decimal bateryCapacity = batery.BateryCapacity;
            decimal percentage = (amount/bateryCapacity)*100M;
            _context.Bateries.FirstOrDefault(b => b.UserId == userId).BateryStorage -= Convert.ToInt32(percentage);

            _context.MainStorages.FirstOrDefault().StorageAmount+= amount;
            _context.SaveChanges();

            this.AddTransaction(userId, true, Convert.ToInt32(amount), income);
        }

        public void BuyAmount(string userId,decimal amount)
        {
            decimal income = (amount * 0.07M);
            _context.MainStorages.FirstOrDefault().StorageAmount -= amount;
            var batery = GetUserBatery(userId);
            decimal bateryCapacity = batery.BateryCapacity;
            decimal percentage = (amount / bateryCapacity) * 100M;
            _context.Bateries.FirstOrDefault(b => b.UserId == userId).BateryStorage += Convert.ToInt32(percentage);

            _context.SaveChanges();

            this.AddTransaction(userId, false, Convert.ToInt32(amount), income);
        }

        public void AddTransaction(string userId,bool isSell,int amount,decimal income)
        {
            Transaction transaction = new Transaction() { EnergyAmount=amount,SaleDate=DateTime.Now,Income=income};
            if (isSell)
            {
                transaction.FromUserId = userId;
            }
            else
            {
                transaction.ToUserId = userId;
            }

            _context.Transactions.Add(transaction);
            _context.SaveChanges();
        }

        public List<Transaction> GetSellTransactions(string userId)
        {
            return _context.Transactions.Where(t => t.FromUserId == userId).ToList();
        }

        public List<Transaction> GetBuyTransactions(string userId)
        {
            return _context.Transactions.Where(t => t.ToUserId == userId).ToList();
        }
    }
}
