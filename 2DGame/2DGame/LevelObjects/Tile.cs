using _2DGame.GameObjects;
using _2DGame.Properties;
using System.Drawing;

namespace _2DGame.LevelObjects
{
    class Tile : GameObject
    {
        public enum Type { Empty, Wall, Platform }; // i should chenge names in this enum
        public enum SurfaceType { Normal, Hot, Ice };// here i should chenge names as well

        Type type;
        SurfaceType surface;

        SpriteGameObject image;

        public Tile(Type type, SurfaceType surface)
        {
            this.type = type;
            this.surface = surface;

            if(type == Type.Platform)
            {
                image = new SpriteGameObject(Resources.test);// @"C:\Users\bezimienny\Desktop\Nowy folder\2dGame\2DGame\2DGame\Resources\test.png");
            }

            if(image != null)
            {
                image.Parent = this;
            }            
        }

        public override void Draw(Graphics graphics)
        {
            if(image != null)
            {
                image.Draw(graphics);
                this.Rectangle = image.BoundingBox;
            }
        }

        public Type TileType
        {
            get { return type; }
        }

        public SurfaceType Surface
        {
            get { return surface; }
        }
    }
}
