namespace WachtWoord;

public partial class MainPage : ContentPage
{
	public MainPage()
    {
        InitializeComponent();

    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        this.Window.Height = 728;
        this.Window.Width = 1024;
    }
}
