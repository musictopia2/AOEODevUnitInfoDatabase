using Phase5DataLibrary.Models;
using System.Threading.Tasks;
namespace Phase5DataLibrary.Services
{
    public class DamageExceptionService : IDamageExceptionService
    {
        public double GetDamage(UnitCalculatedModel unit, double damage, EnumDamageType category)
        {
            if (unit.BasicUnit.UnitName == "Sapper" && category == EnumDamageType.SiegeMelee)
                return unit.HandDPS;
            if (unit.BasicUnit.UnitName == "Farbjoðr" && category == EnumDamageType.Hand && unit.BasicUnit.Champion == true)
                return unit.SiegeMeleeDPS;
            return damage;
        }
        public Task InitAsync()
        {
            return Task.CompletedTask;
        }
    }
}