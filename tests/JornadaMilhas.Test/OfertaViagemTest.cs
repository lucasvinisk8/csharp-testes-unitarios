using JornadaMilhasV1.Modelos;

namespace JornadaMilhas.Test;

public class OfertaViagemTest
{
    [Fact]
    public void TestandoOfertaValida()
    {
        Rota rota = new Rota("OrigemTeste", "DestinoTeste");
        Periodo periodo = new Periodo(new DateTime(2024, 4, 10), new DateTime(2024, 4, 20));
        double preco = 100.0;
        var validacao = true;

        OfertaViagem oferta = new OfertaViagem(rota, periodo, preco);

        Assert.Equal(validacao, oferta.EhValido);
    }
}