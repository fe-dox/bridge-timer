namespace TCTimer
{
    public class CheckListOption<T>
    {
        public string Text;
        public T Value;

        public CheckListOption(string text, T value)
        {
            Text = text;
            Value = value;
        }

        public override string ToString()
        {
            return Text;
        }
    }
}