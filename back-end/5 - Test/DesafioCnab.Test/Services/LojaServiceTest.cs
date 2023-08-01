namespace DesafioCnab.Test.Services;

public class LojaServiceTest
{
    private readonly AutoMocker _mocker = new();
    private readonly Faker _faker = new("pt_BR");

    private readonly ILojaService _service;

    private readonly Mock<ITransacaoRepository> _transacaoRepositoryMock;

    public LojaServiceTest()
    {
        _transacaoRepositoryMock = _mocker.GetMock<ITransacaoRepository>();

        _service = _mocker.CreateInstance<LojaService>();
    }

    [Fact]
    public async Task GetLojasTest()
    {
        // Arrange

        _transacaoRepositoryMock
            .Setup(x => x.GetLojas())
            .ReturnsAsync(new string[] { _faker.Company.CompanyName() });


        // Act

        var result = await _service.GetLojas();


        // Assert

        result.Should().NotBeNullOrEmpty();
    }
}