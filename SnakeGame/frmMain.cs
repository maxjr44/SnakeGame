using System;
using System.Drawing;
using System.Windows.Forms;

namespace SnakeGame
{
    public partial class frmMain : Form
    {
        private int direction = 0;
        private int score = 1;
        private Timer gameLoop = new Timer();
        private Random rand = new Random();
        private Graphics graphics;
        private Snake snake;
        private Food food;

        public frmMain()
        {
            InitializeComponent();
            snake = new Snake();
            food = new Food(rand);
            gameLoop.Interval = 100;
            gameLoop.Tick += Update;
        }

        private void frmMain_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {

                case Keys.Enter:
                    if (lblMenu.Visible)
                    {
                        lblMenu.Visible = false;
                        gameLoop.Start();
                    }
                    break;
                case Keys.Space:
                    if (!lblMenu.Visible)
                        gameLoop.Enabled = (gameLoop.Enabled) ? false : true;
                    break;
                case Keys.Right:
                    if (direction != 9) // left=9
                        direction = 0; // right = 0
                    break;
                case Keys.Down:
                    if (direction != 2) // up = 2
                        direction = 1;// down = 1
                    break;
                case Keys.Left:
                    if (direction != 0)
                        direction = 9;
                    break;
                case Keys.Up:
                    if (direction != 1)
                        direction = 2;
                    break;
            }
        }
        private void frmMain_Paint(object sender, PaintEventArgs e)
        {
            graphics = this.CreateGraphics();
            snake.Draw(graphics);
            food.Draw(graphics);
        }

        private void Update(object sender, EventArgs e)
        {
            this.Text = string.Format("Snake - Score {0}", score);
            snake.Move(direction);
            for (int i = 1; i < snake.Body.Length; i++)
                if (snake.Body[0].IntersectsWith(snake.Body[i]))
                    Restart();
            if (snake.Body[0].X < 0 || snake.Body[0].X > this.Width)
                Restart();
            if (snake.Body[0].Y < 0 || snake.Body[0].Y > this.Width)
                Restart();
            if (snake.Body[0].IntersectsWith(food.Piece))
            {
                score++;
                snake.Grow();
                food.Generate(rand);
            }
            this.Invalidate();
        }

        private void Restart()
        {
            gameLoop.Stop();
            graphics.Clear(SystemColors.Control);
            snake = new Snake();
            food = new Food(rand);
            direction = 0;
            score = 1;
            lblMenu.Visible = true;
        }
    }
}
