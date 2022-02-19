namespace SynthLiveMidiController
{
    public partial class CtlChannelField : CtlByteField
    {
        public CtlChannelField()
        {
            InitializeComponent();
            _value = 1;
            caption = "Chan:";
            min = 1;
            max = 16;
        }

        // ByteValue
        public override byte ByteValue
        {
            get { return (byte)(_value - 1); }
            set
            {
                int res = ValidateValue(value + 1);
                _value = res;
            }
        }
    }
}
