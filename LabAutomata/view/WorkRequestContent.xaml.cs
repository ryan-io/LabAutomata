using System.Windows;
using System.Windows.Controls;

namespace LabAutomata.view {
    /// <summary>
    /// Interaction logic for WorkRequestContent.xaml
    /// </summary>
    public partial class WorkRequestContent : UserControl {
        public WorkRequestContent () {
            InitializeComponent();
        }

        private void OnResized (object sender, SizeChangedEventArgs e) {
            ListView listView = sender as ListView;
            GridView gView = listView.View as GridView;

            var workingWidth = listView.ActualWidth - SystemParameters.VerticalScrollBarWidth; // take into account vertical scrollbar
            var col1 = 0.10;
            var col2 = 0.15;
            var col3 = 0.10;
            var col4 = 0.10;
            var col5 = 0.25;
            var col6 = 0.10;

            gView.Columns[0].Width = workingWidth * col1;
            gView.Columns[1].Width = workingWidth * col2;
            gView.Columns[2].Width = workingWidth * col3;
            gView.Columns[3].Width = workingWidth * col4;
            gView.Columns[4].Width = workingWidth * col5;
            gView.Columns[5].Width = workingWidth * col6;
        }
    }
}
