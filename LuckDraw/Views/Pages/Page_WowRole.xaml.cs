using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LuckDraw.View.Pages
{
    public partial class Page_WowRole : Page
    {
        public Page_WowRole()
        {
            InitializeComponent();
            InitializeCheckBox();
        }

        private void InitializeCheckBox()
        {
            this.CheckBox_Occupation.IsChecked = true;
            this.CheckBox_Race.IsChecked = true;
            this.CheckBox_Gender.IsChecked = true;
            CheckBox_Occupation_Click(null, null);
            CheckBox_Race_Click(null, null);
            CheckBox_Gender_Click(null, null);
        }

        private void Button_Start_Click(object sender, RoutedEventArgs e)
        {
            this.Label_Result.Content = "德拉诺之王";
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
                if (item.GetType() == typeof(CheckBox))
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
    }
}
