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
        private int SwitchNum;

        // View変数                       

        // シナリオ解析＆制御変数
        private Reader reader;
        private Parser parser;
        private ViewController Controller;
        //private ScinarioViewModels Context;


        private ArrayList Scinarios; // 読み込んだシナリオファイルのデータ群
        private ArrayList CtlDatas;
        private int LineCount; // Line番号のカウント


        // SaveData変数
        private CurrentState State;



        public MainWindow()// 遷移するときに値を持たせてフラグ処理でセーブ読み込み
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

            State = new CurrentState();

            this.Root.DataContext = State;
            　
            this.Title = "Platinum Toybox";
            
            
            foreach(var d in CtlDatas){ Console.WriteLine(d); }
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

                    string script = Scinarios[LineCount].ToString();
                    script = script.Replace("[", "");
                    script = script.Replace("]", "");

                    Controller.Brancher((int)CtlDatas[LineCount], script);
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
            // 一文字ずつ変えてく処理
            this.MainText.Text = Text;  
        }

        public void ChangeCharName(string Text)
        {
            // 一文字ずつ変えてく処理？
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
            this.SE.Source = new Uri(ConstParams.SoundsPathRoot + SEPath);
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
            int count = int.Parse(data[1]);

            for(int i = 0; i < count; i++)
            {
                // btn 生成, それぞれのdata[i+2]をcontentに　生成するボタンにidつける クリックイベント(一括)をつける
                // クリックイベントはidよみとって選択しをglobalに投げる > Flagをきる  ここまでやるとOK
            }
        }


        //BGM再生
        //別チャンネルでSEの再生
        //BGIの変更
        //場面転換を入れるか入れないか
        //Save & Loadの仕組みを作る

        public void LoadSaveData(int pathNum)
        {

        }

        public void CreateSaveData(int pathNum)
        {

        }

        // 話の節目に画像を入れる処理(フェードインフェードアウト)

    }
}
