using System.ComponentModel.DataAnnotations.Schema;

namespace Hakaton.WebUI.Models
{
    public class Panel
    {
        public int Id { get; set; }
        public string Order { get; set; }

        public bool IsPerfect { get; set; }

        public string UserId { get; set; }

        [NotMapped]
        public string CardBodyClass
        {
            get
            {
                if (this.IsPerfect)
                    return "card-body text-success";
                return "card-body text-danger";
            }
        }

        [NotMapped]
        public string CardBorderClass
        {
            get
            {
                if (this.IsPerfect)
                    return "card border-success mb-3";
                return "card border-danger mb-3";
            }
        }
    }
}
