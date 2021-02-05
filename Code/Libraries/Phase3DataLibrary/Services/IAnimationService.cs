using CommonBasicStandardLibraries.CollectionClasses;
using Phase3DataLibrary.Models;
using System.Threading.Tasks;
namespace Phase3DataLibrary.Services
{
    public interface IAnimationService
    {
        CustomBasicList<double> GetAttackAnimations(UnitModel unit, EnumDamageType damage, double charge);
        Task InitAsync(); //could get data from a database, etc.
        double GetChargeDamage(UnitModel unit); //if there is charge damage, the third animation will do charge damage.  otherwise, they will not.
        //this allows the possibility of being able to use a database if needed to get the information for charge.
    }
}