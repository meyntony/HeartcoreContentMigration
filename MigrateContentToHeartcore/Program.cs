// See https://aka.ms/new-console-template for more information
using MigrateContentToHeartcore.DTOs;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Net.Http.Formatting;

int page = 0;

Uri ShowsAPI(int page) => new($"https://api.tvmaze.com/shows?page={page}");

HttpClient client = new();

ConcurrentDictionary<int, TVMazeShow> allShows = [];
Stopwatch totalTime = Stopwatch.StartNew();

while (true)
{
	var response = client.GetAsync(ShowsAPI(page++)).Result;
	var shows = response.Content.ReadAsAsync<TVMazeShow[]>(formatters: [new JsonMediaTypeFormatter()]).Result;
	try { response.EnsureSuccessStatusCode(); } catch { break; }
	if (shows.Length != 0)
	{
		foreach (var show in shows)
		{
			allShows.TryAdd(show.Id, show);
		}
	}
}
Console.WriteLine($"Total time to download:{totalTime.Elapsed}");
totalTime.Restart();

await Parallel.ForEachAsync(allShows, async (show, x) =>
{
	_ = UploadShowToMyHeartcoreProject(show.Value);
});
totalTime.Stop();
Console.WriteLine($"Total time to upload:{totalTime.Elapsed}");


async Task<bool> UploadShowToMyHeartcoreProject(TVMazeShow show)
{
	// Console.WriteLine($"Check if {show.Name} exists in your Heartcore project using the ID: {show.Id}");
	/*
	 * if it exists, make sure if a specific property in Heartcore does not have a value but has a value from TVMAZE then update the property.
	 * if it does not exist, make sure to download the images to the media section and reference it to a corresponding content node that you create.
	 */
	return false;
}


