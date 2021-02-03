using CommonBasicStandardLibraries.CollectionClasses;
using Newtonsoft.Json;
using System.Linq;
namespace Phase1DataLibrary.Models
{
    public class AttackUnitModel
    {
        public string UnitName { get; set; } = "";
        public string Civilization { get; set; } = "";
        public CustomBasicList<double> AnimationDurations { get; set; } = new CustomBasicList<double>();
        public double? HandDPS { get; set; }
        public double? CavalryDPS { get; set; }
        public double? RangedDPS { get; set; }
        public double? SiegeMeleeDPS { get; set; }
        public double? SiegeRangedDPS { get; set; }
        [JsonIgnore]
        public double? HandDPA => HandDPS.HasValue == false ? null : GetDPA(HandDPS.Value);
        [JsonIgnore]
        public double? CavalryDPA => CavalryDPS.HasValue == false ? null : GetDPA(CavalryDPS.Value);
        [JsonIgnore]
        public double? RangedDPA => RangedDPS.HasValue == false ? null : GetDPA(RangedDPS.Value);
        [JsonIgnore]
        public double? SiegeMeleeDPA => SiegeMeleeDPS.HasValue == false ? null : GetDPA(SiegeMeleeDPS.Value);
        [JsonIgnore]
        public double? SiegeRangedDPA => SiegeRangedDPS.HasValue == false ? null : GetDPA(SiegeRangedDPS.Value);
        private double GetDPA(double damage)
        {
            double dps = damage;
            double sumAttacks = AnimationDurations.Sum();
            double totalAttacks = AnimationDurations.Count;
            double subs = dps * sumAttacks;
            return subs / totalAttacks;
        }
    }
}