using System;
using System.Collections.Generic;
using System.Linq;
using static System.Math;

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
            var N = cin.ReadInt;
            var t = new int[N + 1];
            var x = new int[N + 1];
            var y = new int[N + 1];
            y[0] = x[0] = y[0] = 0;
            for (int i = 1; i <= N; i++)
            {
                t[i] = cin.ReadInt;
                x[i] = cin.ReadInt;
                y[i] = cin.ReadInt;
            }

            bool flag = true;
            for (int i = 0; i < N; ++i)
            {
                var time = t[i + 1] - t[i];
                var dist = Abs(x[i + 1] - x[i]) + Abs(y[i + 1] - y[i]);
                
                if (time < dist) 
                {
                    flag = false;
                    break;
                }
                
                if (time % 2 != dist % 2) 
                {
                    flag = false;
                    break;
                }
            }

            if (flag) 
            {
                Console.WriteLine("Yes");
            }
            else 
            {
                Console.WriteLine("No");
            }
 
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
