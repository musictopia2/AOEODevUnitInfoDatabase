﻿using Newtonsoft.Json;

namespace Phase2DataLibrary.Models
{
    public class DefenseUnitModel
    {
        public bool Champion { get; set; } //this is now brand new.
        public string UnitName { get; set; } = "";
        [JsonIgnore]
        public string FullName => Champion == false ? $"{Civilization} {UnitName}" : $"{Civilization} {UnitName} Champion"; //this means it can do other parts this time.
        public string Civilization { get; set; } = "";
        public double DamageBonusProtection { get; set; } //i think.
        public double HitPoints { get; set; }
        public double ArmorHand { get; set; }
        public double ArmorCavalry { get; set; }
        public double ArmorRanged { get; set; }
        public double ArmorSiege { get; set; }
    }
}
