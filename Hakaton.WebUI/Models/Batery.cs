using System.ComponentModel.DataAnnotations.Schema;

namespace Hakaton.WebUI.Models
{
    public class Batery
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public decimal BateryStorage { get; set; }

        public int BateryCapacity { get; set; }

        [NotMapped]
        public string BateryStoragePercent
        {
            get
            {
                return this.BateryStorage.ToString("00") + "%";
            }
        }

        [NotMapped]
        public string BateryStorageClass
        {
            get
            {
                string result = "battery-level";
                if (this.BateryStorage <= 20 && this.BateryStorage >= 10)
                    result += " warn";
                else if (this.BateryStorage < 10)
                    result += " alert";
                return result;
            }
        }

        [NotMapped]
        public string AverageFullTime
        {
            get
            {
                var result = (this.BateryCapacity * (decimal)(100 - this.BateryStorage) / (decimal)100) / 5M;

                int hour = Convert.ToInt32(result);


                int minute = Convert.ToInt32(60*(result - hour));

                return hour + " saat "+ minute+" dəqiqə";
            }
        }
        [NotMapped]
        public string AvaliableBateryDay
        {
            get
            {
                var result = (this.BateryCapacity * (decimal)(this.BateryStorage) / (decimal)100) / 40M;
                int day = Convert.ToInt32(result);

                int hour = Convert.ToInt32(24 * (result - day));
                return day+" gün " + hour+" saat";
            }
        }

        [NotMapped]
        public string SailEnergyAmount
        {
            get
            {
                if (this.BateryStorage < 80)
                    return "satacaq qədər enerjiniz yoxdur";

                return Math.Round(((this.BateryCapacity*(this.BateryStorage-80))/100),2).ToString() + " kVt*s";
            }
        }
    }
}
