﻿using System.Text.Json.Serialization;

namespace ProyectoFinal.Models
{
    public class Alarms
    {
        public int IdAlarm { get; set; }

        public int IdUser { get; set; }
        [JsonPropertyName("title")]
        public string AlarmName { get; set; } 
        public string Hour { get; set; }

        public string Frequency { get; set; }
    }
}