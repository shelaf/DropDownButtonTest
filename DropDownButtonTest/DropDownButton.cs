using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;

namespace DropDownButtonTest
{
    /// <summary>
    /// ドロップダウンコントロール
    /// </summary>
    public class DropDownButton : ToggleButton
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public DropDownButton()
        {
            Binding binding = new Binding("Menu.IsOpen") { Source = this };
            SetBinding(IsCheckedProperty, binding);
            DataContextChanged += (sender, args) =>
            {
                if (Menu != null)
                {
                    Menu.DataContext = DataContext;
                }
            };
        }

        /// <summary>
        /// コンテキストメニューの取得・設定
        /// </summary>
        public ContextMenu Menu
        {
            get { return GetValue(MenuProperty) as ContextMenu; }
            set { SetValue(MenuProperty, value); }
        }

        /// <summary>
        /// コンテキストメニュー表すプロパティ
        /// </summary>
        public static readonly DependencyProperty MenuProperty = DependencyProperty.Register("Menu", typeof(ContextMenu), typeof(DropDownButton), new UIPropertyMetadata(null, OnMenuChanged));

        /// <summary>
        /// コンテキストメニュープロパティ変更時の処理
        /// </summary>
        /// <param name="d">ドロップダウンボタン</param>
        /// <param name="e">コンテキストメニュープロパティ変更イベントデータ</param>
        private static void OnMenuChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DropDownButton dropDownButton = d as DropDownButton;
            ContextMenu contextMenu = e.NewValue as ContextMenu;
            if (contextMenu != null)
            {
                contextMenu.DataContext = dropDownButton.DataContext;
            }
        }

        /// <summary>
        /// ドロップダウンボタンクリック時の処理
        /// </summary>
        protected override void OnClick()
        {
            if (Menu != null)
            {
                Menu.PlacementTarget = this;
                Menu.Placement = PlacementMode.Bottom;
                Menu.IsOpen = true;
            }
        }
    }
}
