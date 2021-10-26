using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace TestDataflowSimple
{
    public class SlidingWindow
    {
        // Creates a IPropagatorBlock<T, T[]> object propagates data in a
        // sliding window fashion.
        public static IPropagatorBlock<T, T[]> CreateSlidingWindow<T>(int windowSize)
        {
            // Create a queue to hold messages.
            var queue = new Queue<T>();

            // The source part of the propagator holds arrays of size windowSize
            // and propagates data out to any connected targets.
            var source = new BufferBlock<T[]>();

            // The target part receives data and adds them to the queue.
            var target = new ActionBlock<T>(item =>
            {
                // Add the item to the queue.
                queue.Enqueue(item);
                // Remove the oldest item when the queue size exceeds the window size.
                if (queue.Count > windowSize)
                    queue.Dequeue();
                // Post the data in the queue to the source block when the queue size
                // equals the window size.
                if (queue.Count == windowSize)
                    source.Post(queue.ToArray());
            });

            // When the target is set to the completed state, propagate out any
            // remaining data and set the source to the completed state.
            target.Completion.ContinueWith(delegate
            {
                if (queue.Count > 0 && queue.Count < windowSize)
                    source.Post(queue.ToArray());
                source.Complete();
            });

            // Return a IPropagatorBlock<T, T[]> object that encapsulates the
            // target and source blocks.
            return DataflowBlock.Encapsulate(target, source);
        }

        // Demonstrates usage of the sliding window block by sending the provided
        // values to the provided propagator block and printing the output of
        // that block to the console.
        static void DemonstrateSlidingWindow<T>(IPropagatorBlock<T, T[]> slidingWindow,
            IEnumerable<T> values)
        {
            // Create an action block that prints arrays of data to the console.
            string windowComma = string.Empty;
            var printWindow = new ActionBlock<T[]>(window =>
            {
                Console.Write(windowComma);
                Console.Write("{");

                string comma = string.Empty;
                foreach (T item in window)
                {
                    Console.Write(comma);
                    Console.Write(item);
                    comma = ",";
                }
                Console.Write("}");

                windowComma = ", ";
            });

            // Link the printer block to the sliding window block.
            slidingWindow.LinkTo(printWindow);

            // Set the printer block to the completed state when the sliding window
            // block completes.
            slidingWindow.Completion.ContinueWith(delegate { printWindow.Complete(); });

            // Print an additional newline to the console when the printer block completes.
            var completion = printWindow.Completion.ContinueWith(delegate { Console.WriteLine(); });

            // Post the provided values to the sliding window block and then wait
            // for the sliding window block to complete.
            foreach (T value in values)
            {
                slidingWindow.Post(value);
            }
            slidingWindow.Complete();

            // Wait for the printer to complete and perform its final action.
            completion.Wait();
        }

        public static void Run()
        {
            Console.Write("Using the DataflowBlockExtensions.Encapsulate method ");
            Console.WriteLine("(T=int, windowSize=3):");
            DemonstrateSlidingWindow(CreateSlidingWindow<int>(3), Enumerable.Range(0, 10));

            Console.WriteLine();

            var slidingWindow = new SlidingWindowBlock<char>(4);

            Console.Write("Using SlidingWindowBlock<T> ");
            Console.WriteLine("(T=char, windowSize={0}):", slidingWindow.WindowSize);
            DemonstrateSlidingWindow(slidingWindow, from n in Enumerable.Range(65, 10)
                select (char)n);
        }
    }

    // Propagates data in a sliding window fashion.
    public class SlidingWindowBlock<T> : IPropagatorBlock<T, T[]>,
                                         IReceivableSourceBlock<T[]>
    {
        // The size of the window.
        private readonly int m_windowSize;
        // The target part of the block.
        private readonly ITargetBlock<T> m_target;
        // The source part of the block.
        private readonly IReceivableSourceBlock<T[]> m_source;

        // Constructs a SlidingWindowBlock object.
        public SlidingWindowBlock(int windowSize)
        {
            // Create a queue to hold messages.
            var queue = new Queue<T>();

            // The source part of the propagator holds arrays of size windowSize
            // and propagates data out to any connected targets.
            var source = new BufferBlock<T[]>();

            // The target part receives data and adds them to the queue.
            var target = new ActionBlock<T>(item =>
            {
                // Add the item to the queue.
                queue.Enqueue(item);
                // Remove the oldest item when the queue size exceeds the window size.
                if (queue.Count > windowSize)
                    queue.Dequeue();
                // Post the data in the queue to the source block when the queue size
                // equals the window size.
                if (queue.Count == windowSize)
                    source.Post(queue.ToArray());
            });

            // When the target is set to the completed state, propagate out any
            // remaining data and set the source to the completed state.
            target.Completion.ContinueWith(delegate
            {
                if (queue.Count > 0 && queue.Count < windowSize)
                    source.Post(queue.ToArray());
                source.Complete();
            });

            m_windowSize = windowSize;
            m_target = target;
            m_source = source;
        }

        // Retrieves the size of the window.
        public int WindowSize { get { return m_windowSize; } }

        #region IReceivableSourceBlock<TOutput> members

        // Attempts to synchronously receive an item from the source.
        public bool TryReceive(Predicate<T[]> filter, out T[] item)
        {
            return m_source.TryReceive(filter, out item);
        }

        // Attempts to remove all available elements from the source into a new
        // array that is returned.
        public bool TryReceiveAll(out IList<T[]> items)
        {
            return m_source.TryReceiveAll(out items);
        }

        #endregion

        #region ISourceBlock<TOutput> members

        // Links this dataflow block to the provided target.
        public IDisposable LinkTo(ITargetBlock<T[]> target, DataflowLinkOptions linkOptions)
        {
            return m_source.LinkTo(target, linkOptions);
        }

        // Called by a target to reserve a message previously offered by a source
        // but not yet consumed by this target.
        bool ISourceBlock<T[]>.ReserveMessage(DataflowMessageHeader messageHeader,
           ITargetBlock<T[]> target)
        {
            return m_source.ReserveMessage(messageHeader, target);
        }

        // Called by a target to consume a previously offered message from a source.
        T[] ISourceBlock<T[]>.ConsumeMessage(DataflowMessageHeader messageHeader,
           ITargetBlock<T[]> target, out bool messageConsumed)
        {
            return m_source.ConsumeMessage(messageHeader,
               target, out messageConsumed);
        }

        // Called by a target to release a previously reserved message from a source.
        void ISourceBlock<T[]>.ReleaseReservation(DataflowMessageHeader messageHeader,
           ITargetBlock<T[]> target)
        {
            m_source.ReleaseReservation(messageHeader, target);
        }

        #endregion

        #region ITargetBlock<TInput> members

        // Asynchronously passes a message to the target block, giving the target the
        // opportunity to consume the message.
        DataflowMessageStatus ITargetBlock<T>.OfferMessage(DataflowMessageHeader messageHeader,
           T messageValue, ISourceBlock<T> source, bool consumeToAccept)
        {
            return m_target.OfferMessage(messageHeader,
               messageValue, source, consumeToAccept);
        }

        #endregion

        #region IDataflowBlock members

        // Gets a Task that represents the completion of this dataflow block.
        public Task Completion { get { return m_source.Completion; } }

        // Signals to this target block that it should not accept any more messages,
        // nor consume postponed messages.
        public void Complete()
        {
            m_target.Complete();
        }

        public void Fault(Exception error)
        {
            m_target.Fault(error);
        }

        #endregion
    }
}
