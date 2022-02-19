namespace SynthLiveMidiController
{
    public partial class CtlPerformanceNameField : CtlStringField
    {
        public CtlPerformanceNameField()
        {
            InitializeComponent();

            caption = "Perf:";
        }

        protected override string ValidateValue(string argument)
        {
            int length = argument.Length;
            string res;
            if (length > 12)
            {
                res = argument.Remove(12, length - 12);
            }
            else if (length < 12)
            {
                res = argument.PadRight(12);
            }
            else
            {
                res = argument;
            }
            return res;
        }
    }
}
