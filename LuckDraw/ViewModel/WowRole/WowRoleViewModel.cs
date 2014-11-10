using System;
using System.Collections.Generic;
using System.Linq;

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

        public void InitList(ref List<string> occupation, ref List<string> race, ref List<string> gender)
        {
            InitList_Occupation(ref occupation);
            InitList_Race(ref race);
            InitList_Gender(ref gender);
        }

        public void InitList_Occupation(ref List<string> occupation)
        {
            occupation.Clear();
            foreach (string str in Enum.GetNames(typeof(Models.WowRole.Enum_WowRole.Enum_Occupation)))
            {
                occupation.Add(str);
            }
        }

        public void InitList_Race(ref List<string> race)
        {
            race.Clear();
            foreach (string str in Enum.GetNames(typeof(Models.WowRole.Enum_WowRole.Enum_Race)))
            {
                race.Add(str);
            }
        }

        public void InitList_Gender(ref List<string> gender)
        {
            gender.Clear();
            gender.Add("男");
            gender.Add("女");
        }
    }
}
