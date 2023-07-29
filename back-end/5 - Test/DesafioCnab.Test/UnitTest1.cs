using Bogus;
using Bogus.Extensions.Brazil;
using DesafioCnab.Domain.DTO;
using DesafioCnab.Domain.Entities;
using FluentAssertions;

namespace DesafioCnab.Test;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        Faker faker = new("pt_BR");

        foreach (var _ in new int[99])
        {
            DateTime dataHora = DateTime.Parse(faker.Date.Recent().ToString("yyyy-MM-dd HH:mm:ss"));

            int valorInt = faker.Random.Int(1, 999999999);
            decimal valorDecimal = new decimal(valorInt) / 100m;

            string strTipo = faker.Random.Int(1, 9).ToString();
            string strData = dataHora.ToString("yyyyMMdd");
            string strValor = valorInt.ToString().PadLeft(10, '0');
            string strCpf = faker.Person.Cpf(false);
            string strCartao = $"{1234}****{5678}";
            string strHora = dataHora.ToString("HHmmss");
            string strDono = faker.Name.FirstName().PadRight(14, ' ')[..14];
            string strLoja = faker.Company.CompanyName().PadRight(19, ' ')[..19];

            var strLine = $"{strTipo}{strData}{strValor}{strCpf}{strCartao}{strHora}{strDono}{strLoja}";

            var objLine = new CnabFileLine(strLine);

            Transacao tran = objLine.InstanciarEntidadeTransacao();

            tran.Should().NotBeNull();

            tran.DataHora.Should().Be(dataHora);
            tran.Valor.Should().Be(valorDecimal);

            tran.TipoTransacaoId.ToString().Should().Be(strTipo);

            tran.Cpf.Should().Be(strCpf);
            tran.Cartao.Should().Be(strCartao);
            tran.DonoLoja.Should().Be(strDono.Trim());
            tran.NomeLoja.Should().Be(strLoja.Trim());
        }
    }
}