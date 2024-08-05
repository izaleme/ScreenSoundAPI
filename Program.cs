using System.Text.Json;
using ScreenSoundAPI.Models;
using ScreenSoundAPI.Filters;

using (HttpClient client = new HttpClient())
{
    try
    {
        string resposta = await client.GetStringAsync("https://guilhermeonrails.github.io/api-csharp-songs/songs.json");
        var musicas = JsonSerializer.Deserialize<List<Musica>>(resposta)!;

        // *** Testes de filtros e ordenação ***
        /*LinqOrder.ExibirMusicasOrdenadas(musicas);
        LinqFilters.ExibirGenerosMusicais(musicas);
        LinqOrder.ExibirArtistasOrdenados(musicas);
        LinqFilters.FiltrarArtistasPorGeneroMusical(musicas, "rock");
        LinqFilters.FiltrarMusicasDoArtista(musicas, "Two Door Cinema Club");
        LinqFilters.FiltrarMusicasPorAno(musicas, 2018);*/

        // *** Testes de Musica ***
        /*var musicasFavsAsh = new MusicasPreferidas("Ash");
        musicasFavsAsh.AddMusicasFavoritas(musicas[20]);
        musicasFavsAsh.AddMusicasFavoritas(musicas[30]);
        musicasFavsAsh.AddMusicasFavoritas(musicas[60]);
        musicasFavsAsh.AddMusicasFavoritas(musicas[70]);
        musicasFavsAsh.ExibirMusicasFavoritas();
        musicasFavsAsh.GerarAquivoJson();*/

        //musicas[19].ExibeDetalhesMusica();
        //LinqFilters.FiltrarMusicasPorTonalidade(musicas, 1); // 1 = C#

        // Edit: Comentados porque agora esse projeto será usado como dll, e não como exe.
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Ocorreu um erro: {ex.Message}");
    }
}