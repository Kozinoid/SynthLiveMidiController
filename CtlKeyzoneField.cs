using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SynthLiveMidiController.Pictures;

namespace SynthLiveMidiController
{
    public partial class CtlKeyzoneField : UserControl
    {
        //private static readonly KeyboardPicture picture = new KeyboardPicture();
        private readonly Keyboard kbd = new Keyboard();

        private int lowerX = 0;
        private int upperX = 0;

        private const int minKey = 0;
        private const int maxKey = 60;
        private int lowerKey = minKey;
        private int upperKey = maxKey;
        public int LowerKey
        {
            get { return lowerKey; }
            set
            {
                lowerKey = value;
                if (lowerKey < minKey) lowerKey = minKey;
                if (lowerKey > maxKey) lowerKey = maxKey;
                if (lowerKey > upperKey) upperKey = lowerKey;
                CalculateBounds();
                this.Invalidate();
            }
        }
        public int UpperKey
        {
            get { return upperKey; }
            set
            {
                upperKey = value;
                if (upperKey > maxKey) upperKey = maxKey;
                if (upperKey < minKey) upperKey = minKey;
                if (upperKey < lowerKey) lowerKey = upperKey;
                CalculateBounds();
                this.Invalidate();
            }
        }

        public CtlKeyzoneField()
        {
            InitializeComponent();
            CalculateBounds();
        }

        private void CalculateBounds()
        {
            lowerX = lowerKey * KeyboardPicture.up_width + KeyboardPicture.up_width / 2 + 1;
            upperX = upperKey * KeyboardPicture.up_width + KeyboardPicture.up_width / 2 + 1;
        }

        private void CtlKeyzoneField_Paint(object sender, PaintEventArgs e)
        {
            ImageAttributes ia = new ImageAttributes();

            ia.SetWrapMode(WrapMode.TileFlipXY, Color.Red);

            Point[] points = {
                new Point(lowerX, 0),
                new Point(upperX, 0),
                new Point(upperX, KeyboardPicture.all_height),
                new Point(lowerX, KeyboardPicture.all_height)
            };

            LinearGradientBrush brush = new LinearGradientBrush(new PointF(0, 0), new PointF(0, KeyboardPicture.all_height), Color.FromArgb(128, ForeColor), Color.FromArgb(128, BackColor));

            //picture.DrawKeyboard(e.Graphics, new Point(0, 0));
            kbd.Draw(e.Graphics);
            //e.Graphics.FillPolygon(brush, points, FillMode.Winding);
        }
    }

    public class NoteKey
    {
        readonly Point[] pointsArray;
        readonly Color fillBrushColor;
        readonly Color borderPenColor;

        public NoteKey(Point[] points, Color brushColor, Color penColor)
        {
            pointsArray = points;
            fillBrushColor = brushColor;
            borderPenColor = penColor;
        }

        public void Draw(Graphics gr, bool selected)
        {
            Brush brush = new SolidBrush(fillBrushColor);
            gr.FillPolygon(brush, pointsArray);

            if (selected)
            {
                Brush brushSel = new SolidBrush(Color.FromArgb(64, Color.Blue));
                gr.FillPolygon(brushSel, pointsArray);
            }

            Pen pen = new Pen(borderPenColor);
            gr.DrawPolygon(pen, pointsArray);
        }
    }

    public class Keyboard
    {
        private readonly Pen kbdPen = new Pen(Color.Black);
        private readonly Brush kbdWhiteBrush = Brushes.White;
        private readonly Brush kbdBlackBrush = Brushes.DarkSlateGray;

        public const int min = 0;
        public const int max = 60;
        private readonly int lower = 34;
        private readonly int upper = 52;

        private readonly List<NoteKey> keyList = new List<NoteKey>();
        private readonly KeyboardPicture  picture = new KeyboardPicture();

        public Keyboard()
        {
            for (int i = min; i < max; i++)
            {
                NoteKey key = new NoteKey(picture.GetKeyPoints(i), GetBrushColor(i), Color.Black);
                keyList.Add(key);
            }
        }

        public void Draw(Graphics gr)
        {
            for (int i = min; i < max; i++)
            {
                bool sel = false;
                if ((i >= lower) && (i <= upper)) sel = true;
                keyList[i].Draw(gr, sel);
            }
        }

        public Color GetBrushColor(int keyNumber)
        {
            switch (keyNumber % 12)
            {
                case 0:
                case 2:
                case 4:
                case 5:
                case 7:
                case 9:
                case 11:
                    return Color.White;
                case 1:
                case 3:
                case 6:
                case 8:
                case 10:
                    return Color.DarkSlateGray;
                default:
                    return Color.DarkSlateGray;
            }
        }
    }
}
