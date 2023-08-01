using System.Globalization;

namespace DesafioCnab.Test;

public class CnabFileLineDtoTest
{
    private readonly CnabFileLineDtoFaker _cnabFileLineFaker = new();

    [Theory]
    [Repeat(99)]
    public void InstanciarEntidadeTransacaoTest()
    {
        // Arrange

        CnabFileLineDto dto = _cnabFileLineFaker.Generate();
        string strLine = CnabFileLineDtoFaker.GetLine(dto);
        CnabFileLineDto objLine = new(strLine);


        // Act

        Transacao transacao = objLine.InstanciarEntidadeTransacao();


        // Assert

        transacao.Should().NotBeNull();

        transacao.Cpf.Should().Be(dto.Cpf);
        transacao.Cartao.Should().Be(dto.Cartao);
        transacao.DonoLoja.Should().Be(dto.DonoLoja.Trim());
        transacao.NomeLoja.Should().Be(dto.NomeLoja.Trim());

        transacao.TipoTransacaoId.ToString().Should().Be(dto.Tipo);
        
        var valor = decimal.Parse(dto.Valor, CultureInfo.InvariantCulture) / 100m;
        var dataHora = DateTime.ParseExact(dto.Data + dto.Hora, "yyyyMMddHHmmss", CultureInfo.InvariantCulture);

        transacao.DataHora.Should().Be(dataHora);
        transacao.Valor.Should().Be(valor);
    }
}