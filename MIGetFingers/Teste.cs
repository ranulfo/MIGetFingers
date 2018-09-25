using System;
using System.Collections.Generic;
using System.Text;

namespace MIGetFingers
{
    internal class Teste
    {
        //MIGetFingers.Fingers obj = new Fingers();
        //obj.Ge
        static void Main()
        {
            MIGetFingers.Fingers obj = new Fingers();
            object template =null;
            bool ok = false;
            try
            {
                //if (obj.GetFinger(ref template, 119463404, 3)) //INVALID
                if (obj.GetFinger(ref template, 290811611, 3))
                {

                    ok = true;
                }
                else
                {
                    System.Console.WriteLine("erro!");
                }
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
            }
        }
    }
}
