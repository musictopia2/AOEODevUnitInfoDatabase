using Phase3DataLibrary.Models;
using System.Threading.Tasks;
namespace Phase3DataLibrary.Services
{
    public interface IDamageExceptionService
    {
        double GetDamage(UnitModel unit, double damage, EnumDamageType category);
        Task InitAsync(); //just in case there is a database to initialize.
    }
}