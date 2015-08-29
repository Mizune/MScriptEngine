﻿using MScriptEngine.Views;
using System.Collections;
using MScriptEngine.Models;
using System.Collections.Generic;

namespace MScriptEngine.Models
{
    public class ViewController
    {
        public MainWindow Context;
        public Dictionary<string, int> Flags = new Dictionary<string, int>();
         
        public ViewController(MainWindow BaseContext)
        {
            this.Context = BaseContext;
        }


        public void Brancher(int param,string res)// res -> [ChangeBGI hogehoge]
        {
            string[] data = res.Split(' ');
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
                    ChangeLeftCharImg(data[1]);
                    break;
                case ConstParams.CenterCharImg:
                    ChangeCenterCharImg(data[1]);
                    break;
                case ConstParams.RightCharImg:
                    ChangeRightCharImg(data[1]);
                    break;
                case ConstParams.ThumbnailImg:
                    ChangeCharThumbnail(data[1]);
                    break;
                case ConstParams.CharName:
                    ChangeCharName(data[1]);
                    break;
                case ConstParams.BGI:
                    ChangeBGI(data[1]);
                    break;
                case ConstParams.Flag:
                    switch (data[0])
                    {
                        case "AddFlag":
                            Flags.Add(data[1],0);
                            break;
                        case "AjustFlag":
                            Flags[data[1]] += int.Parse(data[2]); // 入力値検証なし
                            break;
                        case "ClearFlag":
                            Flags[data[1]] = 0;
                            break;
                    }
                    // Addとedit,clear,get
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

        public void CreateSwitch(int selectCount, string[] data) // [Switch {num} {select}...]
        {
            ArrayList select = new ArrayList(data);
            select.RemoveRange(0, 2);

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

        public void ChangeBGI(string BGIPath)
        {

        }

        // Save & Load
        // Flag(Key&Value),ScinarioFilePath, Line,CurrentStates(MainText,CharName,CharPic,BGM)


        // AddFlag

        // Dictionary Flagname:Flagint
    }
}