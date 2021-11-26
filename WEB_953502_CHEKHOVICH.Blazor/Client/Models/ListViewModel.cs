using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace WEB_953502_CHEKHOVICH.Blazor.Client.Models
{
    public class ListViewModel
    {
        [JsonPropertyName("computerId")]
        public int ComputerId { get; set; } // id компьютера
        [JsonPropertyName("name")]
        public string Name { get; set; } // название компьютера
    }
}
