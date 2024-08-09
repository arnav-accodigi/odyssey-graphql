using SpotifyWeb;

namespace Odyssey.MusicMatcher;

public class Query
{
    [GraphQLDescription("Featured playlists")]
    public async Task<List<Playlist>> FeaturedPlaylists(SpotifyService spotifyService)
    {
        var response = await spotifyService.GetFeaturedPlaylistsAsync();
        return response.Playlists.Items.Select(item => new Playlist(item)).ToList();
    }

    [GraphQLDescription("Returns a playlist for the specified id")]
    public async Task<Playlist?> GetPlaylist([ID] string id, SpotifyService spotifyService)
    {
        var response = await spotifyService.GetPlaylistAsync(id);
        return new Playlist(response);
    }

    public async Task<SearchResults> Search(
        string query,
        List<SearchType> includeTypes,
        SpotifyService spotifyService
    )
    {
        var response = await spotifyService.SearchAsync(query, includeTypes, 10, 10, null);
        return response;
    }
}
