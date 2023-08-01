using Bogus;
using Bogus.Extensions.Brazil;
using DesafioCnab.Domain.Entities;

namespace DesafioCnab.Test.Fakers;

public class TransacaoFaker : Faker<Transacao>
{
    public TransacaoFaker()
    {
        static string fnCartao(Faker f) => f.Random.Int(0, 9999).ToString().PadLeft(4, '0');

        RuleFor(o => o.Id, f => f.Random.Guid());
        RuleFor(o => o.Cpf, f => f.Person.Cpf(false));
        RuleFor(o => o.DataHora, f => f.Date.Recent());
        RuleFor(o => o.DonoLoja, f => f.Name.FirstName().PadRight(14, ' ')[..14]);
        RuleFor(o => o.NomeLoja, f => f.Company.CompanyName().PadRight(19, ' ')[..19]);
        RuleFor(o => o.Valor, f => new decimal(f.Random.Int(1, 999999999)) / 100m);
        RuleFor(o => o.Cartao, f => $"{fnCartao(f)}****{fnCartao(f)}");

        RuleFor(o => o.TipoTransacao, _ => new TipoTransacaoFaker().Generate());
    }
}
