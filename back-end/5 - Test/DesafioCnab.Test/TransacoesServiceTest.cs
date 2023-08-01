namespace DesafioCnab.Test;

public class TransacoesServiceTest
{
    private readonly AutoMocker _mocker = new();
    private readonly Faker _faker = new("pt_BR");
    private readonly TransacaoFaker _transacaoFaker = new();

    private readonly ITransacaoService _service;

    private readonly Mock<ITransacaoRepository> _transacaoRepositoryMock;

    public TransacoesServiceTest()
    {
        _transacaoRepositoryMock = _mocker.GetMock<ITransacaoRepository>();

        _service = _mocker.CreateInstance<TransacaoService>();
    }

    [Theory]
    [Repeat(10)]
    public async Task GetTransacoesPorLojaTest()
    {
        // Arrange

        var transacoes = _transacaoFaker.GenerateBetween(1, 99);

        _transacaoRepositoryMock
            .Setup(x => x.GetTransacoesPorLoja(It.IsAny<string>()))
            .ReturnsAsync(transacoes);

        var saldo = _service.CalcularSaldo(transacoes);


        // Act

        var result = await _service.GetTransacoesPorLoja(_faker.Company.CompanyName());


        // Assert

        result.Transacoes.Should().BeEquivalentTo(transacoes);
        result.Saldo.Should().Be(saldo);
    }

    [Theory]
    [Repeat(10)]
    public void CalcularSaldoTest()
    {
        // Arrange

        var transacoes = _transacaoFaker.GenerateBetween(1, 99);
        decimal saldo = 0;

        foreach (Transacao t in transacoes)
        {
            if (t.TipoTransacao.NaturezaTransacao.Sinal == '+')
                saldo += t.Valor;
            else if (t.TipoTransacao.NaturezaTransacao.Sinal == '-')
                saldo -= t.Valor;
            else
                throw new ArgumentOutOfRangeException("Sinal inválido!");
        }


        // Act

        var result = _service.CalcularSaldo(transacoes);


        // Assert

        result.Should().Be(saldo);
    }
}