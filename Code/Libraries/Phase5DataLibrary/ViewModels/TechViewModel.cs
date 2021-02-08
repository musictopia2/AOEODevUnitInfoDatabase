using CommonBasicStandardLibraries.AdvancedGeneralFunctionsAndProcesses.BasicExtensions;
using CommonBasicStandardLibraries.CollectionClasses;
using Phase5DataLibrary.Containers;
using Phase5DataLibrary.Models;
using Phase5DataLibrary.Services;
using System;
using System.Threading.Tasks;
namespace Phase5DataLibrary.ViewModels
{
    public class TechViewModel : ITechViewModel
    {
        private readonly TechListContainer _container;
        private readonly ITechService _techService;
        private CustomBasicList<TechnologyModel> _fullAttackList;
        private CustomBasicList<TechnologyModel> _fullDefenseList;
        public TechViewModel(TechListContainer container, 
                        ITechService techService
            )
        {
            _container = container;
            _techService = techService;
        }
        //even if tech is filtered, whatever is selected is still selected.
        //if you clear the list, then means all cleared (even hidden).
        

        public CustomBasicList<TechnologyModel> AttackFullTechList { get; private set; }
        public CustomBasicList<TechnologyModel> DefenseFullTechList { get; private set; }
        public Action Refresh { get; set; }

        public void UnselectAllAttackTechs()
        {
            _container.AttackSelectedTechList.Clear();
            Refresh?.Invoke();
        }

        public void UnselectAllDefenseTechs()
        {
            _container.DefenseSelectedTechList.Clear();
            Refresh?.Invoke();
        }

        public void FilterAttackCivilization(string civilization)
        {
            
        }


        //maybe no need for now for filtering attacking unit (well see).


        //public void FilterAttackingUnit(string attackingUnit)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task FilterDefendingUnit(string defendingUnit)
        //{
        //    throw new NotImplementedException();
        //}

        public void FilterDefenseCivilization(string civilization)
        {
            
        }

        public async Task InitAsync()
        {
            _fullAttackList = await _techService.GetAllAttackTechsAsync();
            _fullDefenseList = await _techService.GetAllDefenseTechsAsync();
            ClearTechs();
        }

        //i propose no recalculations until you close the popup.
        //most likely would need 2 different popups.
        //i have 2 different reports (so might as well have 2 different popups as well).  more time is spent reading than writing code anyways.
        public void SelectAllAttackTechs()
        {
            //this means that the attack selected total will be whatever is known.
            _container.AttackSelectedTechList = AttackFullTechList.ToCustomBasicList(); //make a copy.
            Refresh?.Invoke();
        }

        public void SelectAllDefenseTechs()
        {
            _container.DefenseSelectedTechList = DefenseFullTechList.ToCustomBasicList();
            Refresh?.Invoke();
        }

        public void ClearTechs()
        {
            AttackFullTechList = _fullAttackList.ToCustomBasicList();
            DefenseFullTechList = _fullDefenseList.ToCustomBasicList();
        }
    }
}