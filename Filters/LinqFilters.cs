using ScreenSoundAPI.Models;

namespace ScreenSoundAPI.Filters;

internal class LinqFilters
{
    //public static void FiltrarGenerosMusicais(List<Musica> musicas)
    //{
    //    var allGenres = musicas.Select(generos => generos.Genero).Distinct().ToList();

    //    foreach (var genre in allGenres)
    //    {
    //        Console.WriteLine($"- {genre}");
    //    }
    //}

    public static void ExibirTodosGenerosMusicaisUnicos(List<Musica> musicas)
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
}
