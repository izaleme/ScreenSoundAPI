using ScreenSoundAPI.Models;

namespace ScreenSoundAPI.Filters;

internal class LinqFilters
{
    public static void ExibirGenerosMusicais(List<Musica> musicas)
    {
        HashSet<string> generosUnicos = new(); // não permite dualidade

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
        Console.WriteLine();
    }

    public static void FiltrarArtistasPorGeneroMusical(List<Musica> musicas, string genero)
    {
        var artistasPorgeneroMusical = musicas.Where(musica => musica.Genero!.Contains(genero)).Select(musica => musica.Artista).Distinct().ToList();
        Console.WriteLine($"\nExibindo os artistas do gênero musical {genero} \n");

        foreach (var artista in artistasPorgeneroMusical)
        {
            Console.WriteLine($"- {artista}");
        }
        Console.WriteLine();
    }

    public static void FiltrarMusicasDoArtista(List<Musica> musicas, string nomeArtista)
    {
        var musicasArtista = musicas.Where(musica => musica.Artista!.ToLower().Equals(nomeArtista.ToLower())).OrderBy(musica => musica.Nome).ThenBy(musica => musica.Artista).ToList();

        Console.WriteLine($"** {nomeArtista} **");
        foreach (var musica in musicasArtista)
        {
            Console.WriteLine($"- {musica.Nome}");
        }
        Console.WriteLine();
    }

    public static void FiltrarMusicasPorAno(List<Musica> musicas, int ano)
    {
        bool existe = false;
        var musicasAno = musicas.Where(musica => musica.Ano == ano).OrderBy(musica => musica.Nome).ThenBy(musica => musica.Artista).Select(musica => musica.Nome).Distinct().ToList();

        Console.WriteLine($"Músicas do ano {ano}:");
        foreach (var musica in musicasAno)
        {
            existe = true;
            Console.WriteLine($"- {musica}");
        }

        if (!existe)
        {
            Console.WriteLine("Nenhuma música encontrada para o ano informado!");
        }
        Console.WriteLine();
    }

    public static void FiltrarMusicasPorTonalidade(List<Musica> musicas, int nota)
    {
        var tonalidade = musicas.Where(m => m.Key == nota).Select(m => m.Nota).Distinct().ToList();
        var musicasTonalidade = musicas.Where(m => m.Key == nota).OrderBy(m => m.Nome).ThenBy(m => m.Artista).Select(m => m.Nome).Distinct().ToList();

        Console.WriteLine($"Músicas da tonalidade {tonalidade[0]}:\n");
        foreach (var musica in musicasTonalidade)
        {
            Console.WriteLine($"- {musica}");
        }
        Console.WriteLine();
    }
}
