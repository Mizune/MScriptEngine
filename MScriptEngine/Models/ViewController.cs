using MScriptEngine.Views;
using System.Collections;
using MScriptEngine.Models;

namespace MScriptEngine.Models
{
    public class ViewController
    {
        public MainWindow Context;
        public ViewController(MainWindow BaseContext)
        {
            this.Context = BaseContext;
        }


        public void Brancher(int param,string[] data)
        {
            switch (param)
            {
                case ConstParams.Text:
                    SetMainText(data[1]);
                    break;
                case ConstParams.Switch:
                    CreateSwitch(int.Parse(data[1]),data);
                    break;
                case ConstParams.BGM:
                    SetBGM(data[1]);
                    break;
                case ConstParams.SE:
                    UseSE(data[1]);
                    break;
                case ConstParams.LeftCharImg:

                    break;
                case ConstParams.CenterCharImg:
                    break;
                case ConstParams.RightCharImg:
                    break;
                case ConstParams.ThumbnailImg:
                    break;
                case ConstParams.CharName:
                    break;
                case ConstParams.BGI:
                    break;
                case ConstParams.Flag:
                    break;
                case ConstParams.Error:
                    break;
            }
        }


        public void SetMainText(string Text)
        {
            Context.ChangeMainText(Text);
        }

        public void ChangeCharName(string Name)
        {

        }

        public void ChangeCharThumbnail(string ImgPath)
        {

        }

        public void CreateSwitch(int selectCount, string[] data)
        {

        }

        public void ChangeLeftCharImg(string ImgPath)
        {

        }

        public void ChangeCenterCharImg(string ImgPath)
        {

        }
        public void ChangeRightCharImg(string ImgPath)
        {

        }

        public void SetBGM(string BGMPath)
        {

        }

        public void UseSE(string SEPath)
        {

        }

        // Save & Load
        // Flag(Key&Value),ScinarioFilePath, Line,CurrentStates(MainText,CharName,CharPic,BGM)


        // AddFlag

        // Dictionary Flagname:Flagint
    }
}