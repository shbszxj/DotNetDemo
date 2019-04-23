using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConcurrentQueue.Test
{
    class Program
    {
        static int inputs = 600;

        static void Main()
        {
            // The token source for issuing the cancelation request.
            CancellationTokenSource cts = new CancellationTokenSource();

            // A blocking collection that can hold no more than 100 items at a time.
            BlockingCollection<int> numberCollection = new BlockingCollection<int>(100);

            // Set console buffer to hold our prodigious output.
            //Console.SetBufferSize(80, 2000);

            // The simplest UI thread ever invented.
            Task.Run(() =>
            {
                if (Console.ReadKey(true).KeyChar == 'c')
                    cts.Cancel();
            });

            Stopwatch watch = new Stopwatch();
            watch.Start();

            // Start one producer and one consumer.
            Task t1 = Task.Run(() => NonBlockingConsumer(numberCollection, cts.Token));
            Task t2 = Task.Run(() => NonBlockingProducer(numberCollection, cts.Token));

            // Wait for the tasks to complete execution
            Task.WaitAll(t1, t2);
            watch.Stop();
            cts.Dispose();
            Console.WriteLine($"Add total {inputs} takes : {watch.Elapsed.TotalSeconds}");
            Console.WriteLine("Press the Enter key to exit.");
            Console.ReadLine();
        }

        static void NonBlockingConsumer(BlockingCollection<int> bc, CancellationToken ct)
        {
            // IsCompleted == (IsAddingCompleted && Count == 0)
            while (!bc.IsCompleted)
            {
                int nextItem = 0;
                try
                {
                    if (!bc.TryTake(out nextItem, 0, ct))
                    {
                        //Console.WriteLine($" Take Blocked; Thread: {Thread.CurrentThread.ManagedThreadId}");
                    }
                    else
                        Console.WriteLine($" Take:{nextItem}; Thread: {Thread.CurrentThread.ManagedThreadId}");
                }

                catch (OperationCanceledException)
                {
                    Console.WriteLine("Taking canceled.");
                    break;
                }

                // Slow down consumer just a little to cause
                // collection to fill up faster, and lead to "AddBlocked"
                Thread.SpinWait(500000);
            }

            Console.WriteLine("\r\nNo more items to take.");
        }

        static void NonBlockingProducer(BlockingCollection<int> bc, CancellationToken ct)
        {
            int itemToAdd = 0;
            bool success = false;

            do
            {
                // Cancellation causes OCE. We know how to handle it.
                try
                {
                    // A shorter timeout causes more failures.
                    success = bc.TryAdd(itemToAdd, 2, ct);
                }
                catch (OperationCanceledException)
                {
                    Console.WriteLine("Add loop canceled.");
                    // Let other threads know we're done in case
                    // they aren't monitoring the cancellation token.
                    bc.CompleteAdding();
                    break;
                }

                if (success)
                {
                    Console.WriteLine($" Add:{itemToAdd}; Thread:{Thread.CurrentThread.ManagedThreadId}");
                    itemToAdd++;
                }
                else
                {
                    //Console.Write($" AddBlocked:{itemToAdd} Count = {bc.Count}; Thread:{Thread.CurrentThread.ManagedThreadId}");
                    // Don't increment nextItem. Try again on next iteration.

                    //Do something else useful instead.
                    UpdateProgress(itemToAdd);
                }

            } while (itemToAdd < inputs);

            // No lock required here because only one producer.
            bc.CompleteAdding();
        }

        static void UpdateProgress(int i)
        {
            double percent = ((double)i / inputs) * 100;
            Console.WriteLine("Percent complete: {0}", percent);
        }
    }
}
