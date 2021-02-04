using Phase1DataLibrary.Models;
using System.Threading.Tasks;
namespace Phase1DataLibrary.Services
{
    public class DamageExceptionService : IDamageExceptionService
    {
        public double GetDamage(AttackUnitModel unit, double damage, EnumDamageType category)
        {
            if (unit.UnitName == "Sapper" && category == EnumDamageType.SiegeMelee)
            {
                return unit.HandDPS;
            } //this means if there are any other exceptions, they can be tracked as well.
            if (unit.UnitName == "Farbjoðr" && category == EnumDamageType.Hand && unit.Champion == true)
            {
                return unit.SiegeMeleeDPS;
            }
            return damage;
        }
        public Task InitAsync()
        {
            return Task.CompletedTask;
        }
    }
}