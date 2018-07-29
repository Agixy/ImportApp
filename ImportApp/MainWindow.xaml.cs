using System.Windows;
using Microsoft.Win32;


namespace ImportApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ImportInitializer importInitializer = new ImportInitializer();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ImportButton_Click(object sender, RoutedEventArgs e)
        {
            var path = ChooseFile();
            try
            {
                importInitializer.Start(path);
            }
            catch (PeselInputException x)
            {
                MessageBox.Show(x.Message);             
            }
        }

        private string ChooseFile()
        {
            var fileDialog = new OpenFileDialog { Filter = "Excel files|*.xls;*.xlsx;*.xlsm" };
            string path = null;
            if (fileDialog.ShowDialog() == true)
            {
                path = fileDialog.FileName;
            }
            return path;
        }
       
    }
}

