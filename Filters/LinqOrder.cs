using ScreenSoundAPI.Models;

namespace ScreenSoundAPI.Filters;

internal class LinqOrder
{
    public static void ExibirArtistasOrdenados(List<Musica> musicas)
    {
        var artistasOrdenados = musicas.OrderBy(mus => mus.Artista).Select(mus => mus.Artista).Distinct().ToList();
        Console.WriteLine("Lista de artistas:");
        foreach (var artista in artistasOrdenados)
        {
            Console.WriteLine($"- {artista}");
        }
    }
}
