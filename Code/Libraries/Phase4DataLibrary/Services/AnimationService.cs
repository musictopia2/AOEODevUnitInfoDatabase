using CommonBasicStandardLibraries.AdvancedGeneralFunctionsAndProcesses.BasicExtensions;
using CommonBasicStandardLibraries.CollectionClasses;
using CommonBasicStandardLibraries.Exceptions;
using Phase4DataLibrary.Models;
using System.Linq;
using System.Threading.Tasks;
namespace Phase4DataLibrary.Services
{
    public class AnimationService : IAnimationService
    {
        public CustomBasicList<double> GetAttackAnimations(UnitModel unit, EnumDamageType damage, double charge)
        {
            CustomBasicList<double> possibleAttacks = new CustomBasicList<double>()
            {
                unit.HandDPS,
                unit.CavalryDPS,
                unit.RangedDPS,
                unit.SiegeMeleeDPS,
                unit.SiegeRangedDPS
            };
            if (unit.UnitName == "Palintonon" || unit.UnitName == "LogThrower" || unit.UnitName == "StoneThrower")
            {
                possibleAttacks.RemoveAt(3); //for now, remove the mele dps for palins.
                if (damage == EnumDamageType.SiegeMelee)
                    return new CustomBasicList<double>(); //try this way
            }
            possibleAttacks.RemoveAllAndObtain(xxx => xxx == 0);

            if (unit.UnitName == "Sapper")
                //this has exception here too.
                if (damage == EnumDamageType.Hand)
                {
                    if (damage == EnumDamageType.Hand)
                        return unit.AnimationDurations.Take(2).ToCustomBasicList();
                    if (damage == EnumDamageType.SiegeMelee)
                        return unit.AnimationDurations.Skip(2).Take(2).ToCustomBasicList();
                    return new CustomBasicList<double>();
                }

            if (charge > 0)
            {
                if (unit.AnimationDurations.Count != 3)
                    throw new BasicBlankException("There must be 3 total animations if there is charge attack.  If that is wrong, then needs updating");
                if (damage == EnumDamageType.Charge)
                    return unit.AnimationDurations.Skip(2).ToCustomBasicList();
                else
                    return unit.AnimationDurations.Take(2).ToCustomBasicList();
            }
            else if (charge == 0 && damage == EnumDamageType.Charge)
                return new CustomBasicList<double>();
            if (unit.UnitName == "Farbjoðr")
            {
                if (damage == EnumDamageType.SiegeMelee)
                    return unit.AnimationDurations.Skip(2).Take(2).ToCustomBasicList();
                if (unit.Champion == false)
                    return new CustomBasicList<double>();
                if (damage == EnumDamageType.Hand)
                    return unit.AnimationDurations.Take(2).ToCustomBasicList();
                return new();
                //this has an exception.  for champion, will be different.  but we are not there yet.
            }
            if (possibleAttacks.Count <= 1)
                return unit.AnimationDurations.ToCustomBasicList();
            if (possibleAttacks.Count == 2)
            {

                if (unit.UnitName == "SiegeTower")
                {
                    //the babylon siege tower has exceptions.
                    //has 3.
                    if (unit.AnimationDurations.Count != 3)
                        throw new BasicBlankException("The Babylonian Siege Tower Must Have 3 Animation Durations");
                    if (damage == EnumDamageType.SiegeMelee)
                        return unit.AnimationDurations.Take(2).ToCustomBasicList();
                    if (damage == EnumDamageType.Ranged)
                        return unit.AnimationDurations.Skip(2).Take(1).ToCustomBasicList();
                    return new CustomBasicList<double>();
                }
                if (unit.UnitName != "Immortal")
                    throw new BasicBlankException($"Immortals should be the only one with 2 attacks.  If that is wrong, needs to account for.  Unit this time was {unit.UnitName}");
                if (unit.AnimationDurations.Count != 4)
                    throw new BasicBlankException("The immortals should have had 4 animation durations.");
                if (damage == EnumDamageType.Hand)
                    return unit.AnimationDurations.Take(2).ToCustomBasicList();
                if (damage == EnumDamageType.Ranged)
                    return unit.AnimationDurations.Skip(2).Take(2).ToCustomBasicList();
                return new CustomBasicList<double>(); //nothing else left.
            }
            if (possibleAttacks.Count == 3)
            {
                //this means villagers.
                //for now, hard code.
                if (unit.UnitName != "Villager")
                    throw new BasicBlankException("Only villagers should have 3 possible attacks.  If we ever have another unit with 3 attacks, something else has to be done");
                if (unit.AnimationDurations.Count == 5)
                {
                    //this accounts for cases where there are 5 animations
                    if (damage == EnumDamageType.Hand)
                        return unit.AnimationDurations.Take(2).ToCustomBasicList();
                    if (damage == EnumDamageType.Ranged)
                        return unit.AnimationDurations.Skip(3).Take(2).ToCustomBasicList();
                    if (damage == EnumDamageType.SiegeMelee)
                        return unit.AnimationDurations.Skip(2).Take(1).ToCustomBasicList();
                    return new CustomBasicList<double>();
                }
                if (unit.AnimationDurations.Count == 8)
                {
                    if (damage == EnumDamageType.Hand)
                        return unit.AnimationDurations.Skip(3).Take(2).ToCustomBasicList();
                    if (damage == EnumDamageType.Ranged)
                        return unit.AnimationDurations.Skip(5).Take(3).ToCustomBasicList();
                    if (damage == EnumDamageType.SiegeMelee)
                        return unit.AnimationDurations.Take(3).ToCustomBasicList();
                    return new CustomBasicList<double>();
                }
                throw new BasicBlankException("Must have either 5 or 8 animations for villagers.  If wrong, then needs to add more conditions");
            }
            throw new BasicBlankException("Only 1, 2 or 3 possible attacks are supported.   If more are needed, then needs to add more conditions");
        }
        public double GetChargeDamage(UnitModel unit)
        {
            //the lancers champion has 2.75 charge damage.  the woad raiders does 3.  can eventually get from database
            if (unit.UnitName == "WoadRaider")
                return 3.0;
            if (unit.UnitName == "Lancer" && unit.Champion)
                return 2.5;
            return 0.0;
        }
        public Task InitAsync()
        {
            return Task.CompletedTask; //this version will not get data from a database.
        }
    }
}