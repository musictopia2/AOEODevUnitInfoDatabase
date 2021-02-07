using Phase5DataLibrary.Models;
using System.Threading.Tasks;
namespace Phase5DataLibrary.Services
{
    public interface IDamageExceptionService
    {
        double GetDamage(UpdateUnitStatModel unit, double damage, EnumDamageType category);
        Task InitAsync(); //just in case there is a database to initialize.
    }
}