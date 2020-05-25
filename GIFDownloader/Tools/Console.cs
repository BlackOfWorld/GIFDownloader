using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GIFDownloader
{

    using retardConsole = System.Console;
    public static class Console
    {
        #region Wrapper
        public static string Title { get => retardConsole.Title; set => retardConsole.Title = value; }
        public static bool IsInputRedirected => retardConsole.IsInputRedirected;
        public static int BufferHeight { get => retardConsole.BufferHeight; set => retardConsole.BufferHeight = value; }
        public static int BufferWidth { get => retardConsole.BufferWidth; set => retardConsole.BufferWidth = value; }
        public static bool CapsLock => retardConsole.CapsLock;
        public static int CursorLeft { get => retardConsole.CursorLeft; set => retardConsole.CursorLeft = value; }
        public static int CursorSize { get => retardConsole.CursorSize; set => retardConsole.CursorSize = value; }
        public static int CursorTop { get => retardConsole.CursorTop; set => retardConsole.CursorTop = value; }
        public static bool CursorVisible { get => retardConsole.CursorVisible; set => retardConsole.CursorVisible = value; }
        public static TextWriter Error => retardConsole.Error;
        public static ConsoleColor ForegroundColor { get => retardConsole.ForegroundColor; set => retardConsole.ForegroundColor = value; }
        public static TextReader In => retardConsole.In;
        public static Encoding InputEncoding { get => retardConsole.InputEncoding; set => retardConsole.InputEncoding = value; }
        public static bool IsErrorRedirected => retardConsole.IsErrorRedirected;
        public static int WindowWidth { get => retardConsole.WindowWidth; set => retardConsole.WindowWidth = value; }
        public static bool IsOutputRedirected => retardConsole.IsOutputRedirected;
        public static bool KeyAvailable => retardConsole.KeyAvailable;
        public static int LargestWindowHeight => retardConsole.LargestWindowHeight;
        public static int LargestWindowWidth => retardConsole.LargestWindowWidth;
        public static bool NumberLock => retardConsole.NumberLock;
        public static TextWriter Out => retardConsole.Out;
        public static Encoding OutputEncoding { get => retardConsole.OutputEncoding; set => retardConsole.OutputEncoding = value; }
        public static bool TreatControlCAsInput { get => retardConsole.TreatControlCAsInput; set => retardConsole.TreatControlCAsInput = value; }
        public static int WindowHeight { get => retardConsole.WindowHeight; set => retardConsole.WindowHeight = value; }

        public static int WindowLeft { get => retardConsole.WindowLeft; set => retardConsole.WindowLeft = value; }
        public static int WindowTop { get => retardConsole.WindowTop; set => retardConsole.WindowTop = value; }
        public static ConsoleColor BackgroundColor { get => retardConsole.BackgroundColor; set => retardConsole.BackgroundColor = value; }
        public static event ConsoleCancelEventHandler CancelKeyPress;
        public static void Beep() => retardConsole.Beep();
        public static void Beep(int frequency, int duration) => retardConsole.Beep(frequency, duration);
        public static void Clear() => retardConsole.Clear();
        public static void MoveBufferArea(int sourceLeft, int sourceTop, int sourceWidth, int sourceHeight, int targetLeft, int targetTop) => retardConsole.MoveBufferArea(sourceLeft, sourceTop, sourceWidth, sourceHeight, targetLeft, targetTop);
        public static void MoveBufferArea(int sourceLeft, int sourceTop, int sourceWidth, int sourceHeight, int targetLeft, int targetTop, char sourceChar, ConsoleColor sourceForeColor, ConsoleColor sourceBackColor) => retardConsole.MoveBufferArea(sourceLeft, sourceTop, sourceWidth, sourceHeight, targetLeft, targetTop, sourceChar, sourceForeColor, sourceBackColor);
        public static Stream OpenStandardError(int bufferSize) => retardConsole.OpenStandardError(bufferSize);
        public static Stream OpenStandardError() => retardConsole.OpenStandardError();
        public static Stream OpenStandardInput(int bufferSize) => retardConsole.OpenStandardInput(bufferSize);
        public static Stream OpenStandardInput() => retardConsole.OpenStandardInput();
        public static Stream OpenStandardOutput(int bufferSize) => retardConsole.OpenStandardOutput(bufferSize);
        public static Stream OpenStandardOutput() => retardConsole.OpenStandardOutput();
        public static int Read() => retardConsole.Read();
        public static ConsoleKeyInfo ReadKey(bool intercept) => retardConsole.ReadKey(intercept);
        public static ConsoleKeyInfo ReadKey() => retardConsole.ReadKey();
        public static string ReadLine() => retardConsole.ReadLine();
        public static void ResetColor() => retardConsole.ResetColor();
        public static void SetBufferSize(int width, int height) => retardConsole.SetBufferSize(width, height);
        public static void SetCursorPosition(int left, int top) => retardConsole.SetCursorPosition(left, top);
        public static void SetError(TextWriter newError) => retardConsole.SetError(newError);
        public static void SetIn(TextReader newIn) => retardConsole.SetIn(newIn);
        public static void SetOut(TextWriter newOut) => retardConsole.SetOut(newOut);
        public static void SetWindowPosition(int left, int top) => retardConsole.SetWindowPosition(left, top);
        public static void SetWindowSize(int width, int height) => retardConsole.SetWindowSize(width, height);
        public static void Write(ulong value) => retardConsole.Write(value);
        public static void Write(bool value) => retardConsole.Write(value);
        public static void Write(char value) => retardConsole.Write(value);
        public static void Write(char[] buffer) => Write(new string(buffer));
        public static void Write(char[] buffer, int index, int count) => retardConsole.Write(buffer, index, count);
        public static void Write(double value) => retardConsole.Write(value);
        public static void Write(long value) => retardConsole.Write(value);
        public static void Write(object value) => Write(value.ToString());
        public static void Write(float value) => retardConsole.Write(value);
        public static void Write(string format, object arg0) => retardConsole.Write(format, arg0);
        public static void Write(string format, object arg0, object arg1) => retardConsole.Write(format, arg0, arg1);
        public static void Write(string format, object arg0, object arg1, object arg2) => retardConsole.Write(format, arg0, arg1, arg2);
        public static void Write(string format, params object[] arg) => retardConsole.Write(format, arg);
        public static void Write(uint value) => retardConsole.Write(value);
        public static void Write(decimal value) => retardConsole.Write(value);
        public static void Write(int value) => retardConsole.Write(value);
        public static void WriteLine(ulong value) => retardConsole.WriteLine(value);
        public static void WriteLine(string format, params object[] arg) => retardConsole.WriteLine(format, arg);
        public static void WriteLine() => retardConsole.WriteLine();
        public static void WriteLine(bool value) => retardConsole.WriteLine(value);
        public static void WriteLine(char[] buffer) => WriteLine(new string(buffer));
        public static void WriteLine(char[] buffer, int index, int count) => retardConsole.WriteLine(buffer, index, count);
        public static void WriteLine(decimal value) => retardConsole.WriteLine(value);
        public static void WriteLine(double value) => retardConsole.WriteLine(value);
        public static void WriteLine(uint value) => retardConsole.WriteLine(value);
        public static void WriteLine(int value) => retardConsole.WriteLine(value);
        public static void WriteLine(object value) => retardConsole.WriteLine(value);
        public static void WriteLine(float value) => retardConsole.WriteLine(value);
        public static void WriteLine(string format, object arg0) => retardConsole.WriteLine(format, arg0);
        public static void WriteLine(string format, object arg0, object arg1) => retardConsole.WriteLine(format, arg0, arg1);
        public static void WriteLine(string format, object arg0, object arg1, object arg2) => retardConsole.WriteLine(format, arg0, arg1, arg2);
        public static void WriteLine(long value) => retardConsole.WriteLine(value);
        public static void WriteLine(char value) => retardConsole.WriteLine(value);
        #endregion

        private static readonly Dictionary<char, ConsoleColor> Colours = new Dictionary<char, ConsoleColor>
        {
             { '0', ConsoleColor.Black             },
             { '1', ConsoleColor.DarkBlue          },
             { '2', ConsoleColor.DarkGreen         },
             { '3', ConsoleColor.DarkCyan          },
             { '4', ConsoleColor.DarkRed           },
             { '5', ConsoleColor.DarkMagenta       },
             { '6', ConsoleColor.Yellow            },
             { '7', ConsoleColor.Gray              },
             { '8', ConsoleColor.DarkGray          },
             { '9', ConsoleColor.Blue              },
             { 'a', ConsoleColor.Green             },
             { 'b', ConsoleColor.Cyan              },
             { 'c', ConsoleColor.Red               },
             { 'd', ConsoleColor.Magenta           },
             { 'e', ConsoleColor.Yellow            },
             { 'f', ConsoleColor.White             },
             { 'k', retardConsole.ForegroundColor  },
             { 'l', retardConsole.ForegroundColor  },
             { 'm', retardConsole.ForegroundColor  },
             { 'n', retardConsole.ForegroundColor  },
             { 'o', retardConsole.ForegroundColor  },
             { 'r', ConsoleColor.White             }
        };
        public static void WriteLine(string line)
        {
            for (var i = 0; i < line.Length; i++)
            {
                if (line[i] == '§' && Colours.ContainsKey(line[i + 1]))
                {
                    retardConsole.ForegroundColor = Colours[line[i + 1]];
                    continue;
                }
                if (i != 0 && line[i - 1] == '§' && Colours.ContainsKey(line[i])) continue;
                retardConsole.Write(line[i]);
            }
            retardConsole.WriteLine();
            retardConsole.ResetColor();
        }
        public static void Write(string line)
        {
            for (var i = 0; i < line.Length; i++)
            {
                if (line[i] == '§' && Colours.ContainsKey(line[i + 1]))
                {
                    retardConsole.ForegroundColor = Colours[line[i + 1]];
                    continue;
                }
                if (line[i - 1] == '§' && Colours.ContainsKey(line[i])) continue;
                retardConsole.Write(line[i]);
            }
            retardConsole.ResetColor();
        }
    }
}
