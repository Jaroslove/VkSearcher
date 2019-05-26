using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Word;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var p = new Program();

            var re = p.GetHash("Artem19/03/2019MoskJoys&Enjoy");

            Console.WriteLine(re);
        }

        const string SALT = "S0m3R@nd0mSalt";

        string GetHash(string pass)
        {
            var provider = MD5.Create();

            byte[] bytes = provider.ComputeHash(Encoding.ASCII.GetBytes(SALT + pass));

            string computedHash = BitConverter.ToString(bytes);

            return computedHash.Replace("-", "");
        }
    }

    class O
    {
        public int GetOne()
        {            
            return 1;
        }
    }

    class Some
    {
        public int One { get; set; }
        public int Two { get; set; }
        public int Three { get; set; }
        public int Four { get; set; }
        public int Five { get; set; }
        public int Six { get; set; }
        public int Seven { get; set; }
        public int Eigth { get; set; }
        public int Nine { get; set; }
        public DateTime Ten { get; set; }
        public int Eleven { get; set; }

        public string NameConstr { get; set; }

        public string CommentFrom { get; set; }
        public string CommentTo { get; set; }
    }

    interface IProgress<T> where T : struct
    {
        void Report(T t);

        event Action<object, T> ProgressChanged;

        T PercentComplete { get; set; }
    }

    class Progress<T> : IProgress<T> where T : struct
    {
        public event Action<object, T> ProgressChanged;

        public T PercentComplete { get; set; }

        public void Report(T t)
        {
            ProgressChanged?.Invoke(this, t);
        }
    }

    class MyCancelationTokenSource
    {
        public bool IsCancellationRequested { get; private set; }
        
        public MyTokenSource Token { get; private set; }

        public MyCancelationTokenSource()
        {
           Token = new MyTokenSource(this);
        }

        public void Cancel()
        {
            IsCancellationRequested = true;
        }
    }

    struct MyTokenSource
    {
        MyCancelationTokenSource cts;

        public MyTokenSource(MyCancelationTokenSource source)
        {
            cts = source;
        }

        public void ThrowIfCancelationRequsted()
        {
            if (cts.IsCancellationRequested)
            {
                throw new Exception();
            }
        }
    }
}
