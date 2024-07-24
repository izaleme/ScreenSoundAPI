using System.Text.Json;
using ScreenSoundAPI.Models;
using ScreenSoundAPI.Filters;

using (HttpClient client = new HttpClient())
{
	try
	{
        string resposta = await client.GetStringAsync("https://guilhermeonrails.github.io/api-csharp-songs/songs.json");
        var musicas = JsonSerializer.Deserialize<List<Musica>>(resposta)!;

        //LinqFilters.ExibirGenerosMusicais(musicas);
        //LinqOrder.ExibirArtistasOrdenados(musicas);
        //LinqFilters.FiltrarArtistasPorGeneroMusical(musicas, "rock");
        //LinqFilters.FiltrarMusicasDoArtista(musicas, "Two Door Cinema Club");
        LinqFilters.FiltrarMusicasPorAno(musicas, 2018);
    }
    catch (Exception ex)
	{
        Console.WriteLine($"Ocorreu um erro: {ex.Message}");
    }
}