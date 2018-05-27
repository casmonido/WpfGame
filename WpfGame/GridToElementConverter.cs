﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WpfGame
{
    class GridToElementConverter : IValueConverter
    {
        public object Convert(object value, Type targetType,
        object parameter, CultureInfo culture)
        {
            return ((double)value) * ((int)parameter);
        }

        public object ConvertBack(object value, Type targetType,
        object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}