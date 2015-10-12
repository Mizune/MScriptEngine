using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MScriptEngine.Models
{
    public class CurrentState
    {
        //画面が1個必ず持つ
        public int Width { get; set; }
        public int Height { get; set; }

        public string CharName { get; set; }
        public string MainText { get; set; }
        public string LeftChar { get; set; }
        public string CenterChar { get; set; }
        public string RightChar { get; set; }
        public string BGIPath { get; set; }
        public string BGMPath { get; set; }


        public int Initialize()
        {
            Width = 1280;
            Height = 720;


            CharName = "";
            MainText = "";
            LeftChar = "";
            CenterChar = "";
            RightChar = "";

            BGIPath = "";
            BGMPath = "";

            return 0;

        }


        public int LoadState()
        {
            LoadState("000");
            return 0;
        }

        public int LoadState(string Num)//セーブナンバー 0{pagenum}{itemnum}
        {

            string data = "data data";
            // 仮置きデータ

            // データがあるかないか確認 > あればロード(currentに入れる)　なければエラー
            if (false　|| Num.Equals("100")) // データの確認
            {
                return -1;
            }

            // Dataの処理



            return 0;
        }
        
        public int SaveState()
        {
            SaveState("000");
            return 0;
        }

        public int SaveState(string Num)
        {

            return 0;
        }

    }
}
