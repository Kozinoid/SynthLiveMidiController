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
        private static readonly KeyboardPicture picture = new KeyboardPicture();

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

            picture.DrawKeyboard(e.Graphics, new Point(0, 0));
            e.Graphics.FillPolygon(brush, points, FillMode.Winding);
        }
    }
}
