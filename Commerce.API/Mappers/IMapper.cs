namespace Commerce.API.Mappers
{
    public interface IMapper<TIn, TOut>
    {
        void Fill(TIn input, TOut output);
        TOut Map(TIn input);
    }
}
