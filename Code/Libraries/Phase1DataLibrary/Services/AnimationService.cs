﻿using CommonBasicStandardLibraries.AdvancedGeneralFunctionsAndProcesses.BasicExtensions;
using CommonBasicStandardLibraries.CollectionClasses;
using CommonBasicStandardLibraries.Exceptions;
using Phase1DataLibrary.Models;
using System.Linq;
using System.Threading.Tasks;
namespace Phase1DataLibrary.Services
{
    public class AnimationService : IAnimationService
    {
        public CustomBasicList<double> GetAttackAnimations(AttackUnitModel unit, EnumDamageType damage)
        {
            CustomBasicList<double> possibleAttacks = new CustomBasicList<double>()
            {
                unit.HandDPS,
                unit.CavalryDPS,
                unit.RangedDPS,
                unit.SiegeMeleeDPS,
                unit.SiegeRangedDPS
            };
            possibleAttacks.RemoveAllAndObtain(xxx => xxx == 0);
            if (possibleAttacks.Count <= 1)
            {
                return unit.AnimationDurations.ToCustomBasicList();
            }

            //when i get to champions, will change the formulas.

            //this means exceptions.
            if (possibleAttacks.Count == 2)
            {
                if (unit.UnitName != "Immortal")
                {
                    throw new BasicBlankException("Immortals should be the only one with 2 attacks.  If that is wrong, needs to account for");
                }
                if (unit.AnimationDurations.Count != 4)
                {
                    throw new BasicBlankException("The immortals should have had 4 animation durations.");
                }
                if (damage == EnumDamageType.Hand)
                {
                    return unit.AnimationDurations.Take(2).ToCustomBasicList();
                }
                if (damage == EnumDamageType.Ranged)
                {
                    return unit.AnimationDurations.Skip(2).Take(2).ToCustomBasicList();
                }
                return new CustomBasicList<double>(); //nothing else left.
            }
            if (possibleAttacks.Count == 3)
            {
                //this means villagers.
                //for now, hard code.
                if (unit.UnitName != "Villager")
                {
                    throw new BasicBlankException("Only villagers should have 3 possible attacks.  If we ever have another unit with 3 attacks, something else has to be done");
                }
                if (unit.AnimationDurations.Count == 5)
                {
                    //this accounts for cases where there are 5 animations
                    if (damage == EnumDamageType.Hand)
                    {
                        return unit.AnimationDurations.Take(2).ToCustomBasicList();
                    }
                    if (damage == EnumDamageType.Ranged)
                    {
                        return unit.AnimationDurations.Skip(3).Take(2).ToCustomBasicList();
                    }
                    if (damage == EnumDamageType.SiegeMelee)
                    {
                        return unit.AnimationDurations.Skip(2).Take(1).ToCustomBasicList();
                    }
                    return new CustomBasicList<double>();
                }
                if (unit.AnimationDurations.Count == 8)
                {
                    if (damage == EnumDamageType.Hand)
                    {
                        return unit.AnimationDurations.Skip(3).Take(2).ToCustomBasicList();
                    }
                    if (damage == EnumDamageType.Ranged)
                    {
                        return unit.AnimationDurations.Skip(5).Take(3).ToCustomBasicList();
                    }
                    if (damage == EnumDamageType.SiegeMelee)
                    {
                        return unit.AnimationDurations.Skip(2).Take(1).ToCustomBasicList();
                    }
                    return new CustomBasicList<double>();
                }
                throw new BasicBlankException("Must have either 5 or 8 animations for villagers.  If wrong, then needs to add more conditions");
            }
            throw new BasicBlankException("Only 1, 2 or 3 possible attacks are supported.   If more are needed, then needs to add more conditions");
        }
        public Task InitAsync()
        {
            return Task.CompletedTask; //this version will not get data from a database.
        }
    }
}