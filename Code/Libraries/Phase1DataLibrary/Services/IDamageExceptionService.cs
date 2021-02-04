using Phase1DataLibrary.Models;
using System.Threading.Tasks;
namespace Phase1DataLibrary.Services
{
    public interface IDamageExceptionService
    {
        double GetDamage(AttackUnitModel unit, double damage, EnumDamageType category);
        Task InitAsync(); //just in case there is a database to initialize.
    }
}
