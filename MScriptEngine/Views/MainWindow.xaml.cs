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
    public partial class MainWindow : Window
    {
        private bool SWFlag;
        private bool TextFlag;
        private bool EventChecker;
        private int testCount;
        private MediaElement BGMContext;
        //private ScinarioViewModels Context;
        private ArrayList Scinarios;

        private TextBlock MainTextBlock;

        public MainWindow()
        {
            InitializeComponent();
            this.MouseLeftButtonDown += (sender, e) => this.DragMove();
            LoadScinarios();
            MainTextBlock = this.MainText;
            BGMContext = this.BGM;
            SWFlag = false;
            TextFlag = false;
            EventChecker = false;
            testCount = 0;
        }

        private void LoadScinarios()
        {
            LoadScinarios("FirstScinarios.txt");
        }

        private void LoadScinarios(string FilePath)
        {
            this.Scinarios = Reader.Load(FilePath); 
        }

        private void WindowChrome_AccessKeyPressed(object sender, AccessKeyPressedEventArgs e)
        {

        }

        private void Minimize(object sender, RoutedEventArgs e)
        {

        }
        private void FullScreen(object sender, RoutedEventArgs e)
        {

        }
        private void ReverseSize(object sender, RoutedEventArgs e)
        {

        }

        private void Exit(object sender, RoutedEventArgs e)
        {

        }

        private void Bg_ButtonClick(object sender, RoutedEventArgs e)
        {
            if (!EventChecker)
            {
                Console.WriteLine("Clicked. : {0}", testCount);
                testCount += 1;

                while (!SWFlag & !TextFlag)
                {
                    // TextかSwitch文が車でひたすらパースし続ける
                    //判定した結果でFlagを操作
                }


            }
            EventChecker = false;
        }

        private void MainTextClick(object sender,RoutedEventArgs e)
        {
            EventChecker = true;
            Console.WriteLine("MainText Clicked : {0}", testCount);
            testCount += 1;
            BGMContext.Source = new Uri(ConstParams.SoundsPathRoot+"Hoge.mp3", UriKind.Relative);
            BGMContext.Play();
        }

        // Reader class 
        public static class Reader
        {

            static StreamReader SReader;
            static ArrayList Datas;
            static string Line;

            

            public static ArrayList Load()
            {
                Load("first.txt");
                return Datas;
            }

            public static ArrayList Load(string filePath)
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

            public static ArrayList GetList()
            {
                return Datas;
            }
        }

        public static class Parser
        {
            static int DataLength;
            static ArrayList Datas;
            static ViewController Controller;

            public static void Initialize(ArrayList rawData)
            {
                Datas = rawData;
                DataLength = Datas.Count;
                Controller = new ViewController();
            }

            public static int Parsing() // これをXAML側で呼び出すように書き換え Clickableに変更 (switchの分岐はちょっと考える) 　Switchを見つけたら 決定を待つ　決定が返って来たらそれにしたがって読み込む
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

            public static bool BranchFunction(string data)
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
                        case "CahgeBGI":
                            Controller.ChangeBGI(Datas[1]);
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
                        case "ChangeThumbnailCharImg":
                            Controller.ChangeThumbnailCharImg(Datas[1]);
                            break;
                        case "Switch":
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
}
