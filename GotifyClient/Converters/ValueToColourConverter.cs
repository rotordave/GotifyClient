
using System;
using System.Linq;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Shapes;

namespace GotifyClient.Converters
{
	public class ValueToColourConverter : IValueConverter
	{

		private static Color StringToColour(string colour)
		{
			Line lne = (Line)System.Windows.Markup.XamlReader.Parse("<Line xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\" xmlns:x=\"http://schemas.microsoft.com/winfx/2006/xaml\" Fill=\"" + colour + "\" />");
			return (Color)lne.Fill.GetValue(SolidColorBrush.ColorProperty);
		}

		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			Color color = Color.FromRgb(255, 0, 0);

			try
			{
				string parameterText = (parameter != null) ? (string)parameter : "Black,Red";
				var parameters = parameterText.Split(',')?.ToList();
				if (parameters != null && parameters.Count > 0)
				{
					var parameterValues = parameters.Where(p => parameters.IndexOf(p) % 2 == 0).ToList();
					var parameterColours = parameters.Where(p => parameters.IndexOf(p) % 2 != 0);
					var colourHex = parameterColours.ToArray()[parameterValues.IndexOf(value.ToString())];
					color = (Color)ColorConverter.ConvertFromString(colourHex);
				}
			}
			catch (Exception ex)
			{
				System.Diagnostics.Trace.WriteLine($"Error in converting {value} to one of {parameter}: {ex}");
			}

			return new SolidColorBrush(color);

		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			return null;
		}
	}
}
