using System.Text.Json.Serialization;

namespace ScreenSoundAPI.Models;

internal class Musica
{
    #region Attributes/Properties

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

    [JsonPropertyName("key")]
    public int Key { get; set; }

    private Dictionary<int, string> notas = new Dictionary<int, string>
    {
        { 0,  "C"  },
        { 1,  "C#" },
        { 2,  "D"  },
        { 3,  "D#" },
        { 4,  "E"  },
        { 5,  "F"  },
        { 6,  "F#" },
        { 7,  "G"  },
        { 8,  "G#" },
        { 9,  "A"  },
        { 10, "A#" },
        { 11, "B"  }
    };

    public string Nota
    {
        get
        {
            if (notas.TryGetValue(Key, out string? value))
            {
                return value;
            }
            else
            {
                return "Nota inválida";
            }
        }
    }

    #endregion

    #region Builders



    #endregion

    #region Methods

    public void ExibeDetalhesMusica()
    {
        Console.WriteLine($"Artista: {Artista}");
        Console.WriteLine($"Música: {Nome}");
        Console.WriteLine($"Duração: {Duracao / 1000}");
        Console.WriteLine($"Gênero musical: {Genero}");
        Console.WriteLine($"Tonalidade: {Nota}");
    }

    public static string ExibeGenerosMusicais(List<Musica> musicas)
    {
        var generos = musicas.Where(g => !String.IsNullOrEmpty(g.Genero.Trim()))
                             .SelectMany(musica => musica.Genero.Split(',', StringSplitOptions.TrimEntries))
                             .OrderBy(y => y)
                             .Distinct()
                             .ToList();

        string generosString = $"Gêneros musicais encontrados: {string.Join("\n ", generos)}";
        return generosString;
    }

    #endregion
}
