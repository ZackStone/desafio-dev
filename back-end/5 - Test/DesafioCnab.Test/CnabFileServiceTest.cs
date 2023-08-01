using System.Text;

namespace DesafioCnab.Test;

public class CnabFileServiceTest
{
    private readonly AutoMocker _mocker = new();
    private readonly Faker _faker = new("pt_BR");
    private readonly CnabFileLineDtoFaker _cnabFileLineFaker = new();

    private readonly ICnabFileService _service;

    public CnabFileServiceTest()
    {
        _service = _mocker.CreateInstance<CnabFileService>();
    }

    [Theory]
    [Repeat(10)]
    public async Task ProcessarArquivoTest()
    {
        // Arrange

        var line = "";

        for (int i = 0; i < _faker.Random.Int(0, 999); i++)
        {
            line += CnabFileLineDtoFaker.GetLine(new CnabFileLineDtoFaker().Generate());
            line += "\n";
        }

        using var test_Stream = new MemoryStream(Encoding.UTF8.GetBytes(line));


        // Act

        var transacoes = await _service.ProcessarArquivo(test_Stream);


        // Assert

        transacoes.Should().NotBeNull();
    }
}