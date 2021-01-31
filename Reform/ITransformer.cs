namespace Reform
{
    public interface ITransformer<TTo, TFrom>
    {
        public TTo Transform(TFrom from);
        public bool TryTransform(TFrom from, out TTo to);
    }
}