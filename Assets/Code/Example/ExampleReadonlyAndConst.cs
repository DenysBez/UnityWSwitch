namespace Lesson
{
    public sealed class ExampleReadonlyAndConst
    {
        public const string Name = "Name";
        
        private readonly int _maxHealth = 100;
        
        public int MinHealth { get; private set; } = 0;

        public ExampleReadonlyAndConst()
        {
            _maxHealth = 100;
        }
        private void NameMethod()
        {
            //_maxHealth = 1;
        }
    }

    public readonly struct MyStruct
    {
        public int MinHealth { get; }
        public readonly int MaxHealth;
    }
}
