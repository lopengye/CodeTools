using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml;

namespace CodeTools
{
    /// <summary>
    /// 
    /// </summary>
    public class XmlHelper
    {
        //public static string xmlHistory = PublicParams.xmlHistory;

        public static void CheckXMLFile(string fileName)
        {
            XmlDocument dom = new XmlDocument();
            try
            {
                dom.Load(fileName);
            }
            catch (Exception ex)
            {
                XmlHelper.CreateXMLFile(fileName);
                LogHelper.WriteLog(string.Format( "不存在配置文件：{0}，已创建。原始消息：{1}",fileName,ex.Message));
            }
        }

        /// <summary>
        /// 从xml文件中读取数据
        /// </summary>
        /// <param name="xmlFileName">文件名</param>
        /// <param name="xPath">节点路径，例如：   /Root/XXXX</param>
        /// <returns>节点值</returns>
        public static string GetValueByXPath(string xmlFileName, string xPath)
        {
            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                string result = string.Empty;
                xmlDoc.Load(xmlFileName);
                XmlNode xmlNode = xmlDoc.SelectSingleNode(xPath);
                if (xmlNode != null)
                    result = xmlNode.InnerText;
                return result;
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex.Message);
                return null;
            }
        }

        /// <summary>
        /// 更新xml文件中节点值
        /// </summary>
        /// <param name="xmlFileName">文件名</param>
        /// <param name="xPath">节点路径，例如：   /Root/XXXX</param>
        /// <param name="value">待更新的值</param>
        public static void UpdateValueByXPath(string xmlFileName, string xPath, string value)
        {
            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.Load(xmlFileName);
                XmlNode xmlNode = xmlDoc.SelectSingleNode(xPath);
                if (xmlNode != null)
                    xmlNode.InnerText = value;
                xmlDoc.Save(xmlFileName);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex.Message);
            }
        }



        public static bool CreateXMLFile(string fileName)
        {
            bool isSuccess = false;
            try
            {
                XmlDocument dom = new XmlDocument();
                XmlDeclaration xmlDec = dom.CreateXmlDeclaration("1.0", "gb2312", null);
                XmlElement xe = dom.CreateElement("Root");
                dom.AppendChild(xmlDec);
                dom.AppendChild(xe);
                dom.Save(fileName);
                isSuccess = true;
            }
            catch (Exception)
            {
            }
            return isSuccess;
        }
    }
}
