namespace Phase5DataLibrary.Models
{
    public record AttackResultsModel(string DamageTypeString, string AttackingUnit, string DefendingUnit, double ChargeDamage, double TrueDPA, double NumberOfAnimations);
}