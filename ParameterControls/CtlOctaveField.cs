using System.Drawing;

namespace SynthLiveMidiController
{
    public partial class CtlOctaveField : CtlByteField
    {
        // Constructor
        public CtlOctaveField()
        {
            InitializeComponent();
            _value = 0;
            caption = "Oct:";
            min = -3;
            max = 3;
        }

        // ByteValue
        public override byte ByteValue 
        {
            get { return (byte)(_value + 3); }
            set 
            { 
                int res = ValidateValue(value - 3);
                _value = res;
            }
        }
    }
}
