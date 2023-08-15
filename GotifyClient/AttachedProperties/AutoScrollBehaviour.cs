using System.Windows;
using System.Windows.Controls;

namespace GotifyClient.AttachedProperties
{
	public static class AutoScrollBehavior
	{
		public static readonly DependencyProperty AutoScrollProperty =
			DependencyProperty.RegisterAttached("AutoScroll", typeof(int), typeof(AutoScrollBehavior), new PropertyMetadata(0, AutoScrollPropertyChanged));


		public static void AutoScrollPropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
		{
			var scrollViewer = obj as ScrollViewer;

			scrollViewer?.ScrollToBottom();
		}

		public static int GetAutoScroll(DependencyObject obj)
		{
			return (int)obj.GetValue(AutoScrollProperty);
		}

		public static void SetAutoScroll(DependencyObject obj, int value)
		{
			obj.SetValue(AutoScrollProperty, value);
		}
	}
}

