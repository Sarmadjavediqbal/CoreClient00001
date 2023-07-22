using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CoreClient00001.Models
{
    public class DataAccess
    {
        [Column("SensorLogID")]
        public int SensorLogID { get; set; }

        [Column("SensorID")]
        public int SensorID { get; set; }

        [Column("SensorData")]
        public double? SensorData { get; set; }

        [Column("SensorTime")]
        public DateTime SensorTime { get; set; }
    }
}
