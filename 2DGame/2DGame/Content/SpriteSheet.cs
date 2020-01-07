using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shooter.Content
{
    class SpriteSheet
    {
        Bitmap sprite;
        Rectangle spriteRectangle;

        List<Bitmap> bitmaps;

        int sheetIndex;
        int sheetColumns;
        int sheetRows;

        public bool Mirror { get; set; }

        public SpriteSheet(string assetname, int sheetIndex = 0)
        {
            //load sprite from file
            sprite = new Bitmap(assetname);
            int spriteWidth = sprite.Width;
            int spriteHeight = sprite.Height;

            sheetColumns = spriteWidth / 32;
            sheetRows = 1;

            bitmaps = new List<Bitmap>();

            for (int i = 0; i < spriteWidth; i+=32)
            {
                bitmaps.Add(sprite.Clone(new RectangleF(i, 0, 32, 32), sprite.PixelFormat));
            }            

            // apply the sheet index; this will also calculate spriteRectangle
            SheetIndex = sheetIndex;
        }

        public void Draw(Graphics graphics, Point position)
        {
            PointF pos = new PointF(position.X, position.Y);
            graphics.DrawImage(bitmaps[sheetIndex], pos);
        }

        public int Width
        {
            get { return sprite.Width / sheetColumns; }
        }

        public int Height
        {
            get { return sprite.Height / sheetRows; }
        }

        public Point Center
        {
            get { return new Point(Width, Height) / 2; }
        }

        public int SheetIndex
        {
            get { return sheetIndex; }
            set
            {
                if (value < NumberOfSheetElements && value >= 0)
                {
                    sheetIndex = value;

                    // recalculate the part of the sprite to draw
                    int columnIndex = sheetIndex % sheetColumns;
                    int rowIndex = sheetIndex / sheetColumns;
                    spriteRectangle = new Rectangle(columnIndex * Width, rowIndex * Height, Width, Height);
                }
            }
        }

        public Rectangle Bounds
        {
            get
            {
                return new Rectangle(0, 0, Width, Height);
            }
        }

        public int NumberOfSheetElements
        {
            get { return sheetColumns * sheetRows; }
        }
    }
}
