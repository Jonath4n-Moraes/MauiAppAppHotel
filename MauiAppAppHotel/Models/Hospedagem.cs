namespace MauiAppAppHotel.Models

{
    public class Hospedagem
    {
        public Quarto QuartoSelecionado {  get; set; }
        public int QtdeAdultos { get; set; }
        public int QtdeCriancas { get; set; }
        public DateTime DataCheckIn { get; set; }
        public DateTime DataCheckOut { get; set; }
        public string imagemQuarto {  get; set; }

        public int Estadia
        {
            get => DataCheckOut.Subtract(DataCheckIn).Days;
        }

        public double ValorTotal
        {
            get
            {
                double valor_adulto = QtdeAdultos * QuartoSelecionado.ValorDiariaAdulto;
                double valor_crianca = QtdeCriancas * QuartoSelecionado.ValorDiariaCrianca;

                double valor_total = (valor_adulto + valor_crianca) * Estadia;

                return valor_total;
            }
        }
    }
}
