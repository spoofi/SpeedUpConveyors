using KitchenData;
using KitchenLib.Utils;

namespace SpeedUpConveyors;

internal static class Utils
{
    internal static IEnumerable<Appliance> GetAppliances(params int[] ids) => ids.Select(GetAppliance);
    
    private static Appliance GetAppliance(int id)
    {
        if (GDOUtils.GetExistingGDO(id) is Appliance appliance) 
            return appliance;
        
        var message = $"Can't get appliance with id = {id}";
        ModLogger.Log(message);
        throw new Exception(message);
    }
}
