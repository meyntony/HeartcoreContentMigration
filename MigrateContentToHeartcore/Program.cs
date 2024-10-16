// See https://aka.ms/new-console-template for more information
using MigrateContentToHeartcore.DTOs;
using System.Diagnostics;
using System.Net.Http.Formatting;

int page = 0;

Uri ShowsAPI(int page) => new($"https://api.tvmaze.com/shows?page={page}");

HttpClient client = new();

Stopwatch totalTime = Stopwatch.StartNew();
while (true)
{
	var response = client.GetAsync(ShowsAPI(page++)).Result;
	var shows = response.Content.ReadAsAsync<TVMazeShow[]>(formatters: [new JsonMediaTypeFormatter()]).Result;
	try { response.EnsureSuccessStatusCode(); } catch { break; }
	if (shows.Any())
	{
		foreach (var show in shows)
		{
			Console.WriteLine($"Check if {show.Name} exists in your Heartcore project using the ID: {show.Id}");
			/*
			 * if it exists, make sure if a specific property in Heartcore does not have a value but has a value from TVMAZE then update the property.
			 * if it does not exist, make sure to download the images to the media section and reference it to a corresponding content node that you create.
			 */
		}
	}
}
totalTime.Stop();
Console.WriteLine(totalTime.Elapsed.ToString());
