using SpotifyWeb;

namespace Odyssey.MusicMatcher;

[GraphQLDescription("A curated collection of tracks designed for a specific activity or mood.")]
public class Playlist
{
    [GraphQLDescription("The ID for the playlist.")]
    [ID]
    public string Id { get; }

    [GraphQLDescription("The name of the playlist.")]
    public string Name { get; set; }

    [GraphQLDescription("Describes the playlist, what to expect and entices the user to listen.")]
    public string? Description { get; set; }

    [GraphQLDescription("List of tracks in this playlist")]
    public async Task<List<PlaylistTrack>> Tracks(
        SpotifyService spotifyService,
        [Parent] Playlist parent
    )
    {
        if (_tracks != null)
        {
            return _tracks;
        }
        var response = await spotifyService.GetPlaylistsTracksAsync(parent.Id);
        return response.Items.Select(item => new PlaylistTrack(item.Track)).ToList();
    }

    private List<PlaylistTrack>? _tracks;

    public Playlist(string id, string name)
    {
        Id = id;
        Name = name;
    }

    public Playlist(PlaylistSimplified playlist)
    {
        Id = playlist.Id;
        Name = playlist.Name;
        Description = playlist.Description;
    }

    public Playlist(SpotifyWeb.Playlist playlist)
    {
        Id = playlist.Id;
        Name = playlist.Name;
        Description = playlist.Description;

        var paginatedTracks = playlist.Tracks.Items;
        _tracks = paginatedTracks.Select(item => new PlaylistTrack(item.Track)).ToList();
    }
}
