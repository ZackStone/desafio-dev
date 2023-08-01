using System.Globalization;

namespace DesafioCnab.Test.Domain.Dto;

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

    [Fact]
    public void SeStringInvalidaDeveLancarExcecaoEspecifica()
    {
        Action act = () => new CnabFileLineDto("");

        act.Should()
            .Throw<FluentValidation.ValidationException>()
            .Where(e => e.Message == "O arquivo não está formatado corretamente.");
    }

    private static void TestarDeveLancarExcecaoEspecifica(CnabFileLineDto dto)
    {
        // Arrange

        string strLine = CnabFileLineDtoFaker.GetLine(dto);
        CnabFileLineDto objLine = new(strLine);


        // Act
        // Assert

        Action act = () => objLine.InstanciarEntidadeTransacao();

        act.Should()
            .Throw<FluentValidation.ValidationException>()
            .Where(e => e.Message == "O arquivo não está formatado corretamente.");
    }

    [Theory]
    [InlineData("")]
    [InlineData("abc")]
    [InlineData("20231232")]
    [InlineData("20230230")]
    [InlineData("2023-02-01")]
    [InlineData("2023/02/01")]
    [InlineData("01/01/2023")]
    [InlineData("01-01-2023")]
    public void SeDataEmFormatoIncorretoDeveLancarExcecaoEspecifica(string input)
    {
        // Arrange

        CnabFileLineDto dto = _cnabFileLineFaker.Generate();
        dto.Data = input;

        // Act
        // Assert

        TestarDeveLancarExcecaoEspecifica(dto);
    }

    [Theory]
    [InlineData("")]
    [InlineData("abc")]
    [InlineData("250000")]
    [InlineData("096000")]
    [InlineData("090060")]
    [InlineData("0930")]
    [InlineData("09:30:00")]
    [InlineData("09:30")]
    public void SeHoraEmFormatoIncorretoDeveLancarExcecaoEspecifica(string input)
    {
        // Arrange

        CnabFileLineDto dto = _cnabFileLineFaker.Generate();
        dto.Hora = input;

        // Act
        // Assert

        TestarDeveLancarExcecaoEspecifica(dto);
    }

    [Theory]
    [InlineData("")]
    [InlineData("abc")]
    public void SeTipoTransacaoEmFormatoIncorretoDeveLancarExcecaoEspecifica(string input)
    {
        // Arrange

        CnabFileLineDto dto = _cnabFileLineFaker.Generate();
        dto.Tipo = input;

        // Act
        // Assert

        TestarDeveLancarExcecaoEspecifica(dto);
    }

    [Theory]
    [InlineData("")]
    [InlineData("abc")]
    [InlineData("123.45")]
    [InlineData("678,90")]
    [InlineData("1.000")]
    [InlineData("1,000")]
    [InlineData("1.000,23")]
    [InlineData("1,000.23")]
    public void SeValorTransacaoEmFormatoIncorretoDeveLancarExcecaoEspecifica(string input)
    {
        // Arrange

        CnabFileLineDto dto = _cnabFileLineFaker.Generate();
        dto.Tipo = input;

        // Act
        // Assert

        TestarDeveLancarExcecaoEspecifica(dto);
    }
}