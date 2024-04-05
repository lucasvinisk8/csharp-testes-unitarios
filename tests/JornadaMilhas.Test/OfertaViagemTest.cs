using JornadaMilhasV1.Modelos;

namespace JornadaMilhas.Test;

public class OfertaViagemTest
{
    [Fact]
    public void TestandoOfertaValida()
    {
        //AAA (Arrange, Act e Assert)
        //cenário - arrange
        Rota rota = new Rota("OrigemTeste", "DestinoTeste");
        Periodo periodo = new Periodo(new DateTime(2024, 4, 10), new DateTime(2024, 4, 20));
        double preco = 100.0;
        var validacao = true;

        //ação - act
        OfertaViagem oferta = new OfertaViagem(rota, periodo, preco);

        //validação 0 assert
        Assert.Equal(validacao, oferta.EhValido);
    }

    [Fact]
    public void TestandoOfertaComRotaNula()
    {
        Rota rota = null;
        Periodo periodo = new Periodo(new DateTime(2024, 4, 10), new DateTime(2024, 4, 20));
        double preco = 100.0;

        OfertaViagem oferta = new OfertaViagem(rota, periodo, preco);

        Assert.Contains("A oferta de viagem não possui rota ou período válidos.", oferta.Erros.Sumario);
        Assert.False(oferta.EhValido);
    }
}