using Netflix.Models;

namespace Netflix.Controls;

public partial class MovieInfoBox : ContentView
{
    public static readonly BindableProperty MediaProperty =
        BindableProperty.Create(nameof(Media), typeof(Media), typeof(MovieInfoBox), null);
    public MovieInfoBox()
	{
		InitializeComponent();
	}
    public Media Media
    {
        get => (Media)GetValue(MovieInfoBox.MediaProperty);
        set => SetValue(MovieInfoBox.MediaProperty, value);

    }
}