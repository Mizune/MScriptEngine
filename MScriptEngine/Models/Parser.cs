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
        ViewController Controller;


        public Parser(ArrayList Data ,MainWindow Context)
        {
            Initialize(Data,Context);
        }

        public  void Initialize(ArrayList rawData,MainWindow Context)
        {
            Datas = rawData;
            DataLength = Datas.Count;
            Controller = new ViewController(Context);
        }

        public int Parsing() // これをXAML側で呼び出すように書き換え Clickableに変更 (switchの分岐はちょっと考える) 　Switchを見つけたら 決定を待つ　決定が返って来たらそれにしたがって読み込む
        {
            Console.WriteLine(DataLength);
            if (DataLength < 0)
                return -1;
            foreach (string data in Datas)
            {
                Console.WriteLine("Call BranchFunction");
                if (!BranchFunction(data))
                {
                    Console.WriteLine("Error. {0} is unknown function.", data);
                }
            }

            return 0;


        }

        public bool BranchFunction(string data)
        {
            if (!data.Contains("[") && !data.Contains("]"))
            {
                Console.WriteLine("通常文章なのでTextRenderer呼び出し");
                Controller.ChangeText(data);
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
                    return false; // Error. 
                }

                switch (Datas[0])
                {
                    case "CangeBGI":
                        Controller.SetBGM(Datas[1]);
                        break;
                    case "UseSE":
                        Controller.UseSE(Datas[1]);
                        break;
                    case "ChangeCenterCharImg":
                        Controller.ChangeCenterCharImg(Datas[1]);
                        break;
                    case "ChangeRightCharImg":
                        Controller.ChangeRightCharImg(Datas[1]);
                        break;
                    case "ChangeLeftCharImg":
                        Controller.ChangeLeftCharImg(Datas[1]);
                        break;
                    case "ChangeCharName":
                        Controller.ChangeCharName(Datas[1]);
                        break;
                    case "ChangeThumbnailCharImg":
                        Controller.ChangeCharThumbnail(Datas[1]);
                        break;
                    case "Switch": // [Switch {SelectNum} {SelectText} {SelectText} ...] // [Case{Num} ] hogehoge [CaseEnd{num}]
                        Controller.CreateSwitch(int.Parse(Datas[1]),Datas);
                        //
                        break;
                    case "InitFlag":
                        // controller.InitFlag,
                        // 
                        break;
                }

            }
            // キー入力待をここに
            return true;
        }
    }
}
