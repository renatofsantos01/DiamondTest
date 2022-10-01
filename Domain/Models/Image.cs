using Domain.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Domain.Model
{
    public class Image
    {
        [Key]
        public int Id { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Color Colors { get; set; }
        public string Shape { get; set; }
    }
}
