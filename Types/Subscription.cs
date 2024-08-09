using SpotifyWeb;

namespace Odyssey.MusicMatcher;

public class Subscription
{
    [Subscribe]
    public Playlist PlaylistItemsAdded([EventMessage] Playlist playlist)
    {
        return playlist;
    }
}
