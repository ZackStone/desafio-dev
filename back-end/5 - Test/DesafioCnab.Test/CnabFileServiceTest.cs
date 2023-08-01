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
    public void ProcessarArquivoTest()
    {
        //_service!.ProcessarArquivo(null);
    }
}