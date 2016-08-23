using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTools 
{
    /// <summary>
    /// ���ߣ�LPY
    /// ʱ�䣺2016-08-23 11:27:50
    /// ˵����Ŀ¼��
    /// </summary>
    public class Catalog 
    {
        public Catalog()
        {
        }
        
        
        private int id;
        /// <summary>
        /// ���
        /// </summary>
        public int Id 
        {
            get { return id; }
            set { id = value; }
        }
        
        private string header;
        /// <summary>
        /// ����
        /// </summary>
        public string Header 
        {
            get { return header; }
            set { header = value; }
        }
        
        private string tag;
        /// <summary>
        /// �û��ؼ�����
        /// </summary>
        public string Tag 
        {
            get { return tag; }
            set { tag = value; }
        }
        
        private string img;
        /// <summary>
        /// ͼƬ·��
        /// </summary>
        public string Img 
        {
            get { return img; }
            set { img = value; }
        }
        
        private System.Windows.Style style;
        /// <summary>
        /// ��ʽ
        /// </summary>
        public System.Windows.Style Style 
        {
            get { return style; }
            set { style = value; }
        }
        
        private int level;
        /// <summary>
        /// Ŀ¼����
        /// </summary>
        public int Level 
        {
            get { return level; }
            set { level = value; }
        }

        public Catalog( string header, string tag,   int level)
        {
            this.header = header;
            this.tag = tag;
            this.level = level;
        }
    }
}