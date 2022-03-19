using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using SynthLiveMidiController.Pictures;
using System.Collections.Generic;

namespace SynthLiveMidiController.ParameterControls
{
    public partial class CtlKeyzoneField : UserControl
    {
        public event EventHandler KeyRangeChanged = null;

        private readonly Keyboard kbd = new Keyboard();
        private bool left = false;
        private bool right = false;
        public int LowerKey
        {
            get { return kbd.LowerKey; }
            set
            {
                kbd.LowerKey = value;
                this.Invalidate();
            }
        }
        public int UpperKey
        {
            get { return kbd.UpperKey; }
            set
            {
                kbd.UpperKey = value;
                this.Invalidate();
            }
        }

        public CtlKeyzoneField()
        {
            InitializeComponent();
        }

        private void CtlKeyzoneField_Paint(object sender, PaintEventArgs e)
        {
            kbd.Draw(e.Graphics);
        }

        private void CtlKeyzoneField_MouseDown(object sender, MouseEventArgs e)
        {
            int num = kbd.GetKeyNumber(e.X, e.Y);
            if (num >= 0)
            {
                if (e.Button == MouseButtons.Left)
                {
                    left = true;
                    LowerKey = num;
                    KeyRangeChanged?.Invoke(sender, e);
                }

                if (e.Button == MouseButtons.Right)
                {
                    right = true;
                    UpperKey = num;
                    KeyRangeChanged?.Invoke(sender, e);
                }
            }
        }

        private void CtlKeyzoneField_MouseUp(object sender, MouseEventArgs e)
        {
            left = false;
            right = false;
        }

        private void CtlKeyzoneField_MouseMove(object sender, MouseEventArgs e)
        {
            if (left || right)
            {
                int num = kbd.GetKeyNumber(e.X, e.Y);
                if (num >= 0)
                {
                    if (left)
                    {
                        LowerKey = num;
                        KeyRangeChanged?.Invoke(sender, e);
                    }
                    if (right)
                    {
                        UpperKey = num;
                        KeyRangeChanged?.Invoke(sender, e);
                    }
                }
            }
        }
    }

    public class NoteKey
    {
        private readonly Point[] pointsArray;
        private readonly Rectangle[] rectsArray;
        private readonly Brush fillBrush;
        private readonly Pen borderPen;
        public static LinearGradientBrush selBrush = new LinearGradientBrush(
            new PointF(0, 0), 
            new PointF(0, KeyboardPicture.all_height), 
            Color.FromArgb(128, Picrutes.VisualOptions.mainTextColor), 
            Color.FromArgb(128, Picrutes.VisualOptions.backgroundColor));

        public NoteKey(Point[] points, Rectangle[] rects, Brush brushColor, Pen penColor)
        {
            pointsArray = points;
            rectsArray = rects;
            fillBrush = brushColor;
            borderPen = penColor;
        }

        public void Draw(Graphics gr, bool selected)
        {
            gr.FillPolygon(fillBrush, pointsArray);

            if (selected)
            {
                gr.FillPolygon(selBrush, pointsArray);
            }

            gr.DrawPolygon(borderPen, pointsArray);
        }

        public bool IsInside(int x, int y)
        {
            bool res = false;
            for (int i = 0; i < rectsArray.Length; i++)
            {
                if (rectsArray[i].Contains(x, y))
                {
                    res = true;
                }
            }
            return res;
        }
    }

    public class Keyboard
    {
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
            }
        }

        private readonly List<NoteKey> keyList = new List<NoteKey>();
        private readonly KeyboardPicture  picture = new KeyboardPicture();

        public Keyboard()
        {
            for (int i = minKey; i <= maxKey; i++)
            {
                NoteKey key = new NoteKey(picture.GetKeyPoints(i), picture.GetKeyRectangles(i), new SolidBrush(GetBrushColor(i)), new Pen(Color.Black));
                keyList.Add(key);
            }
        }

        public void Draw(Graphics gr)
        {
            for (int i = minKey; i <= maxKey; i++)
            {
                bool sel = true;
                if ((i >= lowerKey) && (i <= upperKey)) sel = false;
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

        public int GetKeyNumber(int x, int y)
        {
            int number = -1;

            //---------------------------
            for (int i = minKey; i <= maxKey; i++)
            {
                if (keyList[i].IsInside(x, y))
                {
                    number = i;
                    break;
                }
            }
            //---------------------------

            return number;
        }
    }
}
