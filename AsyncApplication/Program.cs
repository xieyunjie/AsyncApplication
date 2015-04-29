using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncApplication
{
    class Program
    {
        #region Async2
        static void Main(string[] args)
        {
            Console.WriteLine(DateTime.Now.ToLongTimeString());

            var qTask = GetQuickValueAsync("quick");
            var sTask = GetSlowValueAsync("slow");

            Task.WaitAll(qTask, sTask);
             
            Console.WriteLine(qTask.Result);
            Console.WriteLine(sTask.Result); 


            Console.WriteLine(DateTime.Now.ToLongTimeString()); 


            Console.ReadKey();
        }


        static async Task<string> GetQuickValueAsync(string v)
        {
            return await Task.Run<string>(() =>
            {
                Thread.Sleep(3 * 1000);
                return string.Format("this is QuickString,the value is {0},datetime is {1}", v, DateTime.Now.ToLongTimeString());
            
            });
        }

        static async Task<string> GetSlowValueAsync(string v)
        {
            return await Task.Run<string>(() =>
            {
                Thread.Sleep(10 * 1000);
                return string.Format("this is SlowString,the value is {0},datetime is {1}", v, DateTime.Now.ToLongTimeString());

            });
        }

        #endregion


        #region Async1
        /// <summary>
        /// Async 1
        /// </summary>
        /// <param name="args"></param>
        static void Mainx(string[] args)
        {

            Console.WriteLine(DateTime.Now.ToLongTimeString());

            DisplaySlowValue();

            DisplayQuickValue();

            Console.ReadKey();
        }
         
 
        static async void DisplayQuickValue()
        {
            string result = await GetQuickString("Quick");
            Console.WriteLine(result);
        }

        static async void DisplaySlowValue()
        {
            string result = await GetSlowString("Slow");
            Console.WriteLine(result);
        }
         

        static Task<string> GetQuickString(string value)
        {
            return Task.Run<string>(() =>
            {
                Thread.Sleep(3 * 1000);
                return string.Format("this is QuickString,the value is {0},datetime is {1}", value, DateTime.Now.ToLongTimeString());
            });
        }

        static Task<string> GetSlowString(string value)
        {
            return Task.Run<string>(() =>
            {
                Thread.Sleep(10 * 1000);
                return string.Format("this is SlowString,the value is {0},datetime is {1}", value, DateTime.Now.ToLongTimeString());
            });
        }
        #endregion
    }
}
