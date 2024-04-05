using JornadaMilhasV1.Modelos;

namespace JornadaMilhas.Test;

public class OfertaViagemTest
{
    [Fact]
    public void TestandoOfertaValida()
    {
        //AAA (Arrange, Act e Assert)
        //cen�rio - arrange
        Rota rota = new Rota("OrigemTeste", "DestinoTeste");
        Periodo periodo = new Periodo(new DateTime(2024, 4, 10), new DateTime(2024, 4, 20));
        double preco = 100.0;
        var validacao = true;

        //a��o - act
        OfertaViagem oferta = new OfertaViagem(rota, periodo, preco);

        //valida��o 0 assert
        Assert.Equal(validacao, oferta.EhValido);
    }

    [Fact]
    public void TestandoOfertaComRotaNula()
    {
        Rota rota = null;
        Periodo periodo = new Periodo(new DateTime(2024, 4, 10), new DateTime(2024, 4, 20));
        double preco = 100.0;

        OfertaViagem oferta = new OfertaViagem(rota, periodo, preco);

        Assert.Contains("A oferta de viagem n�o possui rota ou per�odo v�lidos.", oferta.Erros.Sumario);
        Assert.False(oferta.EhValido);
    }
}