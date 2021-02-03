using CommonBasicStandardLibraries.CollectionClasses;
using Newtonsoft.Json;
using Phase1DataLibrary.Services;
using System.Linq;
namespace Phase1DataLibrary.Models
{
    public class AttackUnitModel
    {
        public string UnitName { get; set; } = "";
        [JsonIgnore]
        public string FullName => $"{Civilization} {UnitName}"; //this means it can do other parts this time.

        public int HandStartAt { get; set; } = 1; //usually starts at 1.
        public int SiegeStartAt { get; set; } = 1;
        public int RangedStartAt { get; set; } = 1;


        //public string FullName { get; set; } = ""; //needs the full name as well now.
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
        public double SIegeRangedDPA(IAnimationService service) => GetDPA(service, SiegeRangedDPS, EnumDamageType.SiegeRanged);


        //[JsonIgnore]
        //public double? HandDPA => HandDPS.HasValue == false ? null : GetDPA(HandDPS.Value, EnumDamageType.Hand);
        //[JsonIgnore]
        //public double? CavalryDPA => CavalryDPS.HasValue == false ? null : GetDPA(CavalryDPS.Value, EnumDamageType.Cavaltry);
        //[JsonIgnore]
        //public double? RangedDPA => RangedDPS.HasValue == false ? null : GetDPA(RangedDPS.Value, EnumDamageType.Ranged);
        //[JsonIgnore]
        //public double? SiegeMeleeDPA => SiegeMeleeDPS.HasValue == false ? null : GetDPA(SiegeMeleeDPS.Value, EnumDamageType.SiegeMelee);
        //[JsonIgnore]
        //public double? SiegeRangedDPA => SiegeRangedDPS.HasValue == false ? null : GetDPA(SiegeRangedDPS.Value, EnumDamageType.SiegeRanged);




        private double GetDPA(IAnimationService service, double damage, EnumDamageType category)
        {
            double dps = damage;
            CustomBasicList<double> animations = service.GetAttackAnimations(this, category);
            //looks like you can't use di for models.


            double sumAttacks = animations.Sum();
            double totalAttacks = animations.Count;
            double subs = dps * sumAttacks;
            return subs / totalAttacks;
        }
    }
}