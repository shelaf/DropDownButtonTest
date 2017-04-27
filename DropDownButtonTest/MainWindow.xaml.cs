using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace DropDownButtonTest
{
    /// <summary>
    /// メイン画面
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            ObservableCollection<GridData> data = new ObservableCollection<GridData>(
                Enumerable.Range(1, 10).Select(i => new GridData
                {
                    ColumnName = "列名" + i,
                }));
            dataGrid.ItemsSource = data;
        }

        /// <summary>
        /// データグリッドのセルが選択された時の処理
        /// </summary>
        /// <param name="sender">イベント送信元</param>
        /// <param name="e">イベントデータ</param>
        private void DataGrid_GotFocus(object sender, RoutedEventArgs e)
        {
            if (e.OriginalSource.GetType() == typeof(DataGridCell))
            {
                DataGrid grd = (DataGrid)sender;
                grd.BeginEdit(e);
            }
        }
    }
}
