using System.Text.Json.Serialization;

namespace ProyectoFinal.Models;

public class Mascota
{
    public int IdPet { get; set; }

    public int IdUser { get; set; }
    [JsonPropertyName("Name")]
    public string PetName { get; set; }
    public string Specie { get; set; }
    public int Age { get; set; }
}

