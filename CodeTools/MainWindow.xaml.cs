using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using CodeTools;
using Wpf.Controls;
using System.Reflection;

namespace CodeTools
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            InitMenuTree();
        }

        private void InitMenuTree()
        {
            PublicParams.ocCatalogsOfTree.Add(new Catalog("Grid代码生成", "ucGridCode", 1));
            PublicParams.ocCatalogsOfTree.Add(new Catalog("类代码生成", "ucClassCode", 1));
            PublicParams.ocCatalogsOfTree.Add(new Catalog("颜色拾取器", "ucColorPicker", 1));

            //tvMenu.ItemsSource = PublicParams.ocCatalogsOfTree;
            foreach (Catalog catalog in PublicParams.ocCatalogsOfTree)
            {
                TreeViewItem tvi = new TreeViewItem() { Header=catalog.Header,Tag=catalog.Tag ,  };
                tvi.MouseDoubleClick += tvi_MouseDoubleClick;
                tvMenu.Items.Add(tvi);
            }
        }

        void tvi_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                TreeViewItem tvi = sender as TreeViewItem;

                AddNewTabByUC(tvi.Tag.ToString(), tvi.Header.ToString());
            }
            catch (Exception)
            {
            }
        }

        private void AddNewTabByUC(string strUC,string tabHeader)
        {
            if (IsTabExist(tabHeader))
                return;

            Type type = this.GetType();
            Assembly assembly = type.Assembly;
            try
            {
                UserControl uc = (UserControl)assembly.CreateInstance(type.Namespace + ".parts." + strUC);
                BitmapImage image = new BitmapImage(new Uri("images\\logoJovian.png", UriKind.Relative));
                Image img = new Image() { Source = image, Width = 16, Height = 16, Margin = new Thickness(2, 0, 2, 0) };

                TextBlock tb = new TextBlock() { Text = tabHeader, TextTrimming = TextTrimming.CharacterEllipsis, TextWrapping = TextWrapping.NoWrap };

                Wpf.Controls.TabItem ti = new Wpf.Controls.TabItem() { Icon = img, Header = tb, Content = uc };
                tabControl.Items.Add(ti);
            }
            catch (Exception)
            {
                MessageBox.Show("不能添加！");
            }
            

            
        }

        private bool IsTabExist(string tabHeader)
        {
            bool result = false;
            foreach (Wpf.Controls.TabItem ti in tabControl.Items)
            {
                if ((ti.Header as TextBlock).Text == tabHeader)
                {
                    result = true;
                    ti.Focus();
                    break;
                }
            }
            return result;
        }
    }
}
