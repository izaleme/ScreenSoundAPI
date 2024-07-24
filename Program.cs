using System.Text.Json;
using ScreenSoundAPI.Models;
using ScreenSoundAPI.Filters;

using (HttpClient client = new HttpClient())
{
	try
	{
        string resposta = await client.GetStringAsync("https://guilhermeonrails.github.io/api-csharp-songs/songs.json");
        var musicas = JsonSerializer.Deserialize<List<Musica>>(resposta)!;
        //LinqFilters.ExibirTodosGenerosMusicaisUnicos(musicas);
        LinqOrder.ExibirArtistasOrdenados(musicas);
    }
	catch (Exception ex)
	{
        Console.WriteLine($"Ocorreu um erro: {ex.Message}");
    }
}