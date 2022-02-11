using System.Drawing;

namespace SynthLiveMidiController.Picrutes
{
    static class VisualOptions
    {
        public static Font mainFont = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular);
        public static Font displayNameFont = new Font("Calibri", 14.25f, FontStyle.Regular); //new Font("Calibri", 14.25f, FontStyle.Regular);
        public static Font displayTempoFont = new Font("Calibri", 12.0f, FontStyle.Regular);
        public static Color mainTextColor = Color.YellowGreen;
        public static Color selTextColor = Color.Yellow;
        public static Color backgroundColor = Color.FromArgb(16, 16, 16);
        public static Color selBackgroundColor = Color.FromArgb(32, 32, 32);
        public static Color borderBackgroundColor = Color.Black;
        public static Pen borderPen = new Pen(borderBackgroundColor);
        public static Pen mainPen = new Pen(mainTextColor);
        public static Brush mainBrush = new SolidBrush(mainTextColor);
        public static Brush selBrush = new SolidBrush(selTextColor);
        public static Brush backgroundBrush = new SolidBrush(backgroundColor);
        public static Brush selBeckgroundBrush = new SolidBrush(selBackgroundColor);
        public static StringFormat mainStringFormat = new StringFormat
        {
            Alignment = StringAlignment.Center,
            LineAlignment = StringAlignment.Center
        };
        public static StringFormat leftStringFormat = new StringFormat
        {
            Alignment = StringAlignment.Near,
            LineAlignment = StringAlignment.Center,
        };
    }
}
