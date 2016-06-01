using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ioc0
{
    class Program
    {
        static void Main(string[] args)
        {
            ci0 c0 = new ci0();
            ctest c = new ctest(c0);
            c.doit();

            ci1  c1 = new ci1();
            c = new ctest(c1);
            c1.doit();
        }
    }

    public interface Istuff
    {
        void doit();
    }

    public class ctest : Istuff
    {
        public Istuff ist = null;
        public ctest(Istuff ci)
        {
            this.ist = ci;
        }

        public void doit()
        {
            ist.doit();
        }
    }

    public class ci0 : Istuff
    {
        public void doit()
        {
            Console.WriteLine("doit");
        }
    }

    public class ci1 : Istuff
    {
        public void doit()
        {
            Console.WriteLine("DOIT>>>>>>");
        }
    }



}
