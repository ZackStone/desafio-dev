namespace DesafioCnab.Test.Fakers;

public class CnabFileLineDtoFaker : Faker<CnabFileLineDto>
{
    public CnabFileLineDtoFaker()
    {
        static DateTime fnDateTime(Faker f) => DateTime.Parse(f.Date.Recent().ToString("yyyy-MM-dd HH:mm:ss"));
        static string fnCartao(Faker f) => f.Random.Int(0, 9999).ToString().PadLeft(4, '0');

        RuleFor(o => o.Tipo, f => f.Random.Int(1, 9).ToString());
        RuleFor(o => o.Data, f => fnDateTime(f).ToString("yyyyMMdd"));
        RuleFor(o => o.Valor, f => f.Random.Int(1, 999999999).ToString().PadLeft(10, '0'));
        RuleFor(o => o.Cpf, f => f.Person.Cpf(false));
        RuleFor(o => o.Cartao, f => $"{fnCartao(f)}****{fnCartao(f)}");
        RuleFor(o => o.Hora, f => fnDateTime(f).ToString("HHmmss"));
        RuleFor(o => o.DonoLoja, f => f.Name.FirstName().PadRight(14, ' ')[..14]);
        RuleFor(o => o.NomeLoja, f => f.Company.CompanyName().PadRight(19, ' ')[..19]);
    }

    public static string GetLine(CnabFileLineDto dto) =>
        $"{dto.Tipo}{dto.Data}{dto.Valor}{dto.Cpf}{dto.Cartao}{dto.Hora}{dto.DonoLoja}{dto.NomeLoja}";
}
