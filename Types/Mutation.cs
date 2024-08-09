using HotChocolate.Subscriptions;
using SpotifyWeb;

namespace Odyssey.MusicMatcher;

public class Mutation
{
    public async Task<AddItemsToPlaylistPayload> AddItemsToPlaylist(
        AddItemsToPlaylistInput input,
        SpotifyService spotifyService,
        [Service] ITopicEventSender sender
    )
    {
        try
        {
            var snapshot_id = await spotifyService.AddTracksToPlaylistAsync(
                input.PlaylistId,
                null,
                string.Join(",", input.Uris)
            );

            var response = await spotifyService.GetPlaylistAsync(input.PlaylistId);
            var playlist = new Playlist(response);

            await sender.SendAsync(nameof(Subscription.PlaylistItemsAdded), playlist);

            return new AddItemsToPlaylistPayload(
                200,
                true,
                "Successfully added items to playlist",
                playlist
            );
        }
        catch (Exception e)
        {
            return new AddItemsToPlaylistPayload(500, false, e.Message, null);
        }
    }
}
