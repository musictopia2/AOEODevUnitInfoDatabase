using CommonBasicStandardLibraries.CollectionClasses;
using Phase5DataLibrary.Containers;
using Phase5DataLibrary.Helpers;
using Phase5DataLibrary.Models;
using System;
using System.Linq;
namespace Phase5DataLibrary.Services
{
    public class CalculateUnitStatService : ICalculateUnitStatService
    {
        private readonly TechListContainer _techContainer;
        private readonly IAnimationService _animationService;
        private readonly IDamageExceptionService _dService;

        //this could require the view model for the techs for the data.
        //however, if that also requires the calculateunitstat, then overflows.
        //this is where i may need a container for techs.

        public CalculateUnitStatService(TechListContainer techContainer, IAnimationService animationService, IDamageExceptionService dService)
        {
            _techContainer = techContainer;
            _animationService = animationService;
            _dService = dService;
        }
        public CustomBasicList<UpdateUnitStatModel> GetCalculatedAttackUnits(CustomBasicList<UnitModel> attackUnits)
        {
            CustomBasicList<UpdateUnitStatModel> output = new();
            attackUnits.ForEach(old =>
            {
                UpdateUnitStatModel unit = new();
                unit.BasicUnit = old;
                unit.OriginalUnit = old;
                output.Add(unit);
            });
            RecalculateAttackUnits(output);
            return output;
        }
        public CustomBasicList<UpdateUnitStatModel> GetCalculatedDefenseUnits(CustomBasicList<UnitModel> defenseUnits)
        {
            CustomBasicList<UpdateUnitStatModel> output = new();
            defenseUnits.ForEach(old =>
            {
                UpdateUnitStatModel unit = new();
                unit.BasicUnit = old;
                unit.OriginalUnit = old;
                output.Add(unit);
            });
            RecalculateDefenseUnits(output);
            return output;
        }
        private void CalculateDPA(CustomBasicList<UpdateUnitStatModel> units)
        {
            units.ForEach(unit =>
            {
                unit.ChargeDPA = unit.HandDPS > 0 ? GetDPA(unit, unit.HandDPS, EnumDamageType.Charge) : GetDPA(unit, unit.CavalryDPS, EnumDamageType.Charge);
                unit.CavalryDPA = GetDPA(unit, unit.CavalryDPS, EnumDamageType.Cavaltry);
                unit.HandDPA = GetDPA(unit, unit.HandDPS, EnumDamageType.Hand);
                unit.RangedDPA = GetDPA(unit, unit.RangedDPS, EnumDamageType.Ranged);
                unit.SiegeMeleeDPA = GetDPA(unit, unit.SiegeMeleeDPS, EnumDamageType.SiegeMelee);
                unit.SiegeRangedDPA = GetDPA(unit, unit.SiegeRangedDPS, EnumDamageType.SiegeRanged);
            });
        }
        private double GetDPA(UpdateUnitStatModel unit, double damage, EnumDamageType category)
        {
            double dps = _dService.GetDamage(unit, damage, category);
            double charge = _animationService.GetChargeDamage(unit);
            CustomBasicList<double> animations = _animationService.GetAttackAnimations(unit, category, charge);
            if (animations.Count == 0)
            {
                return 0;
            }
            double sumAttacks = animations.Sum();
            double totalAttacks = animations.Count;
            double subs = dps * sumAttacks;
            double output = subs / totalAttacks;
            if (charge > 0 && category == EnumDamageType.Charge)
            {
                output *= charge;
            }
            output = Math.Round(output, 4);
            return output;
        }
        public void RecalculateAttackUnits(CustomBasicList<UpdateUnitStatModel> attackUnits)
        {
            attackUnits.ForEach(unit =>
            {
                StartAttackingUnit(unit);
            });
            AttackTechs(attackUnits); //if there are none, would not apply anything.
            CalculateDPA(attackUnits);
        }
        private void AttackTechs(CustomBasicList<UpdateUnitStatModel> units)
        {
            units.ForEach(unit =>
            {
                _techContainer.AttackSelectedTechList.ForEach(tech =>
                {
                    unit.ApplyAttackTech(tech);
                });
            });
        }
        private void DefenseTechs(CustomBasicList<UpdateUnitStatModel> units)
        {
            units.ForEach(unit =>
            {
                _techContainer.DefenseSelectedTechList.ForEach(tech =>
                {
                    unit.ApplyDefenseTech(tech);
                });
            });
        }
        public void RecalculateDefenseUnits(CustomBasicList<UpdateUnitStatModel> defenseUnits)
        {
            defenseUnits.ForEach(unit =>
            {
                StartDefendingUnit(unit);
            });
            DefenseTechs(defenseUnits); //in this case, this is it.
        }
        private static void StartDefendingUnit(UpdateUnitStatModel unit)
        {
            unit.ArmorCavalry = unit.OriginalUnit.ArmorCavalry;
            unit.ArmorHand = unit.OriginalUnit.ArmorHand;
            unit.ArmorRanged = unit.OriginalUnit.ArmorRanged;
            unit.ArmorSiege = unit.OriginalUnit.ArmorSiege;
            unit.HitPoints = unit.OriginalUnit.HitPoints;
        }
        private static void StartAttackingUnit(UpdateUnitStatModel unit)
        {
            unit.CavalryDPS = unit.OriginalUnit.CavalryDPS;
            unit.DamageBonusAbstractArcher = unit.OriginalUnit.DamageBonusAbstractArcher;
            unit.DamageBonusAbstractArtillery = unit.OriginalUnit.DamageBonusAbstractArtillery;
            unit.DamageBonusAbstractCavalry = unit.OriginalUnit.DamageBonusAbstractInfantry;
            unit.DamageBonusAbstractPriest = unit.OriginalUnit.DamageBonusAbstractPriest;
            unit.DamageBonusBuilding = unit.OriginalUnit.DamageBonusBuilding;
            unit.DamageBonusGr_Cav_Sarissophoroi = unit.OriginalUnit.DamageBonusGr_Cav_Sarissophoroi;
            unit.DamageBonusShip = unit.OriginalUnit.DamageBonusShip;
            unit.DamageBonusUnitTypeBldgStorehouse = unit.OriginalUnit.DamageBonusUnitTypeBldgStorehouse;
            unit.DamageBonusUnitTypeVillager = unit.OriginalUnit.DamageBonusUnitTypeVillager;
            unit.HandDPS = unit.OriginalUnit.HandDPS;
            unit.RangedDPS = unit.OriginalUnit.RangedDPS;
            unit.SiegeMeleeDPS = unit.OriginalUnit.SiegeMeleeDPS;
            unit.SiegeRangedDPS = unit.OriginalUnit.SiegeRangedDPS;
        }
    }
}