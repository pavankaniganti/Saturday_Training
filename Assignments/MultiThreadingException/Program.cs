using System;
using System.Threading;

public class Program
{
    public static void Main(string[] args)
    {
        // Create a new thread
        Thread thread = new Thread(SecondThread);
        //start the thread
        thread.Start();
        Console.WriteLine("Main thread continues...");

        //Work in the main thread
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine($"Main thread working... {i}");
            Thread.Sleep(1000);
        }

        // Wait for the second thread to complete
        thread.Join();

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }

    public static void SecondThread()
    {
        try
        {
            //Work in the second thread
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Second thread working... {i}");
                Thread.Sleep(500);

                //Exception Handle
                if (i == 7)
                    throw new Exception("Something went wrong in the second thread!");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception caught in the second thread: {ex.Message}");
            // Log the exception or perform any necessary actions
        }
    }
}

