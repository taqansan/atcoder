using System;
using System.Collections.Generic;
using System.Linq;

namespace template
{
    class Program
    {
        static void Main(string[] args)
        {
            new Program().Solve(new ConsoleInput(Console.In, ' '));
        }

        public void Solve(ConsoleInput cin)
        {
            var S = cin.Read.Reverse();
            var words = new string[] { "maerd", "remaerd", "esare", "resare" };
            var flag = true;
            for (int i = 0; i < S.Length;)
            {
                var flag2 = false;
                foreach (var x in words)
                {
                    if (S.Length - i < x.Length) 
                    {
                        continue;
                    }

                    if (S.Substring(i, x.Length) == x) 
                    {
                        flag2 = true; 
                        i += x.Length;
                        break;
                    }
                }
                if (!flag2) 
                { 
                    flag = false; 
                    break;
                }
            }
            
            if (flag) 
            {
                Console.WriteLine("YES");
            }
            else 
            {
                Console.WriteLine("NO");
            }
        }
    }

    public static class Extensions
    {
        public static string Reverse(this string sourse)
        {
            char[] chrAry = sourse.ToCharArray();
            Array.Reverse(chrAry);
            return new string(chrAry);
        }
    }

    public class ConsoleInput
    {
        private readonly System.IO.TextReader _stream;
        private char _separator = ' ';
        private Queue<string> inputStream;
        public ConsoleInput(System.IO.TextReader stream, char separator = ' ')
        {
            this._separator = separator;
            this._stream = stream;
            inputStream = new Queue<string>();
        }
        public string Read
        {
            get
            {
                if (inputStream.Count != 0) 
                {
                    return inputStream.Dequeue();
                }

                string[] tmp = _stream.ReadLine().Split(_separator);
                
                for (int i = 0; i < tmp.Length; ++i)
                {
                    inputStream.Enqueue(tmp[i]);
                }
                return inputStream.Dequeue();
            }
        }
        public string ReadLine { get { return _stream.ReadLine(); }}
        public int ReadInt { get { return int.Parse(Read); }}
        public long ReadLong { get { return long.Parse(Read); }}
        public double ReadDouble { get { return double.Parse(Read); }}
        public string[] ReadStrArray(long N) { var ret = new string[N]; for (long i = 0; i < N; ++i) ret[i] = Read; return ret;}
        public int[] ReadIntArray(long N) { var ret = new int[N]; for (long i = 0; i < N; ++i) ret[i] = ReadInt; return ret;}
        public long[] ReadLongArray(long N) { var ret = new long[N]; for (long i = 0; i < N; ++i) ret[i] = ReadLong; return ret;}
    }
}
