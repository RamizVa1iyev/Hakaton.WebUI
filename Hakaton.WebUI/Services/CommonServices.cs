using Hakaton.WebUI.Constants;

namespace Hakaton.WebUI.Services
{
    public class CommonServices
    {
        public static string ShowAlert(AlertTypes type, string message)
        {
            string alertDiv = null;
            switch (type)
            {
                case AlertTypes.Success:
                    alertDiv = "<div style='margin-top:10px' class='alert alert-success alert-dismissable' id='alert'>" + message + "</div>";
                    break;
                case AlertTypes.Danger:
                    alertDiv = "<div style='margin-top:10px' class='alert alert-danger alert-dismissible' id='alert'>" + message + "</div>";
                    break;
                case AlertTypes.Info:
                    alertDiv = "<div style='margin-top:10px' class='alert alert-info alert-dismissable' id='alert'>" + message + "</div>";
                    break;
                case AlertTypes.Warning:
                    alertDiv = "<div style='margin-top:10px' class='alert alert-warning alert-dismissable' id='alert'>" + message + "</div>";
                    break;
            }
            return alertDiv;
        }
    }
}
