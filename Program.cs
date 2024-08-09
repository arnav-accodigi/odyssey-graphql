using Odyssey.MusicMatcher;
using SpotifyWeb;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient<SpotifyService>();

builder
    .Services.AddGraphQLServer()
    .AddInMemorySubscriptions()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>()
    .AddSubscriptionType<Subscription>()
    .RegisterService<SpotifyService>();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("https://studio.apollographql.com").AllowAnyHeader().AllowAnyMethod();
    });
});

var app = builder.Build();

app.UseCors();
app.MapGraphQL();
app.UseWebSockets();

app.Run();
