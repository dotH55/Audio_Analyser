using System;
using System.Collections.Generic;
using System.Text;

namespace Spectrum.Models
{
    public enum MenuItemType
    {
        Browse,
        Spectrum,
        FastLinesChart
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
