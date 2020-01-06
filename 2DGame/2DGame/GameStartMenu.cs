using _2DGame.Engine;
using _2DGame.Properties;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace _2DGame
{
    public partial class GameStartMenu : Form
    {
        private Bitmap NewButton;
        private Bitmap NewButtonHover;
        private Bitmap ExitGameButton;
        private Bitmap ExitButtonHover;
        private CanvasForm canvas;
        private GameManager gameManager;

        public GameStartMenu()
        {
            InitializeComponent();

            this.NewButton = new Bitmap(Resources.GoldButton2);
            this.NewButtonHover = new Bitmap(Resources.GoldButton2Hover);
            this.ExitGameButton = new Bitmap(Resources.ExitButton);
            this.ExitButtonHover = new Bitmap(Resources.ExitButtonHighlight);

            canvas = new CanvasForm();

            gameManager = GameManager.Instance;
            gameManager.GameMenu = this;
            gameManager.Canvas = canvas;
        }

        private void NewGameButton_Click(object sender, EventArgs e)
        {
            this.canvas.Show();
            this.Hide();
            this.gameManager.LoadContent();

        }

        private void NewGameButton_MouseEnter(object sender, EventArgs e)
        {
            this.NewGameButton.BackgroundImage = NewButtonHover;
        }

        private void NewGameButton_MouseLeave(object sender, EventArgs e)
        {
            this.NewGameButton.BackgroundImage = NewButton;
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ExitButton_MouseEnter(object sender, EventArgs e)
        {
            this.ExitButton.BackgroundImage = ExitButtonHover;
        }

        private void ExitButton_MouseLeave(object sender, EventArgs e)
        {
            this.ExitButton.BackgroundImage = ExitGameButton;
        }
    }
}
