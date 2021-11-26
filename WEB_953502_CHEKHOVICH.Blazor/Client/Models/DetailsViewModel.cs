using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace WEB_953502_CHEKHOVICH.Blazor.Client.Models
{
    public class DetailsViewModel
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } // название компьютера

        [JsonPropertyName("ram")]
        public int RAM { get; set; }

        [JsonPropertyName("graphicsCard")]
        public string GraphicsCard { get; set; }

        [JsonPropertyName("cpu")]
        public string CPU { get; set; }

        [JsonPropertyName("price")]
        public int Price { get; set; } // кол. калорий на порцию

        [JsonPropertyName("image")]
        public string Image { get; set; } // имя файла изображения
    }
}
