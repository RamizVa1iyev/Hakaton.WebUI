namespace Hakaton.WebUI.Models
{
    public class HomeViewModel
    {
        public List<Panel> Panels { get; set; }

        public Batery Batery { get; set; }

        public int ErrorPanelCount
        {
            get
            {
                return Panels.Where(p=>!p.IsPerfect).Count();    
            }
        }
    }
}
