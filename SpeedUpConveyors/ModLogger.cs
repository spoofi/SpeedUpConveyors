using KitchenLib.Logging;

namespace SpeedUpConveyors;

internal static class ModLogger
{
    private static readonly KitchenLogger Logger = new(ModInfo.Name);

    public static void Log(string message) => Logger.LogWarning(message);
}
