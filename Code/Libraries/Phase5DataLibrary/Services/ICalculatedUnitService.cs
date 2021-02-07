using CommonBasicStandardLibraries.CollectionClasses;
using Phase5DataLibrary.Models;
namespace Phase5DataLibrary.Services
{
    public interface ICalculatedUnitService
    {
        CustomBasicList<UnitCalculatedModel> GetCalculatedAttackUnits(CustomBasicList<UnitBaseModel> attackUnits);
        CustomBasicList<UnitCalculatedModel> GetCalculatedDefenseUnits(CustomBasicList<UnitBaseModel> defenseUnits);
        void RecalculateAttackUnits(CustomBasicList<UnitCalculatedModel> attackUnits); //this means it will recalculate.
        void RecalculateDefenseUnits(CustomBasicList<UnitCalculatedModel> defenseUnits); //in this case, only the values will get updated.
    }
}