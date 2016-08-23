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

namespace CodeTools.parts
{
    /// <summary>
    /// ucGridCode.xaml 的交互逻辑
    /// </summary>
    public partial class ucGridCode : UserControl
    {
        private StringBuilder sbResult = new StringBuilder();
        public ucGridCode()
        {
            InitializeComponent();
        }


        public string UniqueTabName
        {
            get { return "GridCode"; }
        }

        public string Title
        {
            get { return "Grid代码自动生成"; }
        }

        private void btnBuild_Click(object sender, RoutedEventArgs e)
        {
            sbResult.Clear();
            //tbResult.Text = @"<Grid>\n<Grid.RowDefinitions>{0}</Grid.RowDefinitions><Grid.ColumnDefinitions>{1}</Grid.ColumnDefinitions></Grid>";
            sbResult.AppendFormat("<Grid x:Name=\"gridname\">\n\t<Grid.RowDefinitions>\n{0}\t</Grid.RowDefinitions>\n\t<Grid.ColumnDefinitions>\n{1}\t</Grid.ColumnDefinitions>\n</Grid>", GetRowDefinitions(Convert.ToInt32(tbRow.Text)), GetColDefinitions(Convert.ToInt32(tbColumn.Text)));
            tbResult.Text = sbResult.ToString();
        }

        //
        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Button btn = (Button)sender;
                switch (btn.Name)
                {
                    case "btnSubRow":
                        tbRow.Text = (Convert.ToInt32(tbRow.Text) - 1).ToString();
                        break;
                    case "btnAddRow":
                        tbRow.Text = (Convert.ToInt32(tbRow.Text) + 1).ToString();
                        break;
                    case "btnSubCol":
                        tbColumn.Text = (Convert.ToInt32(tbColumn.Text) - 1).ToString();
                        break;
                    case "btnAddCol":
                        tbColumn.Text = (Convert.ToInt32(tbColumn.Text) + 1).ToString();
                        break;
                    default:
                        break;
                }
            }
            catch (Exception)
            {
            }
        }

        //
        private string GetRowDefinitions(int row)
        {
            StringBuilder sbRows = new StringBuilder();
            for (int i = 0; i < row; i++)
            {
                sbRows.Append("\t\t<RowDefinition Height=\"Auto\"></RowDefinition>\n");
            }
            return sbRows.ToString();
        }

        private string GetColDefinitions(int col)
        {
            StringBuilder sbCols = new StringBuilder();
            for (int i = 0; i < col; i++)
            {
                sbCols.Append("\t\t<ColumnDefinition Width=\"Auto\"></ColumnDefinition>\n");
            }
            return sbCols.ToString();
        }
    }
}
