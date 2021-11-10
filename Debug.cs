using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace UniEx
{

    /// <summary>
    /// 標準入出力クラス
    /// スクリプトのライフサークルによる実装で
    /// System.Console.ReadLine() と System.Console.ReadLine()による入出力処理が使用不可となりました。
    /// 必ず、Debugクラスを用いた入出力を行ってください。
    /// </summary>
    public class Debug
    {
        static string consoleLine = "";
        static bool act = false, queue = false;
        public void Read()
        {
            consoleLine = Console.ReadLine();
            act = true;
            if (queue is false)
            {
                Console.WriteLine("現在、入力待ちがありません。");
                act = false;
            }
        }
        public static string Scan()
        {
            queue = true;
            while (!act) { }
            act = queue = false;
            return consoleLine;
        }
        public static void Log(object message, LogType lt = LogType.Time)
        {
            if (message is null) return;
            switch (lt)
            {
                case LogType.Time:
                    Console.WriteLine($"[{TimePrint.Current.ToString()}] {message.ToString()}");
                    break;
                case LogType.Custom:
                    Console.WriteLine(message.ToString());
                    break;
            }
        }

        /// <summary>
        /// 処理速度を簡易的に計測し、出力します。
        /// 正確度はかなり悪いです。
        /// ミリ秒単位のズレを気にしない場合にのみ使用してください。
        /// </summary>
        public static void LogProcessSpeed(Action action)
        {
            var dt = DateTime.Now;
            action();
            var e = new TimeSpan(DateTime.Now.Ticks - dt.Ticks);

            Debug.Log($"{e.Hours.ToString()}h {e.Minutes.ToString()}min {e.Seconds.ToString()}s {e.Milliseconds.ToString()}ms", LogType.Custom);
        }

        /// <summary>
        /// 処理速度を計測し、出力します。
        /// 正確度は 引数 accurateIntensity の設定値に比例します。
        /// </summary>
        // accurateIntensity：
        // 1 = 悪い
        // 25 = 普通
        // 50 = かなり正確
        // 100 = 超正確
        // ※ 100以上に設定すると計測対象の処理速度によっては処理落ちの可能性があるため、
        // ※ sbyteによる範囲縛りを行っています。
        public static void LogAccurateProcessSpeed(Action action, sbyte accurateIntensity = 25, [CallerLineNumber] int line = 0, [CallerMemberName] string name = null)
        {
            DateTime dt = DateTime.Now;
            for (int i = 0; i < accurateIntensity; i++)
                action();
            var e = new TimeSpan((DateTime.Now.Ticks - dt.Ticks) / accurateIntensity);
            Debug.Log($"{name.ToString()} : {line.ToString()}\n{e.Hours.ToString()}h {e.Minutes.ToString()}min {e.Seconds.ToString()}s {e.Milliseconds.ToString()}ms", LogType.Custom);
        }
    }

    public static class Debug_Extend
    {
        // 処理速度を計測し、出力します。
        // 正確度は普通です。
        public static void DoLog(this Stopwatch stopwatch)
        {
            stopwatch.Stop();
            var e = stopwatch.Elapsed;
            Debug.Log($"{e.Hours.ToString()}h {e.Minutes.ToString()}min {e.Seconds.ToString()}s {e.Milliseconds.ToString()}ms", LogType.Custom);
        }
    }

    public enum LogType
    {
        Time,
        Custom
    }

}