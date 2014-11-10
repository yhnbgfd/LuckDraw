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
            ReadOccupation();

            int race = 0;
            var fields = typeof(Data_WowRole.Enum_Occupation).GetFields();
            foreach (var f in fields)
            {
                if (_occupation.Contains(f.Name))
                {
                    Data_WowRole.Enum_Occupation t = (Data_WowRole.Enum_Occupation)Enum.Parse(typeof(Data_WowRole.Enum_Occupation), f.Name);
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

        private void ReadOccupation()
        {
            _occupation.Clear();
            foreach (var a in this.StackPanel_Occupation.Children)
            {
                if (a.GetType() == typeof(CheckBox) && ((CheckBox)a).IsChecked == true)
                {
                    _occupation.Add(((CheckBox)a).Content.ToString());
                }
            }
        }

        private void ReadRace()
        {
            _race.Clear();
            foreach (var a in this.StackPanel_Race.Children)
            {
                if (a.GetType() == typeof(CheckBox) && ((CheckBox)a).IsChecked == true)
                {
                    _race.Add(((CheckBox)a).Content.ToString());
                }
            }
        }

        private void ReadGender()
        {
            _gender.Clear();
            foreach (var a in this.StackPanel_Gender.Children)
            {
                if (a.GetType() == typeof(CheckBox) && ((CheckBox)a).IsChecked == true)
                {
                    _gender.Add(((CheckBox)a).Content.ToString());
                }
            }
        }

        private void Button_Start_Click(object sender, RoutedEventArgs e)
        {
            ReadOccupation();
            ReadRace();
            ReadGender();

            Model_WowRole result = new ViewModel.WowRole.WowRoleViewModel().Roll(_occupation, _race, _gender);
            this.Label_Result.Content = result.Occupation + " " + result.Race + " " + result.Gender;
            while (result.Occupation.Length < 12)
            {
                result.Occupation += " ";
            }
            while (result.Race.Length < 10)
            {
                result.Race += " ";
            }
            this.TextBox_ResultList.Text += "\n" + result.Occupation + "\t" + result.Race + "\t" + result.Gender;
            this.TextBox_ResultList.ScrollToEnd();
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
        }

        private void CheckBox_Occupation_Details_Click(object sender, RoutedEventArgs e)
        {
            FilterRace();
        }

        private void Button_ClearResultList_Click(object sender, RoutedEventArgs e)
        {
            this.TextBox_ResultList.Text = "Roll号结果：";
            this.Label_Result.Content = "";
        }
    }
}
