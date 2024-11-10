namespace MauiAppAppHotel.Views
{
    public partial class HospedagemContratada : ContentPage
    {
        public HospedagemContratada(string descricaoQuarto, string imagemQuarto, string ValorDiariaAdulto, string ValorDiariaCrianca, int quantidadeAdultos, int quantidadeCriancas)
        {
            InitializeComponent();

            LabelQuarto.Text = descricaoQuarto;

            ImageQuarto.Source = ImageSource.FromFile(imagemQuarto);

            QuantidadeAdultosLabel.Text = quantidadeAdultos.ToString();
            QuantidadeCriancasLabel.Text = quantidadeCriancas.ToString();


            double valorAdulto = double.TryParse(ValorDiariaAdulto, out double ValorA) ? ValorA : 0;
            double valorCrianca = double.TryParse(ValorDiariaCrianca, out double ValorC) ? ValorC : 0;
            double valorTotal = valorAdulto + valorCrianca;

            valotTotalLabel.Text = "Valor Total: R$ " + valorTotal.ToString("F2");
        }

        private void Button_Clicked_Voltar_Hosp_Contr(object sender, EventArgs e)
        {
            App.Current.MainPage = new ContratacaoHospedagem();
        }

    }
}