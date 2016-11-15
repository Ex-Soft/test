using System;
using EvalServiceLibrary;

namespace EvalServiceLibraryClient
{
    class Program
    {
        static void Main(string[] args)
        {
            EvalServiceClient
                evalServiceClient = new EvalServiceClient();

            Eval
                eval;

            eval = new Eval { Comments = "CommentsField1", Submitter = "Submitter1", TimeSubmitted = DateTime.Now};
            evalServiceClient.SubmitEval(eval);
            eval = new Eval { Comments = "CommentsField2", Submitter = "Submitter2", TimeSubmitted = DateTime.Now };
            evalServiceClient.SubmitEval(eval);
            eval = new Eval { Comments = "CommentsField3", Submitter = "Submitter3", TimeSubmitted = DateTime.Now };
            evalServiceClient.SubmitEval(eval);

            Eval[]
                evals = evalServiceClient.GetEvals();

            foreach(Eval e in evals)
                Console.WriteLine("{0}\t{1}\t{2}", e.Id, e.Submitter, e.TimeSubmitted);

            evalServiceClient.Close();

            Console.ReadLine();
        }
    }
}
