using CommonBasicStandardLibraries.CollectionClasses;
using CommonBasicStandardLibraries.Exceptions;
using Phase5DataLibrary.Helpers;
using Phase5DataLibrary.Models;
namespace Phase5DataLibrary.ViewModels
{
    public class AttackResultsViewModel : IAttackResultsViewModel
    {
        public CustomBasicList<AttackResultsModel> GetAttackResults(CustomBasicList<UpdateUnitStatModel> attackingUnits, CustomBasicList<UpdateUnitStatModel> defendingUnits)
        {
            CustomBasicList<AttackResultsModel> output = new();
            attackingUnits.ForEach(attack =>
            {
                defendingUnits.ForEach(defense =>
                {
                    CustomBasicList<AttackResultsModel> list = GetAttackResults(attack, defense);
                    output.AddRange(list);
                });
            });
            return output;
        }
        private static CustomBasicList<AttackResultsModel> GetAttackResults(UpdateUnitStatModel attackingUnit, UpdateUnitStatModel defendingUnit)
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
            if (attackingUnit.HandDPA != 0)
            {
                //this is hand damage.
                damageCat = EnumDamageType.Hand;
                armorCat = UpdateUnitStatModel.GetDefenseArmorCategory(damageCat);
                armorProtectionPercent = defendingUnit.GetArmorProtection(armorCat);
                if (attackingUnit.BasicUnit.Champion && attackingUnit.BasicUnit.UnitName == "ThrowingAxeman" && armorProtectionPercent > 0)
                {
                    armorProtectionPercent *= .6;
                }
                armorProtectionAmount = armorProtectionPercent * attackingUnit.HandDPA;
                dpaMinusArmor = attackingUnit.HandDPA - armorProtectionAmount;
                adjustedAmount = dpaMinusArmor * bonusPecentage;
                if (adjustedAmount == 0)
                {
                    throw new BasicBlankException($"The damage cannot be 0 for hand dpa since originally was not 0.  attacking unit {attackingUnit.BasicUnit.UnitName} and defending unit {defendingUnit.BasicUnit.UnitName}.  Rethink");
                }
                animationsNeeded = defendingUnit.HitPoints / adjustedAmount;
                results = new AttackResultsModel("Hand", attackingUnit.FullName, defendingUnit.FullName, adjustedAmount, animationsNeeded);
                output.Add(results);
            }
            if (attackingUnit.CavalryDPA != 0)
            {
                //this is cav damage.
                damageCat = EnumDamageType.Cavaltry;
                armorCat = UpdateUnitStatModel.GetDefenseArmorCategory(damageCat);
                armorProtectionPercent = defendingUnit.GetArmorProtection(armorCat);
                armorProtectionAmount = armorProtectionPercent * attackingUnit.CavalryDPA;
                dpaMinusArmor = attackingUnit.CavalryDPA - armorProtectionAmount;
                adjustedAmount = dpaMinusArmor * bonusPecentage;
                if (adjustedAmount == 0)
                {
                    throw new BasicBlankException($"The damage cannot be 0 for cav dpa since originally was not 0.  attacking unit {attackingUnit.BasicUnit.UnitName} and defending unit {defendingUnit.BasicUnit.UnitName}.  Rethink");
                }
                animationsNeeded = defendingUnit.HitPoints / adjustedAmount;
                results = new AttackResultsModel("Cavalry", attackingUnit.FullName, defendingUnit.FullName, adjustedAmount, animationsNeeded);
                output.Add(results);
            }
            if (attackingUnit.RangedDPA != 0)
            {
                //this is range damage
                damageCat = EnumDamageType.Ranged;
                armorCat = UpdateUnitStatModel.GetDefenseArmorCategory(damageCat);
                armorProtectionPercent = defendingUnit.GetArmorProtection(armorCat);
                armorProtectionAmount = armorProtectionPercent * attackingUnit.RangedDPA;
                dpaMinusArmor = attackingUnit.RangedDPA - armorProtectionAmount;
                adjustedAmount = dpaMinusArmor * bonusPecentage;
                if (adjustedAmount == 0)
                {
                    throw new BasicBlankException($"The damage cannot be 0 for ranged dpa since originally was not 0.  attacking unit {attackingUnit.BasicUnit.UnitName} and defending unit {defendingUnit.BasicUnit.UnitName}.  Rethink");
                }
                animationsNeeded = defendingUnit.HitPoints / adjustedAmount;
                results = new AttackResultsModel("Ranged", attackingUnit.FullName, defendingUnit.FullName, adjustedAmount, animationsNeeded);
                output.Add(results);
            }
            if (attackingUnit.SiegeMeleeDPA != 0)
            {
                //this is siege melee
                damageCat = EnumDamageType.SiegeMelee;
                armorCat = UpdateUnitStatModel.GetDefenseArmorCategory(damageCat);
                armorProtectionPercent = defendingUnit.GetArmorProtection(armorCat);
                armorProtectionAmount = armorProtectionPercent * attackingUnit.SiegeMeleeDPA;
                dpaMinusArmor = attackingUnit.SiegeMeleeDPA - armorProtectionAmount;
                adjustedAmount = dpaMinusArmor * bonusPecentage;
                if (adjustedAmount == 0)
                {
                    throw new BasicBlankException($"The damage cannot be 0 for siege melle dpa since originally was not 0.  attacking unit {attackingUnit.BasicUnit.UnitName} and defending unit {defendingUnit.BasicUnit.UnitName}.  Rethink");
                }
                animationsNeeded = defendingUnit.HitPoints / adjustedAmount;
                results = new AttackResultsModel("Siege Melee", attackingUnit.FullName, defendingUnit.FullName, adjustedAmount, animationsNeeded);
                output.Add(results);
            }
            if (attackingUnit.SiegeRangedDPA != 0)
            {
                //this is siege ranged.
                damageCat = EnumDamageType.SiegeRanged;
                armorCat = UpdateUnitStatModel.GetDefenseArmorCategory(damageCat);
                armorProtectionPercent = defendingUnit.GetArmorProtection(armorCat);
                armorProtectionAmount = armorProtectionPercent * attackingUnit.SiegeRangedDPA;
                dpaMinusArmor = attackingUnit.SiegeRangedDPA - armorProtectionAmount;
                adjustedAmount = dpaMinusArmor * bonusPecentage;
                if (adjustedAmount == 0)
                {
                    throw new BasicBlankException($"The damage cannot be 0 for siege ranged since originally was not 0.  attacking unit {attackingUnit.BasicUnit.UnitName} and defending unit {defendingUnit.BasicUnit.UnitName}.  Rethink");
                }
                animationsNeeded = defendingUnit.HitPoints / adjustedAmount;
                results = new AttackResultsModel("Siege Ranged", attackingUnit.FullName, defendingUnit.FullName, adjustedAmount, animationsNeeded);
                output.Add(results);
            }
            return output;
        }
        
    }
}