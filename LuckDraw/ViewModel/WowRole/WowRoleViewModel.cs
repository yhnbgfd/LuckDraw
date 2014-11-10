using LuckDraw.Models.WowRole;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LuckDraw.ViewModel.WowRole
{
    class WowRoleViewModel
    {
        public Model_WowRole Roll(List<string> occupation, List<string> race, List<string> gender)
        {
            Random rd = new Random();
            Model_WowRole role = new Model_WowRole();
            if (occupation.Count() > 0)
            {
                role.Occupation = occupation[rd.Next(0, occupation.Count())];
            }
            if (race.Count() > 0)
            {
                role.Race = race[rd.Next(0, race.Count())];
                while (!Models.WowRole.Data_WowRole.OccupationRace[role.Occupation].Contains(role.Race))//如果该种族不合理，重新roll直到合理
                {
                    race.Remove(role.Race);
                    if (race.Count() == 0)
                    {
                        role.Race = "";
                        break;
                    }
                    role.Race = race[rd.Next(0, race.Count())];
                }
            }
            if (gender.Count() > 0)
            {
                role.Gender = gender[rd.Next(0, gender.Count())];
            }
            return role;
        }

    }
}
