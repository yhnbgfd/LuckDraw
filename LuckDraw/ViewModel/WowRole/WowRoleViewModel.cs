using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LuckDraw.ViewModel.WowRole
{
    class WowRoleViewModel
    {
        public string Roll(List<string> occupation, List<string> race, List<string> gender)
        {
            string result = "";
            Random rd = new Random();
            if (occupation.Count() > 0)
            {
                result += occupation[rd.Next(0, occupation.Count())];
            }
            if (race.Count() > 0)
            {
                result += " " + race[rd.Next(0, race.Count())];
            }
            if (gender.Count() > 0)
            {
                result += " " + gender[rd.Next(0, gender.Count())];
            }
            return result;
        }

        public void InitDictionary(ref List<string> occupation, ref List<string> race, ref List<string> gender)
        {
            foreach (string str in Enum.GetNames(typeof(Models.WowRole.Enum_WowRole.Enum_Occupation)))
            {
                occupation.Add(str);
            }
            foreach (string str in Enum.GetNames(typeof(Models.WowRole.Enum_WowRole.Enum_Race)))
            {
                race.Add(str);
            }
            gender.Add("男");
            gender.Add("女");
        }

    }
}
