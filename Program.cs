using System.Text.Json;
using ScreenSoundAPI.Models;

using (HttpClient client = new HttpClient())
{
	try
	{
        string resposta = await client.GetStringAsync("https://guilhermeonrails.github.io/api-csharp-songs/songs.json");
        var musicas = JsonSerializer.Deserialize<List<Musica>>(resposta)!;

        musicas[1998].ExibeDetalhesMusica();
    }
	catch (Exception ex)
	{
        Console.WriteLine($"Ocorreu um erro: {ex.Message}");
    }
}