namespace MauiAppAppHotel.Views;

using MauiAppAppHotel.Models;


public partial class ContratacaoHospedagem : ContentPage
{

    App PropriedadesApp;

	public ContratacaoHospedagem()
	{
		InitializeComponent();

        PropriedadesApp = (App)Application.Current;

        pck_quarto.ItemsSource = PropriedadesApp.lista_quartos;

        dtpck_checkin.MinimumDate = DateTime.Now;
        dtpck_checkin.MaximumDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month + 1, DateTime.Now.Day);

        dtpck_checkout.MinimumDate = dtpck_checkin.Date.AddDays(1);
        dtpck_checkout.MaximumDate = dtpck_checkin.Date.AddMonths(6);
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
		App.Current.MainPage = new Sobre();
    }

    private async void Button_Clicked_Avancar_Contratatada(object sender, EventArgs e)
    {
        try
        {
            var quartoSelecionado = pck_quarto.SelectedItem as Quarto;
            if (quartoSelecionado != null)
            {
                Hospedagem h = new Hospedagem
                {
                    QuartoSelecionado = quartoSelecionado,
                    QtdeAdultos = Convert.ToInt32(stp_adultos.Value),
                    QtdeCriancas = Convert.ToInt32(stp_criancas.Value),
                    DataCheckIn = dtpck_checkin.Date,
                    DataCheckOut = dtpck_checkout.Date,
                    imagemQuarto = quartoSelecionado.Imagem
                };

                await Navigation.PushAsync(new HospedagemContratada
                {
                    BindingContext = h
                });
            }
            else
            {
                await DisplayAlert("Atenção", "Selecione um quarto!", "OK");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Ops", ex.Message, "Ok");
        }
    }

    private void dtpck_checkin_DateSelected(object sender, DateChangedEventArgs e)
    {

        DatePicker elemento = sender as DatePicker;

        DateTime data_selecionada_checkin = elemento.Date;

        dtpck_checkout.MinimumDate = data_selecionada_checkin.AddDays(1);
        dtpck_checkout.MaximumDate = data_selecionada_checkin.AddMonths(6);

    }

    private void pck_quarto_SelectedIndexChanged(object sender, EventArgs e)
    {

        var picker = sender as Picker;
        var quartoSelecionado = picker.SelectedItem as Quarto;

        if (quartoSelecionado != null)
        {
            PrecoAdultoLabel.Text = "R$ " + quartoSelecionado.ValorDiariaAdulto.ToString("F2");
            PrecoCriancaLabel.Text = "R$ " + quartoSelecionado.ValorDiariaCrianca.ToString("F2");
        }
        else
        {
            PrecoAdultoLabel.Text = "R$ 0,00";
            PrecoCriancaLabel.Text = "R$ 0,00";
        }

    }


}