using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;        
using MScriptEngine.Models;            

namespace MScriptEngine.Views
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    /// TODO サンプルスクリプトの場所を探す
    public partial class MainWindow : Window
    {
        private bool SWFlag;
        private bool TextFlag;
        private bool EventChecker;
        private int testCount;

        // View変数                       

        // シナリオ解析＆制御変数
        private Reader reader;
        private Parser parser;
        private ViewController Controller;
        //private ScinarioViewModels Context;


        private ArrayList Scinarios; // 読み込んだシナリオファイルのデータ群
        private ArrayList CtlDatas;
        private int LineCount; // Line番号のカウント



        public MainWindow()
        {
            InitializeComponent();
            this.MouseLeftButtonDown += (sender, e) => this.DragMove();
            reader = new Reader();
            parser = new Parser(reader.GetList(),this);
            Controller = new ViewController(this);
            SWFlag = false;
            TextFlag = false;
            EventChecker = false;
            testCount = 0;
            LineCount = 0;
            LoadScinarios();// if シナリオがあるか　セーブスタートか　
            this.Title = "Platinum Toybox";
        }

        private void LoadScinarios()
        {
            LoadScinarios(ConstParams.ScenarioPathRoot + "FirstScenario.txt");
        }

        private void LoadScinarios(string FilePath)
        {
            this.Scinarios = reader.Load(FilePath);
            parser = new Parser(reader.GetList(), this);
            parser.Parsing();
            Scinarios = parser.GetData();
            CtlDatas = parser.GetControllData();
            //"/Assets/Scenarios/FirstScenario.txt"
        }


        private void Bg_ButtonClick(object sender, RoutedEventArgs e)
        { 
            Console.WriteLine("Clicked. : {0}", testCount);
            testCount += 1;

            while (!TextFlag)
            {
                if (!SWFlag)
                {
                        
                    //判定した結果でFlagを操作
                    // 配列がout of bounds
                    Controller.Brancher((int)CtlDatas[LineCount], Scinarios[LineCount].ToString());
                    if ((int)CtlDatas[LineCount]!= 1)
                    {
                        Console.WriteLine("TextFlag is false");
                    }
                    else
                    {
                        Console.WriteLine("TextFlag is true");
                        TextFlag = true;
                    }

                    LineCount++;
                } 
            }
            TextFlag = false;
            SWFlag = false;

        }


        // Public Method

        public void ChangeMainText(string Text)
        {
            this.MainText.Text = Text;
        }

        public void ChangeCharName(string Text)
        {
            Console.WriteLine("called change char name");
            this.CharName.Text = Text;    
        }

        public void ChangeCenterChar(string ImgPath)
        {
            Console.WriteLine(ConstParams.SoundsPathRoot + ImgPath);
            this.CharCenterImg.Source = new BitmapImage(new Uri(ConstParams.SoundsPathRoot + ImgPath));
        }

        public void ChangeRightChar(string ImgPath)
        {
            this.CharRightImg.Source = new BitmapImage(new Uri(ConstParams.SoundsPathRoot + ImgPath));
        }

        public void ChangeLeftChar(string ImgPath)
        {
            this.CharLeftImg.Source = new BitmapImage(new Uri(ConstParams.SoundsPathRoot + ImgPath));
        }

        public void ChangeBGM(string BGMPath)
        {
            this.BGM.Source = new Uri(ConstParams.SoundsPathRoot + BGMPath);
            // BGMを再生するところまでやらなきゃだめ
        }

        public void UseSE(string SEPath)
        {

        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LoadBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ConfigBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        public void CreateSwitchBtn(string[] data)
        {
            // data[1]を取得して
            // その数だけボタンを生成して
            // ボタンにidを割り振って
            // クリッカブルイベントつくっておわり
        }


        //BGM再生
        //別チャンネルでSEの再生
        //BGIの変更
        //場面転換を入れるか入れないか
        //Save & Loadの仕組みを作る

        public void LoadSaveData(int pathNum)
        {

        }

        // 話の節目に画像を入れる処理(フェードインフェードアウト)

    }
}
