using Hakaton.WebUI.Models;
using Hakaton.WebUI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace Hakaton.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserService _userService;
        public HomeController(ILogger<HomeController> logger, UserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [Authorize]
        public IActionResult Index()
        {
            HomeViewModel homeViewModel = new HomeViewModel();
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            homeViewModel.Batery = _userService.GetUserBatery(userId);
            homeViewModel.Panels = _userService.GetUserPanels(userId);

            return View(homeViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Authorize]
        public IActionResult SellEnergy()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            SellEnergyViewModel model = new SellEnergyViewModel();
            model.MainStorage = _userService.GetMainStorage();
            var batery = _userService.GetUserBatery(userId);
            model.TotalEnergyAmount = Convert.ToInt32((decimal)batery.BateryCapacity * batery.BateryStorage / 100M);
            return View(model);
        }

        [Authorize]
        [HttpPost]
        public IActionResult SellEnergy(SellEnergyViewModel model)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            model.MainStorage = _userService.GetMainStorage();
            _userService.SellAmount(userId,model.SellAmount);
            return RedirectToAction("Index");
        }

        [Authorize]
        public IActionResult BuyEnergy()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            BuyEnergyViewModel model = new BuyEnergyViewModel();
            model.StorageTotalAmount = Convert.ToInt32(_userService.GetMainStorage().StorageAmount);
            var batery = _userService.GetUserBatery(userId);
            model.MaxEnergyAmount = batery.BateryCapacity;
            model.TotalEnergyAmount= Convert.ToInt32((decimal)batery.BateryCapacity * batery.BateryStorage / 100M);
            return View(model);
        }


        [Authorize]
        [HttpPost]
        public IActionResult BuyEnergy(BuyEnergyViewModel model)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _userService.BuyAmount(userId, model.BuyAmount);
            return RedirectToAction("Index");
        }

        [Authorize]
        public IActionResult GetTransactions()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            GetTransactionsViewModel model = new GetTransactionsViewModel();
            model.BuyTransactions = _userService.GetBuyTransactions(userId);
            model.SellTransactions = _userService.GetSellTransactions(userId);
            model.TotalIncome= (model.SellTransactions.Sum(t => t.Income)*0.9M) - model.BuyTransactions.Sum(t => t.Income);
            return View(model);
        }
    }
}