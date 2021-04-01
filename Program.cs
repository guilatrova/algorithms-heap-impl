using System;

namespace heaps
{
    class Program
    {
        static Heap heap = new Heap(10);

        static string ask(string msg) {
            Console.ForegroundColor = ConsoleColor.Yellow;
            System.Console.WriteLine();
            System.Console.WriteLine(msg);
            Console.ResetColor();
            return Console.ReadLine();
        }

        static void addNumber(int n) {
            heap.add(n);
        }

        static void pop() {
            var n = heap.pop();
            Console.ForegroundColor = ConsoleColor.Yellow;
            System.Console.WriteLine($"* Popped {n}");
            Console.ResetColor();
        }

        static void print() {
            Console.ForegroundColor = ConsoleColor.Blue;
            System.Console.WriteLine();
            System.Console.WriteLine("********** Here's your Heap:");
            Console.ResetColor();
            heap.debug();
        }

        static void Main(string[] args)
        {
            string input;
            int addN;

            do {
                input = ask("What value you want to add? (Type bare number to add, tap - to pop)");
                bool isNumeric = int.TryParse(input, out addN);

                if (isNumeric) {
                    addNumber(addN);
                }
                else if (input == "-") {
                    pop();
                }

                print();

            } while (input != "");

            for (var i = 1; i <= 10; i++) {
                heap.add(i);
                heap.debug();
            }
        }
    }
}
