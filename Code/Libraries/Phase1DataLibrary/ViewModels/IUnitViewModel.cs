using CommonBasicStandardLibraries.CollectionClasses;
using Phase1DataLibrary.Helpers;
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
        EnumStage Stage { get; }
        CustomBasicList<string> Civilizations { get; }
        string CivilizationRequested { get; set; } //you have the right to request the civilization.
        string UnitRequested { get; set; }
        AttackUnitModel UnitUsed { get; set; }
        Task InitAsync();

        CustomBasicList<string> Units { get; }

        void Clear(); //you have the ability to clear out to start over again.

        Task ChoseCivilizationAsync();
        Task ChoseUnitAsync();



        //i think that after choosing a unit, you can always choose another unit easily.
        

        //i propose that after choosing civ, then ui should change.
        //then another popup.
        //finally show results.


    }
}
