using ScreenSoundAPI.Models;

namespace ScreenSoundAPI.Filters;

internal class LinqFilters
{
    public static void ExibirGenerosMusicais(List<Musica> musicas)
    {
        HashSet<string> generosUnicos = new HashSet<string>(); // não permite dualidade

        foreach (Musica musica in musicas)
        {
            string[] generos = musica.Genero!.Split(',');

            foreach (string genero in generos)
            {
                if (!(genero.Trim() == "set()")) // Tratando spring do python
                {
                    generosUnicos.Add(genero.Trim());
                }
            }
        }

        // ~~~ Exibição ~~~
        Console.WriteLine("Gêneros musicais encontrados: \n");
        foreach (var genero in generosUnicos.OrderBy(g => g))
        {
            Console.WriteLine($"- {genero}");
        }
    }

    public static void FiltrarArtistasPorGeneroMusical(List<Musica> musicas, string genero)
    {
        var artistasPorgeneroMusical = musicas.Where(musica => musica.Genero!.Contains(genero)).Select(musica => musica.Artista).Distinct().ToList();
        Console.WriteLine($"\nExibindo os artistas do gênero musical {genero} \n");

        foreach (var artista in artistasPorgeneroMusical)
        {
            Console.WriteLine($"- {artista}");
        }
    }

    public static void FiltrarMusicasDoArtista(List<Musica> musicas, string nomeArtista)
    {
        var musicasArtista = musicas.Where(musica => musica.Artista!.ToLower().Equals(nomeArtista.ToLower())).OrderBy(m => m).ToList();

        Console.WriteLine($"** {nomeArtista} **");
        foreach (var musica in musicasArtista)
        {
            Console.WriteLine($"- {musica.Nome}");
        }
    }

    public static void FiltrarMusicasPorAno(List<Musica> musicas, int ano)
    {
        var musicasAno = musicas.Where(musica => musica.Ano == ano).OrderBy(musica => musica.Nome).Select(musica => musica.Nome).Distinct().ToList();

        Console.WriteLine($"Músicas do ano {ano}:");
        foreach (var musica in musicasAno)
        {
            Console.WriteLine($"- {musica}");
        }
    }
}
