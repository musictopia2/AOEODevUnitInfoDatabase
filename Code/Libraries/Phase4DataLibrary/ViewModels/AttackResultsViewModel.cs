using CommonBasicStandardLibraries.CollectionClasses;
using CommonBasicStandardLibraries.Exceptions;
using Phase4DataLibrary.Helpers;
using Phase4DataLibrary.Models;
using Phase4DataLibrary.Services;
using System.Threading.Tasks;

namespace Phase4DataLibrary.ViewModels
{
    public class AttackResultsViewModel : IAttackResultsViewModel
    {
        private readonly IDamageExceptionService _damageService;
        private readonly IAnimationService _animationService;
        public AttackResultsViewModel(IDamageExceptionService damageService, IAnimationService animationService)
        {
            _damageService = damageService;
            _animationService = animationService;
        }
        public CustomBasicList<AttackResultsModel> GetAttackResults(CustomBasicList<UnitModel> attackingUnits, CustomBasicList<UnitModel> defendingUnits)
        {
            CustomBasicList<AttackResultsModel> output = new();
            attackingUnits.ForEach(attack =>
            {
                //has to do here.  more efficient doing just once and passing through.
                double handdpa = attack.HandDPA(_animationService, _damageService);
                double cavdpa = attack.CavalryDPA(_animationService, _damageService);
                double rangeddpa = attack.RangedDPA(_animationService, _damageService);
                double siegemeleedpa = attack.SiegeMeleeDPA(_animationService, _damageService);
                double siegerangedpa = attack.SiegeRangedDPA(_animationService, _damageService);
                defendingUnits.ForEach(defense =>
                {
                    CustomBasicList<AttackResultsModel> list = GetAttackResults(attack, defense, handdpa, cavdpa, rangeddpa, siegemeleedpa, siegerangedpa); ;
                    output.AddRange(list);
                });
            });
            return output;
        }
        private static CustomBasicList<AttackResultsModel> GetAttackResults(UnitModel attackingUnit, UnitModel defendingUnit, double handdpa, double cavdpa, double rangeddpa, double siegemeleedpa, double siegerangeddpa)
        {
            CustomBasicList<AttackResultsModel> output = new();
            EnumDamageType damageCat;
            EnumArmorCategory armorCat;
            double armorProtectionPercent;
            double armorProtectionAmount;
            double dpaMinusArmor;
            double bonusPecentage;
            double adjustedAmount;
            EnumBonusCategory bonusCat;
            bonusCat = attackingUnit.GetAttackBonusCategory(defendingUnit);
            bonusPecentage = attackingUnit.BonusDamagePercentage(bonusCat, defendingUnit);
            AttackResultsModel results;
            double animationsNeeded;
            if (handdpa != 0)
            {
                //this is hand damage.
                damageCat = EnumDamageType.Hand;
                armorCat = UnitModel.GetDefenseArmorCategory(damageCat);
                armorProtectionPercent = defendingUnit.GetArmorProtection(armorCat);
                armorProtectionAmount = armorProtectionPercent * handdpa;
                dpaMinusArmor = handdpa - armorProtectionAmount;
                adjustedAmount = dpaMinusArmor * bonusPecentage;
                if (adjustedAmount == 0)
                {
                    throw new BasicBlankException($"The damage cannot be 0 for hand dpa since originally was not 0.  attacking unit {attackingUnit.UnitName} and defending unit {defendingUnit.UnitName}.  Rethink");
                }
                animationsNeeded = defendingUnit.HitPoints / adjustedAmount;
                results = new AttackResultsModel("Hand", attackingUnit.FullName, defendingUnit.FullName, adjustedAmount, animationsNeeded);
                output.Add(results);
            }
            if (cavdpa != 0)
            {
                //this is cav damage.
                damageCat = EnumDamageType.Cavaltry;
                armorCat = UnitModel.GetDefenseArmorCategory(damageCat);
                armorProtectionPercent = defendingUnit.GetArmorProtection(armorCat);
                armorProtectionAmount = armorProtectionPercent * cavdpa;
                dpaMinusArmor = cavdpa - armorProtectionAmount;
                adjustedAmount = dpaMinusArmor * bonusPecentage;
                if (adjustedAmount == 0)
                {
                    throw new BasicBlankException($"The damage cannot be 0 for cav dpa since originally was not 0.  attacking unit {attackingUnit.UnitName} and defending unit {defendingUnit.UnitName}.  Rethink");
                }
                animationsNeeded = defendingUnit.HitPoints / adjustedAmount;
                results = new AttackResultsModel("Cavalry", attackingUnit.FullName, defendingUnit.FullName, adjustedAmount, animationsNeeded);
                output.Add(results);
            }
            if (rangeddpa != 0)
            {
                //this is range damage
                damageCat = EnumDamageType.Ranged;
                armorCat = UnitModel.GetDefenseArmorCategory(damageCat);
                armorProtectionPercent = defendingUnit.GetArmorProtection(armorCat);
                armorProtectionAmount = armorProtectionPercent * rangeddpa;
                dpaMinusArmor = rangeddpa - armorProtectionAmount;
                adjustedAmount = dpaMinusArmor * bonusPecentage;
                if (adjustedAmount == 0)
                {
                    throw new BasicBlankException($"The damage cannot be 0 for ranged dpa since originally was not 0.  attacking unit {attackingUnit.UnitName} and defending unit {defendingUnit.UnitName}.  Rethink");
                }
                animationsNeeded = defendingUnit.HitPoints / adjustedAmount;
                results = new AttackResultsModel("Ranged", attackingUnit.FullName, defendingUnit.FullName, adjustedAmount, animationsNeeded);
                output.Add(results);
            }
            if (siegemeleedpa != 0)
            {
                //this is siege melee
                damageCat = EnumDamageType.SiegeMelee;
                armorCat = UnitModel.GetDefenseArmorCategory(damageCat);
                armorProtectionPercent = defendingUnit.GetArmorProtection(armorCat);
                armorProtectionAmount = armorProtectionPercent * siegemeleedpa;
                dpaMinusArmor = siegemeleedpa - armorProtectionAmount;
                adjustedAmount = dpaMinusArmor * bonusPecentage;
                if (adjustedAmount == 0)
                {
                    throw new BasicBlankException($"The damage cannot be 0 for siege melle dpa since originally was not 0.  attacking unit {attackingUnit.UnitName} and defending unit {defendingUnit.UnitName}.  Rethink");
                }
                animationsNeeded = defendingUnit.HitPoints / adjustedAmount;
                results = new AttackResultsModel("Siege Melee", attackingUnit.FullName, defendingUnit.FullName, adjustedAmount, animationsNeeded);
                output.Add(results);
            }
            if (siegerangeddpa != 0)
            {
                //this is siege ranged.
                damageCat = EnumDamageType.SiegeRanged;
                armorCat = UnitModel.GetDefenseArmorCategory(damageCat);
                armorProtectionPercent = defendingUnit.GetArmorProtection(armorCat);
                armorProtectionAmount = armorProtectionPercent * siegerangeddpa;
                dpaMinusArmor = siegerangeddpa - armorProtectionAmount;
                adjustedAmount = dpaMinusArmor * bonusPecentage;
                if (adjustedAmount == 0)
                {
                    throw new BasicBlankException($"The damage cannot be 0 for siege ranged since originally was not 0.  attacking unit {attackingUnit.UnitName} and defending unit {defendingUnit.UnitName}.  Rethink");
                }
                animationsNeeded = defendingUnit.HitPoints / adjustedAmount;
                results = new AttackResultsModel("Siege Ranged", attackingUnit.FullName, defendingUnit.FullName, adjustedAmount, animationsNeeded);
                output.Add(results);
            }
            return output;
        }

        public async Task InitAsync()
        {
            await _damageService.InitAsync();
            await _animationService.InitAsync();
        }
    }
}