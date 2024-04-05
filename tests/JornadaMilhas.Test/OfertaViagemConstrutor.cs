using JornadaMilhasV1.Modelos;

namespace JornadaMilhas.Test;

public class OfertaViagemConstrutor
{
    [Theory]
    [InlineData("", null, "2024-01-01", "2024-01-02", 0, false)]
    [InlineData("OrigemTeste", "DestinoTeste", "2024-02-01", "2024-02-05", 100, true)]
    public void RetornaEhValidoDeAcordoComDadosDeEntrada(string origem, string destino, string dataIda, string dataVolta, double preco, bool validacao)
    {
        //AAA (Arrange, Act e Assert)
        //cen�rio - arrange
        Rota rota = new Rota(origem, destino);
        Periodo periodo = new Periodo(DateTime.Parse(dataIda), DateTime.Parse(dataVolta));

        //a��o - act
        OfertaViagem oferta = new OfertaViagem(rota, periodo, preco);

        //valida��o 0 assert
        Assert.Equal(validacao, oferta.EhValido);
    }

    [Fact]
    public void RetornaMensagemDeErroDeRotaOuPeriodoInvalidosQuandoRotaNula()
    {
        Rota rota = null;
        Periodo periodo = new Periodo(new DateTime(2024, 4, 10), new DateTime(2024, 4, 20));
        double preco = 100.0;

        OfertaViagem oferta = new OfertaViagem(rota, periodo, preco);

        Assert.Contains("A oferta de viagem n�o possui rota ou per�odo v�lidos.", oferta.Erros.Sumario);
        Assert.False(oferta.EhValido);
    }

    [Fact]
    public void RetornaMensagemDeErroDePrecoInvalidoQuandoPrecoMenorQueZero()
    {
        //arrange
        Rota rota = new Rota("Origem1", "Destino2");
        Periodo periodo = new Periodo(new DateTime(2024, 8, 20), new DateTime(2024, 8, 30));
        double preco = -250;

        //act
        OfertaViagem oferta = new OfertaViagem(rota, periodo, preco);

        //assert
        Assert.Contains("O pre�o da oferta de viagem deve ser maior que zero.", oferta.Erros.Sumario);
    }
}