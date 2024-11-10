namespace MauiAppAppHotel.Views
{
    public partial class HospedagemContratada : ContentPage
    {
        public HospedagemContratada()
        {
            InitializeComponent();

        }

        private async void Button_Clicked_Voltar_Hosp_Contr(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }


    }
}