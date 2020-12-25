using System;
using System.Diagnostics;
using System.Text;

namespace DesignPatternsInCSharpAnddotNet
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var person = new PersonBuilder()
                .Called("Tom")
                .WorkAs("Engineer")
                .Build();
            Console.WriteLine(person);
        }
    }
}