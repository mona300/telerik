using System.Windows;
using Telerik.Windows.Controls.Map;

namespace ProvidersBingMapProvider
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string bingMapsKey = this.BingMapsKey.Text;

            BingRestMapProvider bingMap = new BingRestMapProvider(MapMode.Aerial, true, bingMapsKey);
            this.radMap.Provider = bingMap;
        }
    }
}
