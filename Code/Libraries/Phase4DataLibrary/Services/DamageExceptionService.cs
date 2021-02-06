using Phase4DataLibrary.Models;
using System.Threading.Tasks;
namespace Phase4DataLibrary.Services
{
    public class DamageExceptionService : IDamageExceptionService
    {
        public double GetDamage(UnitModel unit, double damage, EnumDamageType category)
        {
            if (unit.UnitName == "Sapper" && category == EnumDamageType.SiegeMelee)
                return unit.HandDPS;
            if (unit.UnitName == "Farbjoðr" && category == EnumDamageType.Hand && unit.Champion == true)
                return unit.SiegeMeleeDPS;
            return damage;
        }
        public Task InitAsync()
        {
            return Task.CompletedTask;
        }
    }
}