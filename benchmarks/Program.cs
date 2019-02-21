using System;
using BenchmarkDotNet.Running;
using test;

namespace benchmarks
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<Rendering>();
        }
    }
}
