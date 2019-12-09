namespace AdventOfCode2019.Day9
{
    public interface IRelativBaseModifier
    {
        void Update(long change);
    }

    public interface IRelativBase
    {
        long Get();
    }

    public class RelativeBase: IRelativBase, IRelativBaseModifier
    {
        private long _relativeBase = 0;

        public long Get()
        {
            return _relativeBase;
        }

        public void Update(long change)
        {
            _relativeBase += change;
        }
    }
}