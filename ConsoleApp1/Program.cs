using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            InfoDal infoDal = new InfoDal();
            var a = infoDal.GetTitleNums("es");
            Console.WriteLine(a);
            Console.ReadKey();
        }
    }
}
