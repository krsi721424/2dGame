using Shooter.Content;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shooter.GameObjects
{
    class SpriteGameObject : GameObject
    {
        protected SpriteSheet sprite;

        public Point Origin { get; set; }

        public int SheetIndex
        {
            get { return sprite.SheetIndex; }
            set { sprite.SheetIndex = value; }
        }

        public SpriteGameObject(string spriteName, int sheetIndex = 0)
        {
            if(spriteName != null)
            {
                this.sprite = new SpriteSheet(spriteName, sheetIndex);
            }

            Origin = Point.Zero;
        }

        public override void Draw(Graphics graphics)
        {
            if(!Visible)
            {
                return;
            }

            if(sprite != null)
            {
                sprite.Draw(graphics, GlobalPosition);
            }
        }

        public int Width { get { return sprite.Width; } }

        public int Height { get { return sprite.Height; } }

        public void SetOriginToCenter()
        {
            Origin = sprite.Center;
        }

        public Rectangle BoundingBox
        {
            get
            {
                // get the sprite's bounds
                Rectangle spriteBounds = sprite.Bounds;
                // add the object's position to it as an offset
                spriteBounds.Offset((int)(GlobalPosition.X - Origin.X), (int)(GlobalPosition.Y - Origin.Y));
                return spriteBounds;
            }
        }
    }
}
