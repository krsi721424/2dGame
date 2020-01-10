using Shooter.GameObjects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shooter.Levels.LevelObjects
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

            //string surfaceExtenstion = "";
            //if(surface == SurfaceType.Hot)
            //{
            //    surfaceExtenstion = "_hot";
            //}
            //else if(surface == SurfaceType.Ice)
            //{
            //    surfaceExtenstion = "_ice";
            //}

            if(type == Type.Wall)
            {
                //image = new SpriteGameObject("" + surfaceExtenstion);
            }
            else if(type == Type.Platform)
            {
                image = new SpriteGameObject(@"F:\Projekty\Shooter\shooter2\Shooter\Resources\test.png");
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
