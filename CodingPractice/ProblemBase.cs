namespace CodingPractice
{
    public abstract class ProblemBase
    {
        public abstract string Title { get; }

        public abstract string Description { get; }
    }

    public abstract class ProblemBaseT<TIn, TOut> : ProblemBase
    {
        public abstract TOut Solve(TIn input);
    }
}
