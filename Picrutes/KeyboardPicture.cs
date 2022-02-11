using System.Drawing;

namespace SynthLiveMidiController.Pictures
{
    public class KeyboardPicture
    {
        public const int up_width = 7;
        public const int dn_width = 12;
        public const int up_height = 33;
        public const int all_height = 56;

        public Rectangle[] GetKeyRectangles(int index)
        {
            int x = (index / 12) * 12 * up_width;
            int y = 0;

            Rectangle[] rctsC =
            {
                new Rectangle(x, y, up_width, up_height),
                new Rectangle(x, up_height, dn_width, all_height - up_height)
            };
            Rectangle[] rctsD =
            {
                new Rectangle(x + 2 * up_width, y, up_width, up_height),
                new Rectangle(x + dn_width, y + up_height, dn_width, all_height - up_height)
            };
            Rectangle[] rctsE =
            {
                new Rectangle(x + 4 * up_width, y, up_width, up_height),
                new Rectangle(x + 2 * dn_width, y + up_height, dn_width, all_height - up_height)
            };
            Rectangle[] rctsF =
            {
                new Rectangle(x + 5 * up_width, y, up_width, up_height),
                new Rectangle(x + 3 * dn_width, y + up_height, dn_width, all_height - up_height)
            };
            Rectangle[] rctsG =
            {
                new Rectangle(x + 7 * up_width, y, up_width, up_height),
                new Rectangle(x + 4 * dn_width, y + up_height, dn_width, all_height - up_height)
            };
            Rectangle[] rctsA =
            {
                new Rectangle(x + 9 * up_width, y, up_width, up_height),
                new Rectangle(x + 5 * dn_width, y + up_height, dn_width, all_height - up_height)
            };
            Rectangle[] rctsH =
            {
                new Rectangle(x + 11 * up_width, y, up_width, up_height),
                new Rectangle(x + 6 * dn_width, y + up_height, dn_width, all_height - up_height)
            };

            if (index == 60)
            {
                return GetC6Rect(x, y);
            }

            switch (index % 12)
            {
                case 0:
                    return rctsC;
                case 1:
                    return GetBlackKeyRect(x + up_width, y);
                case 2:
                    return rctsD;
                case 3:
                    return GetBlackKeyRect(x + 3 * up_width, y);
                case 4:
                    return rctsE;
                case 5:
                    return rctsF;
                case 6:
                    return GetBlackKeyRect(x + 6 * up_width, y);
                case 7:
                    return rctsG;
                case 8:
                    return GetBlackKeyRect(x + 8 * up_width, y);
                case 9:
                    return rctsA;
                case 10:
                    return GetBlackKeyRect(x + 10 * up_width, y);
                case 11:
                    return rctsH;
                default:
                    return new Rectangle[] { new Rectangle() };
            }
        }

        private Rectangle[] GetBlackKeyRect(int x, int y)
        {
            Rectangle[] rcts = {
                new Rectangle(x, y, up_width, up_height)
            };
            return rcts;
        }

        private Rectangle[] GetC6Rect(int x, int y)
        {
            Rectangle[] rcts = {
                new Rectangle(x, y, dn_width, all_height)
            };
            return rcts;
        }

        public Point[] GetKeyPoints(int index)
        {
            int x = (index / 12) * 12 * up_width;
            int y = 0;

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

            if (index  == 60)
            {
                return GetC6Points(x, y);
            }

            switch (index % 12)
            {
                case 0:
                    return ptsC;
                case 1:
                    return GetBlackKeyPoints(x + up_width, y);
                case 2:
                    return ptsD;
                case 3:
                    return GetBlackKeyPoints(x + 3 * up_width, y);
                case 4:
                    return ptsE;
                case 5:
                    return ptsF;
                case 6:
                    return GetBlackKeyPoints(x + 6 * up_width, y);
                case 7:
                    return ptsG;
                case 8:
                    return GetBlackKeyPoints(x + 8 * up_width, y);
                case 9:
                    return ptsA;
                case 10:
                    return GetBlackKeyPoints(x + 10 * up_width, y);
                case 11:
                    return ptsH;
                default: 
                    return new Point[]
                {
                    new Point(),
                    new Point(),
                    new Point()
                };
            }
        }

        private Point[] GetBlackKeyPoints(int x, int y)
        {
            Point[] pts = {
                new Point(x, y),
                new Point(x + up_width, y),
                new Point(x + up_width, y + up_height),
                new Point(x, y + up_height),
            };
            return pts;
        }

        private Point[] GetC6Points(int x, int y)
        {
            Point[] pts = {
                new Point(x, y),
                new Point(x + dn_width, y),
                new Point(x + dn_width, y + all_height),
                new Point(x, y + all_height),
            };
            return pts;
        }
    }
}
