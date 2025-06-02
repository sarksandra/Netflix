using Netflix.ViewModels;

namespace Netflix.Pages;

public partial class DetailsPag : ContentPage
{
    private readonly DetailsViewModel _viewModel;

    public DetailsPag(DetailsViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = _viewModel;
    }

    protected override void OnSizeAllocated(double width, double height)
    {
        base.OnSizeAllocated(width, height);
        if (width > 0)
        {
            _viewModel.SimilarItemWidth = Convert.ToInt32(width / 3) - 3;
        }
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        await _viewModel.InitializeAsync();
    }

    private void TrailersTab_Tapped(object sender, TappedEventArgs e)
    {
       
    }

    private void SimilarTab_Tapped(object sender, TappedEventArgs e)
    {
       
    }

    private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        
    }
}