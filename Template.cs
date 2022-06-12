#if DEBUG
#pragma warning disable CS8600 // Null リテラルまたは Null の可能性がある値を Null 非許容型に変換しています。

public static class CompetitiveDebug
{
    //ここに問題データを貼り付ける(デバッグ用)
    static string rawdata =
@"

";

    #region デバッグ用メソッド
    internal static void DebugSetup()
    {
        string data = "";

        data = rawdata.Trim();

        StringReader stream = new StringReader(data);
        Console.SetIn(stream);
    }
    #endregion
}
#endif

namespace Competitive
{
    //-----------コピー範囲ここから--------------
    using System;
    using System.Collections.Generic;

    public static class Competitive
    {
        //入力データ
        static string RawData = "";                                       //問題データ
        static List<string> LineData = new List<string>();                //行ごとのデータ
        static List<List<string>> SplitData = new List<List<string>>();   //(空白)文字ごとに分割したデータ
        static List<List<long>> LongData = new List<List<long>>();        //分割データを整数(long型)に変換したもの
        static List<List<double>> DoubleData = new List<List<double>>();  //分割データを実数(double型)に変換したもの

        //解答用文字列
        static string OutputData = "";

        //改行
        static string NL = System.Environment.NewLine;

        #region ヘルパメソッド
        static void GetLineData()
        {
            while (true)
            {
                string line = Console.ReadLine();
                if (line == null) break;
                RawData += line + Environment.NewLine;
                LineData.Add(line);
            }
        }


        static void GetSplitData(char sep)
        {
            if (LineData.Count == 0) return;

            for (int i = 0; i < LineData.Count; i++)
            {
                SplitData.Add(new List<string>());
                string[] ssv = LineData[i].Split(sep);

                for (int j = 0; j < ssv.Length; j++)
                {
                    SplitData[i].Add(ssv[j]);
                }
            }

        }

        static void GetConvertLongData()
        {
            if (SplitData.Count == 0) return;

            for (int i = 0; i < SplitData.Count; i++)
            {
                LongData.Add(new List<long>());
                for (int j = 0; j < SplitData[i].Count; j++)
                {
                    long dat;
                    try
                    {
                        dat = Int64.Parse(SplitData[i][j]);
                    }
                    catch (Exception)
                    {
                        dat = 0;
                    }
                    LongData[i].Add(dat);
                }
            }
        }

        static void GetConvertDoubleData()
        {
            if (SplitData.Count == 0) return;

            for (int i = 0; i < SplitData.Count; i++)
            {
                DoubleData.Add(new List<double>());
                for (int j = 0; j < SplitData[i].Count; j++)
                {
                    double dat;
                    try
                    {
                        dat = Double.Parse(SplitData[i][j]);
                    }
                    catch (Exception)
                    {
                        dat = 0;
                    }
                    DoubleData[i].Add(dat);
                }
            }
        }
        #endregion

        #region エントリポイント
        //エントリポイント
        public static void Main()
        {
#if DEBUG
            CompetitiveDebug.DebugSetup();
#endif
            Init();
            Start();
            Console.Write(OutputData);
        }
        #endregion

        //問題データの取得と処理
        static void Init()
        {
            //この中から必要なヘルパ関数を選ぶ
            GetLineData();              //問題データを行ごとに取得
            GetSplitData(' ');          //行データを特定の文字ごとに分割
            GetConvertLongData();       //分割データを整数(long型)に変換
            //GetConvertDoubleData();   //分割データを実数(double型)に変換
        }


        static void Start()
        {
            //ここに解答コードを記述

        }
    }
    //----------コピー範囲ここまで--------------
}


