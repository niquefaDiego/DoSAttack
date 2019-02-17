using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace DoSAttack
{
    class Program
    {
        static string request = "https://localhost:44390/?IsPalindrome=true&IsCircular=true&IsRightTruncable=true";
        static void MakeRequest() {
            using (var wc = new WebClient()) {
                wc.Headers.Add(
                        "X-Mashape-Authorization", "1R1tvmPFLFL7brrvfO9jvsqnvhiVggAn");
                var body = wc.DownloadString(request);
                Console.WriteLine(body);
            }
        }
        static void Main(string[] args) {
            List<Task> tasks = new List<Task>();
            for ( int i = 0; i < 1000; ++i ) {
                Task t = new Task(() => MakeRequest());
                t.Start();
                tasks.Add(t);
            }
            Task.WaitAll(tasks.ToArray());
        }
    }
}
