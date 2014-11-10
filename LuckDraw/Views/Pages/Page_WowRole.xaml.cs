using LuckDraw.Models.WowRole;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace LuckDraw.View.Pages
{
    public partial class Page_WowRole : Page
    {
        private List<string> _occupation = new List<string>();
        private List<string> _race = new List<string>();
        private List<string> _gender = new List<string>();

        public Page_WowRole()
        {
            InitializeComponent();
            InitializeCheckBox();
        }

        private void InitializeCheckBox()
        {
            this.CheckBox_Occupation.IsChecked = true;
            CheckBox_Occupation_Click(null, null);
        }

        private void FilterRace()
        {
            int race = 0;
            var fields = typeof(Enum_WowRole.Enum_Occupation).GetFields();
            foreach (var f in fields)
            {
                if (_occupation.Contains(f.Name))
                {
                    Enum_WowRole.Enum_Occupation t = (Enum_WowRole.Enum_Occupation)Enum.Parse(typeof(Enum_WowRole.Enum_Occupation), f.Name);
                    race = race | t.GetHashCode();
                }
            }
            string strf = Convert.ToString(race, 2);
            int i = 0;
            foreach (var c in strf)
            {
                if (i == 0)
                {
                    i++;
                    continue;
                }
                CheckBox cb = (CheckBox)this.StackPanel_Race.FindName("CheckBox_Race_" + i);
                if (c == '0')
                {
                    cb.IsChecked = false;
                    cb.IsEnabled = false;
                    _race.Remove(cb.Content.ToString());
                }
                else
                {
                    cb.IsEnabled = true;
                    cb.IsChecked = true;
                    if (!_race.Contains(cb.Content.ToString()))
                    {
                        _race.Add(cb.Content.ToString());
                    }
                }
                i++;
            }
        }

        private void Button_Start_Click(object sender, RoutedEventArgs e)
        {
            this.Label_Result.Content = new ViewModel.WowRole.WowRoleViewModel().Roll(_occupation, _race, _gender);
        }

        private void CheckBox_Occupation_Click(object sender, RoutedEventArgs e)
        {
            bool isCheck = (bool)this.CheckBox_Occupation.IsChecked;
            foreach (var item in this.StackPanel_Occupation.Children)
            {
                if (item.GetType() == typeof(CheckBox))
                {
                    ((CheckBox)item).IsChecked = isCheck;
                }
            }
            if (isCheck)
            {
                new ViewModel.WowRole.WowRoleViewModel().InitList_Occupation(ref _occupation);
            }
            else
            {
                _occupation.Clear();
            }
        }

        private void CheckBox_Race_Click(object sender, RoutedEventArgs e)
        {
            bool isCheck = (bool)this.CheckBox_Race.IsChecked;
            foreach (var item in this.StackPanel_Race.Children)
            {
                if (item.GetType() == typeof(CheckBox) && ((CheckBox)item).IsEnabled == true)
                {
                    ((CheckBox)item).IsChecked = isCheck;
                }
            }
            if (isCheck)
            {
                new ViewModel.WowRole.WowRoleViewModel().InitList_Race(ref _race);
            }
            else
            {
                _race.Clear();
            }
        }

        private void CheckBox_Gender_Click(object sender, RoutedEventArgs e)
        {
            bool isCheck = (bool)this.CheckBox_Gender.IsChecked;
            foreach (var item in this.StackPanel_Gender.Children)
            {
                if (item.GetType() == typeof(CheckBox))
                {
                    ((CheckBox)item).IsChecked = isCheck;
                }
            }
            if (isCheck)
            {
                new ViewModel.WowRole.WowRoleViewModel().InitList_Gender(ref _gender);
            }
            else
            {
                _gender.Clear();
            }
        }

        private void CheckBox_Occupation_Details_Click(object sender, RoutedEventArgs e)
        {
            bool isCheck = (bool)(sender as CheckBox).IsChecked;
            string content = (sender as CheckBox).Content.ToString();
            if (isCheck && !_occupation.Contains(content))
            {
                _occupation.Add(content);
            }
            else
            {
                _occupation.Remove(content);
            }
            FilterRace();
        }

        private void CheckBox_Race_Details_Click(object sender, RoutedEventArgs e)
        {
            bool isCheck = (bool)(sender as CheckBox).IsChecked;
            string content = (sender as CheckBox).Content.ToString();
            if (isCheck && !_race.Contains(content))
            {
                _race.Add(content);
            }
            else
            {
                _race.Remove(content);
            }
        }

        private void CheckBox_Gender_Details_Click(object sender, RoutedEventArgs e)
        {
            bool isCheck = (bool)(sender as CheckBox).IsChecked;
            string content = (sender as CheckBox).Content.ToString();
            if (isCheck && !_gender.Contains(content))
            {
                _gender.Add(content);
            }
            else
            {
                _gender.Remove(content);
            }
        }
    }
}
