using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatters_1.Liskov
{
    public class SquareWrong : RectangleWrong
    {
        public new int Width
        {
            set
            {
                base.Width = base.Height = value;
            }
        }

        public new int Height
        {
            set
            {
                base.Width = base.Height = value;
            }
        }
    }
}
