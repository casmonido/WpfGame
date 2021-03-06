﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfGame.viewmodels
{
    public class ColorScheme
    {
        public string BackColor { get; set; } = "Blue";
        public string FrontColor { get; set; } = "White";
        public ColorScheme(string b, string f)
        {
            BackColor = b;
            FrontColor = f;
        }
        public ColorScheme()
        {
        }
        new public bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;
            ColorScheme c = (ColorScheme)obj;
            return (c.BackColor == BackColor) && (FrontColor == c.FrontColor);
        }
    }
}
