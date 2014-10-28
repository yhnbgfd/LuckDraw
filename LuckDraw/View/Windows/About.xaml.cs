using System.Windows;

namespace LuckDraw.View.Windows
{
    public partial class About : Window
    {
        public About()
        {
            InitializeComponent();
            this.Label_Version.Content += Application.ResourceAssembly.GetName().Version.ToString();
        }
    }
}
