namespace Odyssey.MusicMatcher;

public class AddItemsToPlaylistPayload
{
    public int Code { get; set; }

    public bool Success { get; set; }

    public string Message { get; set; }

    public Playlist? Playlist { get; set; }

    public AddItemsToPlaylistPayload(int code, bool success, string message, Playlist? playlist)
    {
        Code = code;
        Success = success;
        Message = message;

        if (playlist != null)
        {
            Playlist = playlist;
        }
    }
}
