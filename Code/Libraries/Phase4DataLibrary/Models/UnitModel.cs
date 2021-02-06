using CommonBasicStandardLibraries.CollectionClasses;
using Newtonsoft.Json;
using Phase4DataLibrary.Services;
using System;
using System.Linq;
namespace Phase4DataLibrary.Models
{
    public class UnitModel
    {
        public bool IsAttacker { get; set; } //this means it can be used for attacking.
        public bool Champion { get; set; }
        public string UnitName { get; set; } = "";
        [JsonIgnore]
        public string FullName => Champion == false ? $"{Civilization} {UnitName}" : $"{Civilization} {UnitName} Champion"; //this means it can do other parts this time.
        public string Civilization { get; set; } = "";
        public CustomBasicList<double> AnimationDurations { get; set; } = new CustomBasicList<double>();
        public double HandDPS { get; set; }
        public double CavalryDPS { get; set; }
        public double RangedDPS { get; set; }
        public double SiegeMeleeDPS { get; set; }
        public double SiegeRangedDPS { get; set; }
        public double BonusDamageProtection { get; set; }
        public double HandDPA(IAnimationService aService, IDamageExceptionService dService) => GetDPA(aService, dService, HandDPS, EnumDamageType.Hand);
        public double CavalryDPA(IAnimationService aService, IDamageExceptionService dService) => GetDPA(aService, dService, CavalryDPS, EnumDamageType.Cavaltry);
        public double RangedDPA(IAnimationService aService, IDamageExceptionService dService) => GetDPA(aService, dService, RangedDPS, EnumDamageType.Ranged);
        public double SiegeMeleeDPA(IAnimationService aService, IDamageExceptionService dService) => GetDPA(aService, dService, SiegeMeleeDPS, EnumDamageType.SiegeMelee);
        public double SiegeRangedDPA(IAnimationService aService, IDamageExceptionService dService) => GetDPA(aService, dService, SiegeRangedDPS, EnumDamageType.SiegeRanged);
        public double ChargeDPA(IAnimationService aService, IDamageExceptionService dService) => HandDPS > 0 ? GetDPA(aService, dService, HandDPS, EnumDamageType.Charge)
            : GetDPA(aService, dService, CavalryDPS, EnumDamageType.Charge);
        private double GetDPA(IAnimationService aService, IDamageExceptionService dService, double damage, EnumDamageType category)
        {
            double dps = dService.GetDamage(this, damage, category);
            double charge = aService.GetChargeDamage(this);
            CustomBasicList<double> animations = aService.GetAttackAnimations(this, category, charge);
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

        //now the target type.
        public double HitPoints { get; set; }
        public double ArmorHand { get; set; }
        public double ArmorCavalry { get; set; }
        public double ArmorRanged { get; set; }
        public double ArmorSiege { get; set; }

        //now extras so the final calculations can be done.
        public string Tags { get; set; } = ""; //this is needed too now for the final calculations.
        public double DamageBonusAbstractinfantry { get; set; }
        public double DamageBonusAbstractArcher { get; set; }
        public double DamageBonusAbstractCavalry { get; set; }
        public double DamageBonusBuilding { get; set; }
        public double DamageBonusShip { get; set; }
        public double DamageBonusAbstractArtillery { get; set; }
        public double DamageBonusAbstractPriest { get; set; }
        public double DamageBonusUnitTypeVillager { get; set; }
        public double DamageBonusGr_Cav_Sarissophoroi { get; set; }
        public double DamageBonusUnitTypeBldgStorehouse { get; set; }
    }
}