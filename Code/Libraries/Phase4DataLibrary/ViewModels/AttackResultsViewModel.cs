using CommonBasicStandardLibraries.CollectionClasses;
using Phase4DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phase4DataLibrary.ViewModels
{
    public class AttackResultsViewModel : IAttackResultsViewModel
    {

        public AttackResultsViewModel()
        {

        }

        public CustomBasicList<AttackResultsModel> GetAttackResults(CustomBasicList<UnitModel> attackingUnits, CustomBasicList<UnitModel> defendingUnits)
        {
            throw new NotImplementedException();
        }

        
    }
}
