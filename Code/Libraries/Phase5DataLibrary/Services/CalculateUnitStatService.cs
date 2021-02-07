using CommonBasicStandardLibraries.CollectionClasses;
using Phase5DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phase5DataLibrary.Services
{
    public class CalculateUnitStatService : ICalculateUnitStatService
    {

        //this could require the view model for the techs for the data.
        //however, if that also requires the calculateunitstat, then overflows.
        //this is where i may need a container for techs.



        public CustomBasicList<UpdateUnitStatModel> GetCalculatedAttackUnits(CustomBasicList<UnitModel> attackUnits)
        {
            throw new NotImplementedException();
        }

        public CustomBasicList<UpdateUnitStatModel> GetCalculatedDefenseUnits(CustomBasicList<UnitModel> defenseUnits)
        {
            throw new NotImplementedException();
        }

        public void RecalculateAttackUnits(CustomBasicList<UpdateUnitStatModel> attackUnits)
        {
            throw new NotImplementedException();
        }

        public void RecalculateDefenseUnits(CustomBasicList<UpdateUnitStatModel> defenseUnits)
        {
            throw new NotImplementedException();
        }
    }
}
