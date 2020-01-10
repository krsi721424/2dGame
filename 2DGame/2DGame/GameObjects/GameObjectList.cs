using System.Collections.Generic;
using System.Drawing;

namespace _2DGame.GameObjects
{
    class GameObjectList : GameObject
    {
        List<GameObject> children;

        public GameObjectList()
        {
            children = new List<GameObject>();
        }

        public void AddChild(GameObject obj)
        {
            obj.Parent = this;
            children.Add(obj);
        }

        public void RemoveChild(GameObject obj)
        {
            children.Remove(obj);
        }

        public List<GameObject> GetChildrens()
        {
            return this.children;
        }

        public override void Update(float currentFps)
        {
            foreach (GameObject obj in children)
            {
                obj.Update(currentFps);
            }
        }

        public override void Draw(Graphics graphics)
        {
            if (!Visible)
                return;

            foreach (GameObject obj in children)
            {
                obj.Draw(graphics);
            }                
        }

        public override void Reset()
        {
            foreach (GameObject obj in children)
            {
                obj.Reset();
            }                
        }
    }
}
