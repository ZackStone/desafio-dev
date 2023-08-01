using Bogus;
using DesafioCnab.Domain.Entities;

namespace DesafioCnab.Test.Fakers;

public class NaturezaTransacaoFaker : Faker<NaturezaTransacao>
{
    public NaturezaTransacaoFaker()
    {
        RuleFor(o => o.Id, f => f.Random.Int(1, 20));
        RuleFor(o => o.Descricao, f => f.Lorem.Sentence(2));
        RuleFor(o => o.Sinal, f => f.Random.ArrayElement(new char[] { '-', '+' }));
    }
}