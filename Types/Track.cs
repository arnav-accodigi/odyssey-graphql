using System;
using SpotifyWeb;

namespace Odyssey.MusicMatcher;

[GraphQLDescription("A single track")]
public class PlaylistTrack
{
    [ID]
    public string Id { get; }

    public string Name { get; set; }

    [GraphQLDescription("Duration of the track in ms")]
    public double DurationMs { get; set; }

    public bool Explicit { get; set; }

    public string Uri { get; set; }

    public PlaylistTrack(string id, string name, string uri)
    {
        Id = id;
        Name = name;
        Uri = uri;
    }

    public PlaylistTrack(PlaylistTrackItem track)
    {
        Id = track.Id;
        Name = track.Name;
        DurationMs = track.Duration_ms;
        Explicit = track.Explicit;
        Uri = track.Uri;
    }
}
