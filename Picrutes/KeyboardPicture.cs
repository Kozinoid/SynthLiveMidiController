using System.Drawing;

namespace SynthLiveMidiController.Pictures

{
    public class KeyboardPicture
    {
        private const int up_width = 7;
        private const int dn_width = 12;
        private const int up_height = 30;
        private const int all_height = 50;
        private readonly Pen kbdPen = new Pen(Color.Black);
        private readonly Brush kbdWhiteBrush = Brushes.White;
        private readonly Brush kbdBlackBrush = Brushes.DarkSlateGray;

        public void DrawKeyboard(Graphics gr, Point pt)
        {
            DrawKeyboard(gr, pt.X, pt.Y);
        }

        public void DrawKeyboard(Graphics gr, int x, int y)
        {
            for (int i = 0; i < 5; i++)
            {
                DrawOctave(gr, x + i * dn_width * 7, y);
            }
            DrawC6(gr, x + 5 * dn_width * 7, y);
        }

        public void DrawOctave(Graphics gr, int x, int y)
        {
            Point[] ptsC = {
                new Point(x, y),
                new Point(x + up_width, y),
                new Point(x + up_width, y + up_height),
                new Point(x + dn_width, y + up_height),
                new Point(x + dn_width, y + all_height),
                new Point(x, y + all_height)
            };
            Point[] ptsD = {
                new Point(x + 2 * up_width, y),
                new Point(x + 3 * up_width, y),
                new Point(x + 3 * up_width, y + up_height),
                new Point(x + 2 * dn_width, y + up_height),
                new Point(x + 2 * dn_width, y + all_height),
                new Point(x + dn_width, y + all_height),
                new Point(x + dn_width, y + up_height),
                new Point(x + 2 * up_width, y + up_height),
            };
            Point[] ptsE =  {
                new Point(x + 4 * up_width, y),
                new Point(x + 3 * dn_width, y),
                new Point(x + 3 * dn_width, y + all_height),
                new Point(x + 2 * dn_width, y + all_height),
                new Point(x + 2 * dn_width, y + up_height),
                new Point(x + 4 * up_width, y + up_height)
            };
            Point[] ptsF = {
                new Point(x + 3 * dn_width, y),
                new Point(x + 6 * up_width, y),
                new Point(x + 6 * up_width, y + up_height),
                new Point(x + 4 * dn_width, y + up_height),
                new Point(x + 4 * dn_width, y + all_height),
                new Point(x + 3 * dn_width, y + all_height)
            };
            Point[] ptsG = {
                new Point(x + 7 * up_width, y),
                new Point(x + 8 * up_width, y),
                new Point(x + 8 * up_width, y + up_height),
                new Point(x + 5 * dn_width, y + up_height),
                new Point(x + 5 * dn_width, y + all_height),
                new Point(x + 4 * dn_width, y + all_height),
                new Point(x + 4 * dn_width, y + up_height),
                new Point(x + 7 * up_width, y + up_height),
            };
            Point[] ptsA = {
                new Point(x + 9 * up_width, y),
                new Point(x + 10 * up_width, y),
                new Point(x + 10 * up_width, y + up_height),
                new Point(x + 6 * dn_width, y + up_height),
                new Point(x + 6 * dn_width, y + all_height),
                new Point(x + 5 * dn_width, y + all_height),
                new Point(x + 5 * dn_width, y + up_height),
                new Point(x + 9 * up_width, y + up_height),
            };
            Point[] ptsH =  {
                new Point(x + 11 * up_width, y),
                new Point(x + 7 * dn_width, y),
                new Point(x + 7 * dn_width, y + all_height),
                new Point(x + 6 * dn_width, y + all_height),
                new Point(x + 6 * dn_width, y + up_height),
                new Point(x + 11 * up_width, y + up_height)
            };

            DrawWhiteKey(gr, ptsC);
            DrawWhiteKey(gr, ptsD);
            DrawWhiteKey(gr, ptsE);
            DrawWhiteKey(gr, ptsF);
            DrawWhiteKey(gr, ptsG);
            DrawWhiteKey(gr, ptsA);
            DrawWhiteKey(gr, ptsH);

            DrawBlackKey(gr, x + up_width, y);
            DrawBlackKey(gr, x + 3 * up_width, y);
            DrawBlackKey(gr, x + 6 * up_width, y);
            DrawBlackKey(gr, x + 8 * up_width, y);
            DrawBlackKey(gr, x + 10 * up_width, y);

        }

        public void DrawWhiteKey(Graphics gr, Point[] pts)
        {
            gr.FillPolygon(kbdWhiteBrush, pts);
            gr.DrawPolygon(kbdPen, pts);
        }

        public void DrawBlackKey(Graphics gr, int x, int y)
        {
            Point[] pts = {
                new Point(x, y),
                new Point(x + up_width, y),
                new Point(x + up_width, y + up_height),
                new Point(x, y + up_height),
            };
            gr.FillPolygon(kbdBlackBrush, pts);
            gr.DrawPolygon(kbdPen, pts);
        }

        public void DrawC6(Graphics gr, int x, int y)
        {
            Point[] pts = {
                new Point(x, y),
                new Point(x + dn_width, y),
                new Point(x + dn_width, y + all_height),
                new Point(x, y + all_height),
            };
            gr.FillPolygon(kbdWhiteBrush, pts);
            gr.DrawPolygon(kbdPen, pts);
        }
    }
}
