using System.Text.Json;

namespace ScreenSoundAPI.Models;

internal class MusicasPreferidas
{
    #region Attributes/Properties

    public string? Nome { get; set; }
    public List<Musica> ListaMusicasFavoritas { get; set; }

    #endregion

    #region Builders

    public MusicasPreferidas(string nome)
    {
        Nome = nome;
        ListaMusicasFavoritas = new List<Musica>();
    }

    #endregion

    #region Methods

    public void AddMusicasFavoritas(Musica musica)
    {
        ListaMusicasFavoritas.Add(musica);
    }

    public void ExibirMusicasFavoritas()
    {
        Console.WriteLine($"Músicas favoritas de {Nome}:");
        foreach (var musica in ListaMusicasFavoritas)
        {
            Console.WriteLine($" - {musica.Nome} de {musica.Artista}");
        }
        Console.WriteLine();
    }

    public void GerarAquivoJson()
    {
        // Criando um objeto anônimo -------------
        string json = JsonSerializer.Serialize(new
        {
            nome = Nome,
            musicas = ListaMusicasFavoritas
        });

        string nomeArquivo = $"musicas-favoritas-{Nome}.json";

        File.WriteAllText(nomeArquivo, json);
        Console.WriteLine($"O arquivo Json foi criado com sucesso! {Path.GetFullPath(nomeArquivo)}");
    }

    #endregion
}
