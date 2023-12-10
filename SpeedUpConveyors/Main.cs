using System.Reflection;
using JetBrains.Annotations;
using Kitchen;
using KitchenLib;
using KitchenLib.References;

namespace SpeedUpConveyors;

[UsedImplicitly]
public class Main : BaseMod
{
    public Main() : base(
        ModInfo.Guid,
        ModInfo.Name,
        ModInfo.Author,
        ModInfo.Version,
        ModInfo.GameVersion,
        Assembly.GetExecutingAssembly())
    {
    }

    protected override void OnInitialise() => SpeedUpConveyors();

    private static void SpeedUpConveyors()
    {
        var baseConveyors = Utils.GetAppliances(ApplianceReferences.Belt, ApplianceReferences.Grabber, ApplianceReferences.GrabberRotatable, ApplianceReferences.GrabberSmart);

        foreach (var appliance in baseConveyors)
        {
            if (appliance.Properties?.Any() is null or false)
                continue;

            for (var i = 0; i < appliance.Properties!.Count; i++)
            {
                switch (appliance.Properties[i])
                {
                    case CConveyCooldown cooldown:
                        cooldown.Total = 0.01f;
                        appliance.Properties[i] = cooldown;
                        break;
                    case CConveyPushItems pushItems:
                        pushItems.Delay = 0.33f;
                        appliance.Properties[i] = pushItems;
                        break;
                }
            }
        }
    }
}
