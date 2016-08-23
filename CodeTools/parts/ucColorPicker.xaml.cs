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
    /// ucColorPicker.xaml 的交互逻辑
    /// </summary>
    public partial class ucColorPicker : UserControl
    {
        public ucColorPicker()
        {
            InitializeComponent();
        }

        private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

            //Slider slider = sender as Slider;
            //if (slider.Tag == null || txtR == null || txtG == null || txtB == null)
            //    return;
            //switch (slider.Tag.ToString())
            //{
            //    case "R":
            //        txtR.Text = slider.Value.ToString();
            //        break;
            //    case "G":
            //        txtG.Text = slider.Value.ToString();
            //        break;
            //    case "B":
            //        txtB.Text = slider.Value.ToString();
            //        break;
            //    default:
            //        break;
            //}
        }
    }
}
