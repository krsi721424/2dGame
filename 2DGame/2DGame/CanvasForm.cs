using _2DGame.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2DGame
{
    public partial class CanvasForm : Form
    {
        private GameManager gameManager;

        public CanvasForm()
        {
            InitializeComponent();

            gameManager = GameManager.Instance;

            this.GameOverPanel.Visible = false;

            GameTimer.Interval = 1000 / 60;
            GameTimer.Tick += UpdateScreen;
            GameTimer.Start();

        }

        private void UpdateScreen(object sender, EventArgs e)
        {
            gameManager.UpdateGame(this.Canvas);

            Canvas.Invalidate(); //this invoke paint
        }

        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;

            gameManager.Draw(graphics);
        }

        private void CanvasForm_KeyDown(object sender, KeyEventArgs e)
        {
            UserInputController.ChangeState(e.KeyCode, true);
        }

        private void CanvasForm_KeyUp(object sender, KeyEventArgs e)
        {
            UserInputController.ChangeState(e.KeyCode, false);
        }

        public void GameOver()
        {
            this.GameOverPanel.Visible = true;
        }

        public void NewGame()
        {
            this.GameOverPanel.Visible = false;
        }
    }
}
