using System.Windows;

namespace LuckDraw.View.Windows
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitializeFrameContent();
        }

        private void InitializeFrameContent()
        {
            this.Frame_1.Content = new View.Pages.Page_Draw1();
        }

        private void MenuItem_File_Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MenuItem_Help_About_Click(object sender, RoutedEventArgs e)
        {
            new View.Windows.About().ShowDialog();
        }
    }
}
