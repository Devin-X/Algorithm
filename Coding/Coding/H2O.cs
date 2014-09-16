using System;
using System.Threading;

namespace Coding
{
    class H2O
    {
        private static Semaphore _H = new Semaphore(0, 20);
        private static Semaphore _O = new Semaphore(0, 20);

        private static int _hCount = 0;
        private static int _oCount = 0;

        //public H2O()
        //{
        //    _H = new Semaphore(0, 2);
        //    _O = new Semaphore(0, 1);
        //}

        public static void H(object num)
        {
            //Thread.Sleep(10);
            //if (_hCount > 1 && _oCount > 0)
            //{
            //    _hCount -= 2;
            //    _oCount -= 1;
            //    _H.Release(2);
            //    _O.Release();
            //    Console.WriteLine("H H2O made!");
            //}

            //_hCount ++;
            //_O.WaitOne();
            //Console.WriteLine("H H2O made!");
            _H.Release();
        }

        public static void O(object num)
        {
            //if (_hCount > 1 && _oCount > 0)
            //{
            //    _hCount -= 2;
            //    _oCount -= 1;
            //    _H.Release(2);
            //    _O.Release();
            //    Console.WriteLine("O H2O made!");
            //}

            //_oCount++;
            _H.WaitOne();
            _H.WaitOne();
            Console.WriteLine("O H2O made!");
            _O.Release();
        }


        public static void Simulate()
        {
            for (int i = 0; i < 20; i++)
            {
                Thread hWorker = new Thread(new ParameterizedThreadStart(H2O.H));
                hWorker.Start();
            }
            for (int i = 0; i < 10; i++)
            {
                Thread oWorker = new Thread(new ParameterizedThreadStart(H2O.O));
                oWorker.Start();
            }
        }
    }
}
