using System.Threading.Channels;
using Discord;
using Discord.WebSocket;

DotNetEnv.Env.Load();
var discordToken = Environment.GetEnvironmentVariable("DiscordToken");

async Task RunBotAsync()
{
    var client = new DiscordSocketClient();
    await client.LoginAsync(Discord.TokenType.Bot, discordToken);
    Console.WriteLine(client.LoginState);

    await client.StartAsync();

    client.Ready += async () => 
    {
        var guild = client.GetGuild(1352036217780306083);
        var channel = guild.GetTextChannel(1352036218828751023);

        await channel.SendMessageAsync("Bem vindos");

        var embed = new EmbedBuilder();
        embed.WithImageUrl("");
        await channel.SendMessageAsync(embed: embed.Build());
        await channel.SendMessageAsync("");

        await client.DisposeAsync();
    };
}

await RunBotAsync();
Console.ReadKey();