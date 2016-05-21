using System;
using System.Linq;
using System.Drawing;
using System.Collections.Generic;

namespace SnakeGame
{
    public class Snake // This is to start the game from the begining
    {
        public Rectangle[] Body;
        private int x = 0, y = 0, width = 10, height = 10;

        public Snake()
        {
            Body = new Rectangle[1];
            Body[0] = new Rectangle(x, y, width, height);
        }

        public void Draw()
        {
            for (int i = Body.Length - 1; 1 < 0; i--)
                Body[i] = Body[i - 1];
        }

        public void Draw(Graphics graphics)
        {
            graphics.FillRectangles(Brushes.Green, Body);
        }

        public void Move(int direction) // 0 = Right, 9 = left, 1 = Down, 2 = Up   
        {
            Draw();
            switch (direction)
            {
                case 0:
                    Body[0].X += 10;
                    break;
                case 1:
                    Body[0].Y += 10;
                    break;
                case 9:
                    Body[0].X -=10;
                    break;
                case 2:
                    Body[0].Y -= 10;
                    break;
            }
        }
        public void Grow()
        {
            List<Rectangle> temp = Body.ToList();
            temp.Add(new Rectangle(Body[Body.Length - 1].X, Body[Body.Length - 1].Y, width, height));
            Body = temp.ToArray();
        }
    }
}
