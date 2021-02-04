using CommonBasicStandardLibraries.CollectionClasses;
using Phase1DataLibrary.Models;
using Phase1DataLibrary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phase1DataLibrary.ViewModels
{
    public interface IUnitViewModel 
    {
        CustomBasicList<string> UnitStringList { get; } //this would show up first now.
        string UnitRequested { get; set; }
        CustomBasicList<string> Civilizations { get; } //based on unit selected.
        string CivilizationRequested { get; set; } //you have the right to request the civilization.
        string BaseString { get; set; }
        CustomBasicList<AttackUnitModel> UnitAttackList { get; } //after choosing the unit.

        CustomBasicList<string> UpgradeList { get; }

        //not just one unit though.


        Task InitAsync();


        void Clear(); //you have the ability to clear out to start over again.
        Task ChoseUnitAsync();

        void FilterCivilization();
        void FilterBaseChampion();


        //i think that after choosing a unit, you can always choose another unit easily.
        

        //i propose that after choosing civ, then ui should change.
        //then another popup.
        //finally show results.


    }
}
