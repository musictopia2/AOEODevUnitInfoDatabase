using CommonBasicStandardLibraries.CollectionClasses;
using Newtonsoft.Json;
using Phase1DataLibrary.Services;
using System;
using System.Linq;
namespace Phase1DataLibrary.Models
{
    public class AttackUnitModel
    {
        public bool Champion { get; set; } //this is now brand new.
        public string UnitName { get; set; } = "";
        [JsonIgnore]
        public string FullName => Champion == false ? $"{Civilization} {UnitName}" : $"{Civilization} {UnitName} Champion"; //this means it can do other parts this time.
        public int HandStartAt { get; set; } = 1; //usually starts at 1.
        public int SiegeStartAt { get; set; } = 1;
        public int RangedStartAt { get; set; } = 1;
        public string Civilization { get; set; } = "";
        public CustomBasicList<double> AnimationDurations { get; set; } = new CustomBasicList<double>();
        public double HandDPS { get; set; }
        public double CavalryDPS { get; set; }
        public double RangedDPS { get; set; }
        public double SiegeMeleeDPS { get; set; }
        public double SiegeRangedDPS { get; set; }
        public double HandDPA(IAnimationService service) => GetDPA(service, HandDPS, EnumDamageType.Hand);
        public double CavalryDPA(IAnimationService service) => GetDPA(service, CavalryDPS, EnumDamageType.Cavaltry);
        public double RangedDPA(IAnimationService service) => GetDPA(service, RangedDPS, EnumDamageType.Ranged);
        public double SiegeMeleeDPA(IAnimationService service) => GetDPA(service, SiegeMeleeDPS, EnumDamageType.SiegeMelee);
        public double SiegeRangedDPA(IAnimationService service) => GetDPA(service, SiegeRangedDPS, EnumDamageType.SiegeRanged);
        public double ChargeDPA(IAnimationService service) => GetDPA(service, HandDPS, EnumDamageType.Charge);
        private double GetDPA(IAnimationService service, double damage, EnumDamageType category)
        {
            double dps = damage;
            double charge = service.GetChargeDamage(this);
            CustomBasicList<double> animations = service.GetAttackAnimations(this, category, charge);
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
    }
}