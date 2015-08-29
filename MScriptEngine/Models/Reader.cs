using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MScriptEngine.Models
{
    public  class Reader
    {

        StreamReader SReader;
        ArrayList Datas;
        string Line;
        
        public Reader()
        {
            Load();
        }

        public Reader(string filePath)
        {
            Load(filePath);
        }


        public ArrayList Load()
        {
            Load(ConstParams.ScenarioPathRoot + "FirstScenario.txt");
            return Datas;
        }

        public ArrayList Load(string filePath)
        {
            Line = "";
            Datas = new ArrayList();

            using (SReader = new StreamReader(filePath, Encoding.GetEncoding("UTF-8")))
            {
                while ((Line = SReader.ReadLine()) != null)
                {
                    Datas.Add(Line);
                }
            }
            return Datas;
        }

        public  ArrayList GetList()
        {
            return Datas;
        }
    }
}
