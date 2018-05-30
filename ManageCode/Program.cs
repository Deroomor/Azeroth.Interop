using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ManageCode
{
    public delegate int Function(int v1,int v2);

    public class Program
    {
        [System.Runtime.InteropServices.DllImport("NativeC.dll")]
        public static extern int Add(int v1,int v2);

        //P/Invoke中不能使用泛型的委托，所以定义一个与原方法中callback函数指针方法签名一致的委托
        [System.Runtime.InteropServices.DllImport("NativeC.dll")]
        public static extern int Handler(IntPtr str,Function callback);

        static void Main(string[] args)
        {
            int rst= Add(1,2);//
            IntPtr str= System.Runtime.InteropServices.Marshal.StringToHGlobalAnsi("hello world");
            int rst2 = Handler(str, new Function(RT));
            Console.ReadKey();
        }

        static int RT(int v1, int v2)
        {
            return v1 * 2 + v2 * 3;
        }
    }
}
