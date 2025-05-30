namespace ProyectoFinal.Models
{
    public class Alarms
    {
        public int IdAlarm { get; set; }

        public int IdUser { get; set; }
        public string AlarmName { get; set; } 
        public string Hour { get; set; }

        public string Frecuency { get; set; }
    }
}