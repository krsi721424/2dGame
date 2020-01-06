using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2DGame.Engine
{
    class GameManager
    {
        public static string StateName_Playing = "playing";

        private DateTime endTime;
        public Form GameMenu { get; set; }
        public CanvasForm Canvas { get; set; }
        private int level = 1;

        private bool stopGame = false;

        //Singleton class
        public static GameManager Instance { get; } = new GameManager();
        public float CurrentFps { get; private set; }

        private GameManager()
        {
            //game state inicjalize
        }

        public void LoadContent()
        {
            this.NewGame();
        }

        internal void UpdateGame(PictureBox canvas)
        {
            if (!stopGame)
            {
                CalcDelta();
                
            }
            else
            {
                if (UserInputController.KeyPressed(Keys.Escape))
                {
                    UserInputController.ChangeState(Keys.Escape, false);
                    this.GameMenu.Show();
                    this.Canvas.Hide();
                }

                if (UserInputController.KeyPressed(Keys.Enter))
                {
                    UserInputController.ChangeState(Keys.Enter, false);
                    this.NewGame();
                }
            }

            if (UserInputController.KeyPressed(Keys.Escape))
            {
                UserInputController.ChangeState(Keys.Escape, false);
                this.GameOver();
            }
        }

        internal void Draw(Graphics graphics)
        {
            
        }

        private void CalcDelta()
        {
            TimeSpan deltaTime = DateTime.Now - endTime;
            int milliSeconds = deltaTime.Milliseconds > 0 ? deltaTime.Milliseconds : 1;
            CurrentFps = 1000 / milliSeconds;
            endTime = DateTime.Now;
        }

        public void GameOver()
        {
            this.stopGame = true;
            this.Canvas.GameOver();
        }

        public void NewGame()
        {
            this.stopGame = false;
            this.Canvas.NewGame();
            
        }
    }
}
