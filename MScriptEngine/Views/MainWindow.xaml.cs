﻿using System;
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

        // View変数
        private TextBlock MainTextBlock;
        private MediaElement BGMContext;

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
            LoadScinarios();
            Connect();
            reader = new Reader();
            parser = new Parser(reader.GetList(),this);
            SWFlag = false;
            TextFlag = false;
            EventChecker = false;
            testCount = 0;
            LineCount = 0;
        }

        private void Connect()
        {
            MainTextBlock = this.MainText;
            BGMContext = this.BGM;

        }

        private void LoadScinarios()
        {
            LoadScinarios("FirstScinarios.txt");
        }

        private void LoadScinarios(string FilePath)
        {
            this.Scinarios = reader.Load(FilePath);
            parser = new Parser(reader.GetList(), this);
            parser.Parsing();
            Scinarios = parser.GetData();
            CtlDatas = parser.GetControllData();
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
                    if((int)CtlDatas[LineCount] == 1 || (int)CtlDatas[LineCount] == 2)

                    LineCount++;    
                }


            }
            EventChecker = false;
        }

        private void MainTextClick(object sender,RoutedEventArgs e)
        {
            EventChecker = true;
            Console.WriteLine("MainText Clicked : {0}", testCount);
            testCount += 1;
            BGMContext.Source = new Uri(ConstParams.SoundsPathRoot);
        }


        // Public Method

        public void ChangeMainText(string Text)
        {
            MainTextBlock.Text = Text;
        }
       
        
    }
}
