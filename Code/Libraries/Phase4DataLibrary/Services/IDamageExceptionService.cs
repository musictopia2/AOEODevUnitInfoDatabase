using Phase4DataLibrary.Models;
using System.Threading.Tasks;
namespace Phase4DataLibrary.Services
{
    public interface IDamageExceptionService
    {
        double GetDamage(UnitModel unit, double damage, EnumDamageType category);
        Task InitAsync(); //just in case there is a database to initialize.
    }
}