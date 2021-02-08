using CommonBasicStandardLibraries.AdvancedGeneralFunctionsAndProcesses.BasicExtensions;
using CommonBasicStandardLibraries.CollectionClasses;
using CommonBasicStandardLibraries.Exceptions;
using Phase5DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phase5DataLibrary.Helpers
{
    public static class TechExtensions
    {
        public static void FilterTechCivs(this CustomBasicList<TechnologyModel> techs, string civilization)
        {
            techs.RemoveAllAndObtain(xxx =>
            {
                if (xxx.Civilization.ToLower() == "all")
                {
                    return false;
                }
                if (xxx.Civilization.ToLower() == civilization.ToLower())
                {
                    return false;
                }
                if (xxx.Civilization.Contains("-") == false)
                {
                    return true;
                }
                CustomBasicList<string> list = xxx.Civilization.Split("-").ToCustomBasicList();
                if (list.Count != 2)
                {
                    throw new BasicBlankException("Can only have 2 items for splitting -  Otherwise, rethink");
                }
                string excepts = list.Last();
                if (xxx.Civilization.ToLower() == excepts.ToLower())
                {
                    return true;
                }
                return false;
            });
        }
    }
}
