namespace AdventOfCode2019.Day9
{
    public interface IRelativBaseModifier
    {
        void Update(int change);
    }

    public interface IRelativBase
    {
        int Get();
    }

    public class RelativeBase: IRelativBase, IRelativBaseModifier
    {
        private int _relativeBase = 0;

        public int Get()
        {
            return _relativeBase;
        }

        public void Update(int change)
        {
            _relativeBase += change;
        }
    }
}