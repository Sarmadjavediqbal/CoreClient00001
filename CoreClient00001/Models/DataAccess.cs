using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CoreClient00001.Models
{
    public class DataAccess
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("sensor_id")]
        public int SensorId { get; set; }

        [Column("sensor_data")]
        public double? SensorData { get; set; }

        [Column("sensor_name")]
        public string? SensorName { get; set; }

        [Column("created_at")]
        public DateTime? CreatedAt { get; set; }
    }
}
