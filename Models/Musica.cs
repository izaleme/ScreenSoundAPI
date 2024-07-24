using System.Text.Json.Serialization;

namespace ScreenSoundAPI.Models;

internal class Musica
{
    [JsonPropertyName("song")]
    public string? Nome { get; set; }

    [JsonPropertyName("artist")]
    public string? Artista { get; set; }

    [JsonPropertyName("duration_ms")]
    public int Duracao { get; set; }

    [JsonPropertyName("genre")]
    public string? Genero { get; set; }

    [JsonPropertyName("year")]
    public string? AnoString { get; set; }

    public int Ano
    {
        get
        {
            return int.Parse(AnoString!);
        }
    }

    public void ExibeDetalhesMusica()
    {
        Console.WriteLine($"Artista: {Artista}");
        Console.WriteLine($"Música: {Nome}");
        Console.WriteLine($"Duração: {Duracao / 1000}");
        Console.WriteLine($"Gênero musical: {Genero}");
    }

    //public static string ExibeGenerosMusicais(List<Musica> musicas)
    //{
    //    var generos = musicas.Select(musica => musica.Genero) // Seleciona os gêneros
    //                         .Where(g => g != null) // Filtra os valores null
    //                         .Distinct() // Distinct ignorando dif entre maiúscula/minúscula
    //                         .OrderBy(g => g); // Ordena por ordem alfabética

    //    string generosString = $"Gêneros musicais encontrados: {string.Join("\n ", generos)}";
    //    return generosString;
    //}
}
