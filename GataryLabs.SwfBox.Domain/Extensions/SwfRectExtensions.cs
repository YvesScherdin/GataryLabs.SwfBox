using SwfLib.Data;
using System.Drawing;

namespace GataryLabs.SwfBox.Domain.Extensions
{
    internal static class SwfRectExtensions
    {
        internal static Rectangle ToRectangle(this SwfRect rect)
        {
            Rectangle result = Rectangle.FromLTRB(rect.XMin, rect.YMax, rect.XMax, rect.YMin);
            return result;
        }
    }
}
