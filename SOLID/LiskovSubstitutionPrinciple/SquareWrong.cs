using System;
using System.Collections.Generic;
using System.Text;

namespace LiskovSubstitutionPrinciple
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
