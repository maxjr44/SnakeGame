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
            for (int i = Body.Length - 1; i < 0; i--)
                Body[i] = Body[i - 1];
        }

        public void Draw(Graphics graphics)
        {
            graphics.FillRectangles(Brushes.Green, Body);
        }

        public void Move(int direction) // 0 = Right, 9 = left, 1 = Down, 2 = Up   
        {
            Draw();
            int tnx, tny, tox, toy;
            tnx = Body[0].X;
            tny = Body[0].Y;

            switch (direction)
            {
                case 0:
                    tnx += 10;
                    break;
                case 1:
                    tny += 10;
                    break;
                case 9:
                    tnx -=10;
                    break;
                case 2:
                    tny -= 10;
                    break;
            }
            for (int i = 0; i < Body.Length; i++)
            {
                tox = Body[i].X;
                toy = Body[i].Y;
                Body[i].X = tnx;
                Body[i].Y = tny;
                tnx = tox;
                tny = toy;
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
