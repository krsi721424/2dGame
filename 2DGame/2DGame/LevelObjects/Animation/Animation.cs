using _2DGame.Content;
using System;
using System.Drawing;

namespace _2DGame.LevelObjects.Animation
{
    class Animation : SpriteSheet
    {
        public float TimePerFrame { get; protected set; }

        public bool IsLooping { get; protected set; }

        public int NumberOfFrames { get{ return NumberOfSheetElements; } }

        public bool AnimationEnded
        {
            get { return !IsLooping && SheetIndex >= NumberOfFrames - 1; }
        }

        DateTime Time;

        public Animation(Bitmap assetname, bool looping, float timePerFrame)
            : base(assetname)
        {
            IsLooping = looping;
            TimePerFrame = timePerFrame;
        }

        public void Play(int startSheetIndex)
        {
            SheetIndex = startSheetIndex;
            Time = DateTime.Now;
        }

        public void Update(float currentFps)
        {

            if (DateTime.Now > Time.AddSeconds(TimePerFrame))
            {
                if (IsLooping) // go to the next frame, or loop around
                {
                    SheetIndex = (SheetIndex + 1) % NumberOfSheetElements;
                    Time = DateTime.Now;
                }
                else // go to the next frame if it exists
                    SheetIndex = Math.Min(SheetIndex + 1, NumberOfSheetElements - 1);
            }
        }
    }
}
