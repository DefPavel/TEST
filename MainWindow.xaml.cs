using Squirrel;
using System.Windows;

namespace TEST
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private UpdateManager manager;

        public MainWindow()
        {
            InitializeComponent();

            
        }
        private async void CheckForUpdatesButton_Click(object sender, RoutedEventArgs e)
        {
            var updateInfo = await manager.CheckForUpdate();

            if (updateInfo.ReleasesToApply.Count > 0)
            {
                    UpdateButton.IsEnabled = true;
            }
            else
            {
                    UpdateButton.IsEnabled = false;
            }
        }

        private async void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            await manager.UpdateApp();

            MessageBox.Show("Updated succesfuly!");
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            manager = await UpdateManager.GitHubUpdateManager(@"https://github.com/DefPavel/TEST");

            CurrentVersionTextBox.Text = manager.CurrentlyInstalledVersion().ToString();

        }  
           
     

    }
}
