using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
namespace Wpf_concept
{
    public class Parser
    {
        public IEnumerable<string> NameList
        {
            get { return _nameList; }
            set { _nameList = value; }
        }

        private IEnumerable<string> _nameList;

        //public List<string> RobotNameList
        //{
        //    get { return _robotNameList; }
        //    set { _robotNameList = value; }
        //}

        //private List<string> _robotNameList;

        public Parser()
        {
            string url = "..\\..\\..\\DefCommponent_ver1.xml";
            var XFile = XDocument.Load(url);

            // show robot list
            _nameList = (
                from firstNode in XFile.Element("FlexSpot").Elements("Category").Elements("Component")
                where firstNode.Attribute("name").Value == "Robot"
                from robotNode in firstNode.Elements("CompValue")
                select robotNode.Attribute("value").Value);           

        }
    }
}