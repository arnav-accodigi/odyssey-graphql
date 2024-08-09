namespace Odyssey.MusicMatcher;

public class AddItemsToPlaylistInput
{
    [ID]
    [GraphQLDescription("ID of the playlist")]
    public string PlaylistId { get; set; }

    [GraphQLDescription("List of Spotify URIs to add")]
    public List<string> Uris { get; set; }

    public AddItemsToPlaylistInput(string playlistId, List<string> uris)
    {
        PlaylistId = playlistId;
        Uris = uris;
    }
}
