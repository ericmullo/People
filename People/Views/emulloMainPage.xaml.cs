using People.ViewModels;
using Microsoft.Maui.Controls;

namespace People.Views;

public partial class emulloMainPage : ContentPage
{
    public emulloMainPage()
    {
        InitializeComponent();
        BindingContext = new MainPageViewModel();
    }

    private void OnNewButtonClicked(object sender, EventArgs e)
    {
        var viewModel = (MainPageViewModel)BindingContext;

        // Validamos que el control newPerson no sea null y tenga texto
        if (!string.IsNullOrEmpty(newPerson?.Text))
        {
            viewModel.AddPerson(newPerson.Text);
            newPerson.Text = string.Empty;
        }
    }

    private void OnGetButtonClicked(object sender, EventArgs e)
    {
        var viewModel = (MainPageViewModel)BindingContext;
        viewModel.LoadPeople();
    }
}
