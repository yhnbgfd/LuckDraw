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
            this.Frame_1.Content = new View.Pages.Page_多选一();
        }

        private void MenuItem_File_Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
