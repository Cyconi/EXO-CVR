using MelonLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EXO_CVR
{
    internal class CLog
    {
        internal static void L(string MessageToLog, ConsoleColor NameColor = ConsoleColor.DarkRed, ConsoleColor TextColor = ConsoleColor.White, ConsoleColor MidColor = ConsoleColor.DarkRed)
        {
            System.Console.ForegroundColor = NameColor;
            System.Console.Write("[EXO]");
            System.Console.ForegroundColor = MidColor;
            System.Console.Write(" [~>] ");

            System.Console.ForegroundColor = TextColor;
            System.Console.WriteLine(MessageToLog);
            System.Console.ResetColor();
        }

        internal static void S(string MessageToLog, ConsoleColor NameColor = ConsoleColor.DarkRed, ConsoleColor TextColor = ConsoleColor.DarkRed, ConsoleColor MidColor = ConsoleColor.DarkRed)
        {
            System.Console.ForegroundColor = NameColor;
            System.Console.Write("[EXO]");
            System.Console.ForegroundColor = MidColor;
            System.Console.Write(" [~>] ");

            System.Console.ForegroundColor = TextColor;
            System.Console.WriteLine(MessageToLog);
            System.Console.ResetColor();
        }

        internal static void E(string MessageToLog, ConsoleColor NameColor = ConsoleColor.DarkBlue, ConsoleColor TextColor = ConsoleColor.Red, ConsoleColor MidColor = ConsoleColor.Red)
        {

            System.Console.ForegroundColor = NameColor;
            System.Console.Write("[EXO]");
            System.Console.ForegroundColor = MidColor;
            System.Console.Write(" [~>] ");
            System.Console.ForegroundColor = ConsoleColor.Red;
            System.Console.Write(" [ERROR] ");

            System.Console.ForegroundColor = TextColor;
            System.Console.WriteLine(MessageToLog);
            System.Console.ResetColor();
        }
        public static event Action<ConsoleColor, ConsoleColor, string, string> MsgCallbackHandler;
        private static void NativeMsg(ConsoleColor namesection_color, ConsoleColor txt_color, string namesection, string txt)
        {
            if (string.IsNullOrEmpty(namesection))
            {
                MelonBase melonFromStackTrace = MelonUtils.GetMelonFromStackTrace();
                if (melonFromStackTrace != null)
                {
                    namesection = melonFromStackTrace.Info?.Name?.Replace(" ", "_");
                    namesection_color = melonFromStackTrace.ConsoleColor;
                }
            }
            Internal_Msg(namesection_color, txt_color, namesection, txt ?? "null");
            RunMsgCallbacks(namesection_color, txt_color, namesection, txt ?? "null");
        }
        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void Internal_Msg(ConsoleColor namesection_color, ConsoleColor txt_color, string namesection, string txt);
        internal static void RunMsgCallbacks(ConsoleColor namesection_color, ConsoleColor txt_color, string namesection, string txt)
        {
            MsgCallbackHandler?.Invoke(namesection_color, txt_color, namesection, txt);
        }
        public static void Msg(string txt)
        {
            NativeMsg(ConsoleColor.DarkRed, ConsoleColor.DarkRed, null, txt);
        }
    }
}

	
