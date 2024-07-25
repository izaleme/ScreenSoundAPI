using ScreenSoundAPI.Models;

namespace ScreenSoundAPI.Filters;

internal class LinqOrder
{
    public static void ExibiMusicasOrdenadas(List<Musica> musicas)
    {
        var musicasOrdenadas = musicas.OrderBy(mus => mus.Nome).Select(mus => mus.Nome).Distinct().ToList();
        Console.WriteLine("Lista de músicas:");
        foreach (var musica in musicasOrdenadas)
        {
            Console.WriteLine($"- {musica}");
        }
        Console.WriteLine();
    }

    public static void ExibirArtistasOrdenados(List<Musica> musicas)
    {
        var artistasOrdenados = musicas.OrderBy(mus => mus.Artista).Select(mus => mus.Artista).Distinct().ToList();
        Console.WriteLine("Lista de artistas:");
        foreach (var artista in artistasOrdenados)
        {
            Console.WriteLine($"- {artista}");
        }
        Console.WriteLine();
    }
}
