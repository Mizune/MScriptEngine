using MScriptEngine.Views;
using System.Collections;

namespace MScriptEngine.Models
{
    public class ViewController
    {
        public MainWindow Context;
        public ViewController(MainWindow BaseContext)
        {
            this.Context = BaseContext;
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