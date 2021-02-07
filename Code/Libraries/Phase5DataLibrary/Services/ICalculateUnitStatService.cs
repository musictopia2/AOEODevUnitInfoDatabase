using CommonBasicStandardLibraries.CollectionClasses;
using Phase5DataLibrary.Models;
namespace Phase5DataLibrary.Services
{
    public interface ICalculateUnitStatService
    {
        CustomBasicList<UpdateUnitStatModel> GetCalculatedAttackUnits(CustomBasicList<UnitModel> attackUnits);
        CustomBasicList<UpdateUnitStatModel> GetCalculatedDefenseUnits(CustomBasicList<UnitModel> defenseUnits);
        void RecalculateAttackUnits(CustomBasicList<UpdateUnitStatModel> attackUnits); //this means it will recalculate.
        void RecalculateDefenseUnits(CustomBasicList<UpdateUnitStatModel> defenseUnits); //in this case, only the values will get updated.
    }
}