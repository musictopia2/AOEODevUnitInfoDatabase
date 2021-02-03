using CommonBasicStandardLibraries.CollectionClasses;
using Phase1DataLibrary.Models;
using System.Threading.Tasks;

namespace Phase1DataLibrary.Services
{
    public interface IAnimationService
    {
        CustomBasicList<double> GetAttackAnimations(AttackUnitModel unit, EnumDamageType damage);

        Task InitAsync(); //could get data from a database, etc.

    }
}