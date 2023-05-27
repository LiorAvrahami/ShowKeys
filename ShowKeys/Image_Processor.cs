using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowKeys {
    internal class Image_Processor {
        private Bitmap _bitmap;

        public Image_Processor(string image_path) {
            if (image_path != null) {
                this._bitmap = new Bitmap(image_path);
            } else {
                this._bitmap = null;
            }
        }

        public Image get_origional_image() {
            return invert_rectangles(new List<Point>());
        }

        public unsafe Image invert_single_rectangle(Point point, int square_radius = 30) {
            List<Point> points = new List<Point> {point};
            return invert_rectangles(points);
        }

        public unsafe Image invert_rectangles(List<Point> points, int square_radius = 30) {
            bool[,] bool_map = new bool[_bitmap.Width, _bitmap.Height];
            Bitmap ret = new Bitmap(_bitmap);

            BitmapData imageData = ret.LockBits(new Rectangle(0, 0, ret.Width, ret.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            int bytesPerPixel = 3;

            byte* scan0 = (byte*)imageData.Scan0.ToPointer();
            int stride = imageData.Stride;

            foreach (Point p in points) {
                int left = p.X - square_radius;
                int top = p.Y - square_radius;
                int right = p.X + square_radius;
                int bottom = p.Y + square_radius;

                
                if (left < 0) {
                    left = 0;
                }
                if (top < 0) {
                    top = 0;
                }
                if (right > ret.Width) {
                    right = ret.Width;
                }
                if (bottom > ret.Height) {
                    bottom = ret.Height;
                }

                for (int y = top; y < bottom; y++) {
                    byte* row = scan0 + (y * stride);

                    for (int x = left; x < right; x++) {
                        // Watch out for actual order (BGR)!
                        int bIndex = x * bytesPerPixel;
                        int gIndex = bIndex + 1;
                        int rIndex = bIndex + 2;

                        if (bool_map[x, y] == false) {
                            bool_map[x, y] = true;
                            row[rIndex] = (byte)((byte)255 - row[rIndex]);
                            row[gIndex] = (byte)((byte)255 - row[gIndex]);
                            row[bIndex] = (byte)((byte)255 - row[bIndex]);
                        }
                    }
                }
            }
            ret.UnlockBits(imageData);

            return ret;
        }
    }
}
