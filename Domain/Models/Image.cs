using Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Domain.Model
{
    public class Image

    {
        public int Id { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Color Colors { get; set; }
        public Shape Shape { get; set; }
        [Required]
        public int? DiamondId { get; set; }
    }
}