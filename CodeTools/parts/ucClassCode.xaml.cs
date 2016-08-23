using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// ucClassCode.xaml 的交互逻辑
    /// </summary>
    public partial class ucClassCode : UserControl
    {
        private static string template = 
@"using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace {0} 
{{
    /// <summary>
    /// 作者：{1}
    /// 时间：{5}
    /// 说明：{2}
    /// </summary>
    public class {3} 
    {{
        public {3}()
        {{
        }}
        {4}
    }}
    {6}
}}";

        private static string oneProperty = @"
        
        private {0} {1};
        /// <summary>
        /// {3}
        /// </summary>
        public {0} {2} 
        {{
            get {{ return {1}; }}
            set {{ {1} = value; }}
        }}";

        private static string Constructor = @"
        //
        public {0}({1})
        {{
        {2}
        }}
        ";

        private StringBuilder sbConstructorParams = new StringBuilder();
        private StringBuilder sbConstructorContent = new StringBuilder();

        public ucClassCode()
        {
            InitializeComponent();

            //ObservableCollection<Entity> propertys = new ObservableCollection<Entity>();

            //propertys.Add(new Entity() { NAME = "Id", TYPE = "int" });

            dgPropertyList.DataContext = new ObservableCollection<Entity>() { new Entity() { NAME = "id", TYPE = "int" ,SUMMARY="编号"} };
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            ObservableCollection<Entity> propertys = new ObservableCollection<Entity>();
            StringBuilder sbContent = new StringBuilder();
            sbConstructorParams.Clear();
            sbConstructorContent.Clear();

            foreach (Entity en in dgPropertyList.DataContext as ObservableCollection<Entity>)//去空
            {
                if(en.NAME!=null&&en.TYPE!=null)
                    propertys.Add(en);
            }

            foreach (Entity en in propertys)
            {
                sbContent.Append(GetOnePropertyDefinition(en));
            }
            //sbConstructorParams=sbConstructorParams.Remove(sbConstructorParams.ToString().LastIndexOf(","), 1);
            string sConstructor = string.Format(Constructor, tbClass.Text.Trim(), sbConstructorParams.Remove(sbConstructorParams.ToString().LastIndexOf(","), 1), sbConstructorContent.ToString());

            tbResult.Text = string.Format(template, tbNamespace.Text.Trim(), tbAuthor.Text.Trim(), tbSummary.Text.Trim(), tbClass.Text.Trim(), sbContent.ToString(), DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), sConstructor);//@"{0}And {1}and {2} and {3} "

            if (cbSaveFile.IsChecked == true)//保存为文件
            {
                System.Windows.Forms.SaveFileDialog sfd = new System.Windows.Forms.SaveFileDialog() { FileName = tbClass.Text.Trim() + ".cs", Filter = "cs files(*.cs)|*.cs" };
                
                if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    using (System.IO.FileStream fs = new System.IO.FileStream(sfd.FileName, System.IO.FileMode.Create))
                    {
                        using (System.IO.StreamWriter writer = new System.IO.StreamWriter(fs, Encoding.Default))
                        {
                            writer.Write(tbResult.Text.Trim());
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="en"></param>
        /// <returns></returns>
        private string GetOnePropertyDefinition(Entity en)
        {
            string name = GetFirstCharToLower(en.NAME.Trim());
            string type = en.TYPE.Trim();
            string summary = en.SUMMARY == null ? "" : en.SUMMARY.Trim();

            sbConstructorParams.AppendFormat("{0} {1},", type, name);
            sbConstructorContent.AppendFormat("\tthis.{0}={0};\n",name);

            return string.Format(oneProperty, type, name, GetFirstCharToUpper(name), summary);            
        }

        private void TextBox_MouseEnter(object sender, MouseEventArgs e)
        {
            TextBox tb = sender as TextBox;
            tb.Focus();
            tb.SelectAll();
        }

        private string GetFirstCharToLower(string str)
        {
            
            if (str.Length > 1)
                return str.Substring(0, 1).ToLower() + str.Substring(1);            
            else if (str.Length == 1)
                return str.ToLower();
            else
                return "";
        }

        private string GetFirstCharToUpper(string str)
        {

            if (str.Length > 1)
                return str.Substring(0, 1).ToUpper() + str.Substring(1);
            else if (str.Length == 1)
                return str.ToLower();
            else
                return "";
        }
    }

    public class Entity
    {
        public string NAME { get; set; }
        public string TYPE { get; set; }
        public string SUMMARY { get; set; }
    }

}
