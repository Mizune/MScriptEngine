using MScriptEngine.Views;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MScriptEngine.Models
{
    public  class Parser
    {
        int DataLength;
        ArrayList Datas;

        ArrayList CtlDatas; // intのみ格納 Datasに対応する


        public Parser(ArrayList Data ,MainWindow Context)
        {
            Initialize(Data,Context);
        }

        public  void Initialize(ArrayList rawData,MainWindow Context)
        {
            Datas = rawData;
            DataLength = Datas.Count;
            CtlDatas = new ArrayList();
        }

        public int Parsing() // これをXAML側で呼び出すように書き換え Clickableに変更 (switchの分岐はちょっと考える) 　Switchを見つけたら 決定を待つ　決定が返って来たらそれにしたがって読み込む
        {
            Console.WriteLine(DataLength);
            if (DataLength < 0)
                return -1;
            foreach (string data in Datas)
            {
                Console.WriteLine("Call BranchFunction");
                if (CreateControlData(data) == -1)
                {
                    Console.WriteLine("Error. {0} is unknown function.", data);
                }
                CtlDatas.Add(CreateControlData(data));
            }

            return 0;


        }

        public ArrayList GetData() { return Datas; }

        public ArrayList GetControllData() { return CtlDatas; }

        public int CreateControlData(string data)
        {
            if (!data.Contains("[") && !data.Contains("]"))
            {
                Console.WriteLine("通常文章なのでTextRenderer呼び出し");
                return 1; // 1 > TextRederer
            }
            else
            {
                data.Replace("[", ""); // 要らないものを消去
                data.Replace("]", "");

                string[] Datas = data.Split(' '); // スペースでsplit
                int DataSize = Datas.Length;

                if (DataSize < 1)
                {
                    Console.WriteLine("Error. 引数が足りません。");
                    return -1; // Error. 
                }

                switch (Datas[0])
                {
                    case "CangeBGI":
                        return ConstParams.BGI; 
                    case "UseSE":
                        return ConstParams.SE;  
                    case "ChangeCenterCharImg":
                        return ConstParams.CenterCharImg; 
                    case "ChangeRightCharImg":
                        return ConstParams.RightCharImg; 
                    case "ChangeLeftCharImg":
                        return ConstParams.LeftCharImg; 
                    case "ChangeCharName":
                        return ConstParams.CharName; 
                    case "ChangeThumbnailCharImg":
                        return ConstParams.ThumbnailImg;
                    case "Switch": // [Switch {SelectNum} {SelectText} {SelectText} ...] // [Case{Num} ] hogehoge [CaseEnd{num}]
                        return ConstParams.Switch; 
                    case "InitFlag":
                        // controller.InitFlag,
                        //
                        return ConstParams.Flag; 
                }

            }
            // キー入力待をここに
            return 0;
        }
    }
}
