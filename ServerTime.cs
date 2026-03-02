using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Modules.Commands;
using CounterStrikeSharp.API.Modules.Utils;

namespace ServerTimePlugin;

public class ServerTimeConfig : IBasePluginConfig
{
    public List<string> Commands { get; set; } =
        new() { "css_time", "css_ora", "css_thetime" };
    public string TimeZone { get; set; } = "";
    public string TimeFormat { get; set; } = "HH:mm:ss";
    public string Message { get; set; } = "Time is: {time}";
    public int Version { get; set; } = 1;
}

public class ServerTimePlugin : BasePlugin, IPluginConfig<ServerTimeConfig>
{
    public override string ModuleName => "ServerTime";
    public override string ModuleAuthor => "GSM-RO";
    public override string ModuleVersion => "1.0.0";
    public override string ModuleDescription => "Time on server";

    public ServerTimeConfig Config { get; set; } = new();

    public void OnConfigParsed(ServerTimeConfig config)
    {
        Config = config;
    }

    public override void Load(bool hotReload)
    {
        foreach (var cmd in Config.Commands)
        {
            AddCommand(cmd, "Show server time", CommandTime);
        }
    }

    private void CommandTime(CCSPlayerController? player, CommandInfo command)
    {
        if (player == null || !player.IsValid || player.IsBot)
            return;

        // Ia ora serverului (sau fusul orar configurat)
        DateTime time = DateTime.Now;

        if (!string.IsNullOrEmpty(Config.TimeZone))
        {
            try
            {
                var tz = TimeZoneInfo.FindSystemTimeZoneById(Config.TimeZone);
                time = TimeZoneInfo.ConvertTime(DateTime.Now, tz);
            }
            catch
            {
                // fallback at time OS
            }
        }

        string formatted = time.ToString(Config.TimeFormat);

        string rawMessage = Config.Message.Replace("{time}", formatted);

string message = $" {ChatColors.Green}[ServerTime]{ChatColors.Yellow} {rawMessage}{ChatColors.Default}";

string separator = $" {ChatColors.Green}[ServerTime]{ChatColors.Yellow} ****************{ChatColors.Default}";

player.PrintToChat(separator);
player.PrintToChat(message);
player.PrintToChat(separator);
    }
}