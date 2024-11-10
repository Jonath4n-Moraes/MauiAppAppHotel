namespace MauiAppAppHotel.Models
{
    public class Quarto
    {
        public string Descricao { get; set; }
        public double ValorDiariaAdulto { get; set; }
        public double ValorDiariaCrianca { get; set; }

        // Propriedade para armazenar o nome da imagem
        public string Imagem { get; set; }
    }
}
