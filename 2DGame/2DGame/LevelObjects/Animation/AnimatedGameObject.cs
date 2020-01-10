using Shooter.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shooter.Levels.LevelObjects.Animation
{
    class AnimatedGameObject : SpriteGameObject
    {
        Dictionary<string, Animation> animations;

        public AnimatedGameObject()
            : base(null)
        {
            animations = new Dictionary<string, Animation>();
        }

        public void LoadAnimation(string assetName, string id, bool looping, float frameTime)
        {
            Animation anim = new Animation(assetName, looping, frameTime);
            animations[id] = anim;
        }

        public void PlayAnimation(string id, bool forceRestart = false, int startSheetIndex = 0)
        {
            // if the animation is already playing, do nothing
            if (!forceRestart && sprite == animations[id])
                return;

            animations[id].Play(startSheetIndex);
            sprite = animations[id];
        }

        public override void Update(float currentFps)
        {
            base.Update(currentFps);

            if (sprite != null)
                ((Animation)sprite).Update(currentFps);
        }
    }
}
