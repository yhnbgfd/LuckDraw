using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace LuckDraw.View.Pages
{
    public partial class Page_Draw1 : Page
    {
        string[] _drawList = new string[0];
        List<string> _drawResultList = new List<string>();
        bool _isAllowDuplicateWinning = true;

        public Page_Draw1()
        {
            InitializeComponent();
        }

        private void Button_Draw_Click(object sender, RoutedEventArgs e)
        {
            if (_drawList.Length == 0)
            {
                MessageBox.Show("参奖者列表不能为空。");
                return;
            }
            Random rd = new Random();
            string result = _drawList[rd.Next(0, _drawList.Length)];
            if (!_isAllowDuplicateWinning)
            {
                if (_drawResultList.Count() >= _drawList.Length)
                {
                    MessageBox.Show("所有参奖者都已中奖。");
                    return;
                }
                while ((from item in _drawResultList where item == result select item).Count() > 0)
                {
                    result = _drawList[rd.Next(0, _drawList.Length)];
                }
            }
            this.TextBox_Result.Text += result + "\n";
            this.TextBox_Result.ScrollToEnd();
            _drawResultList.Add(result);
        }

        private void Button_ClearResult_Click(object sender, RoutedEventArgs e)
        {
            this.TextBox_Result.Clear();
            _drawResultList.Clear();
        }

        private void CheckBox_AllowDuplicateWinning_Click(object sender, RoutedEventArgs e)
        {
            _isAllowDuplicateWinning = (bool)this.CheckBox_AllowDuplicateWinning.IsChecked;
            Button_ClearResult_Click(null, null);
        }

        private void TextBox_List_SelectionChanged(object sender, RoutedEventArgs e)
        {
            _drawList = this.TextBox_List.Text.Trim().Split('\n');
        }
    }
}
