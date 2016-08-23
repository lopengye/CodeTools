using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTools 
{
    /// <summary>
    /// 作者：LPY
    /// 时间：2016-08-23 11:27:50
    /// 说明：目录树
    /// </summary>
    public class Catalog 
    {
        public Catalog()
        {
        }
        
        
        private int id;
        /// <summary>
        /// 编号
        /// </summary>
        public int Id 
        {
            get { return id; }
            set { id = value; }
        }
        
        private string header;
        /// <summary>
        /// 标题
        /// </summary>
        public string Header 
        {
            get { return header; }
            set { header = value; }
        }
        
        private string tag;
        /// <summary>
        /// 用户控件名称
        /// </summary>
        public string Tag 
        {
            get { return tag; }
            set { tag = value; }
        }
        
        private string img;
        /// <summary>
        /// 图片路径
        /// </summary>
        public string Img 
        {
            get { return img; }
            set { img = value; }
        }
        
        private System.Windows.Style style;
        /// <summary>
        /// 样式
        /// </summary>
        public System.Windows.Style Style 
        {
            get { return style; }
            set { style = value; }
        }
        
        private int level;
        /// <summary>
        /// 目录级别
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