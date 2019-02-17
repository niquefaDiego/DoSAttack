using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DoSAttack
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Task> tasks = new List<Task>();
            for ( int i = 0; i < 1000; ++i )
            {
                tasks.Add(new Task( () =>
                {
                    using (var wc = new WebClient())
                    {
                        wc.Headers.Add(
                                "X-Mashape-Authorization", "1R1tvmPFLFL7brrvfO9jvsqnvhiVggAn");
                        var body = wc.DownloadString("https://localhost:44390/?IsPalindrome=true&IsCircular=true&IsRightTruncable=true");
                        Console.WriteLine(body);
                    }
                }));
            }
            Task.WaitAll(tasks.ToArray());
        }
    }
}
