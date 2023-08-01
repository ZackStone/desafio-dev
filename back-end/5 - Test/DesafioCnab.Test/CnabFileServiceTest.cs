using System.Text;

namespace DesafioCnab.Test;

public class CnabFileServiceTest
{
    private readonly AutoMocker _mocker = new();
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

        var line = CnabFileLineDtoFaker.GetLine(new CnabFileLineDtoFaker().Generate());

        using var test_Stream = new MemoryStream(Encoding.UTF8.GetBytes(line));


        // Act

        var transacoes = await _service.ProcessarArquivo(test_Stream);


        // Assert

        transacoes.Should().NotBeNull();
    }
}