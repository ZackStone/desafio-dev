namespace DesafioCnab.Test.Fakers;

public class TipoTransacaoFaker : Faker<TipoTransacao>
{
    public TipoTransacaoFaker()
    {
        RuleFor(o => o.Id, f => f.Random.Int(1, 20));
        RuleFor(o => o.Descricao, f => f.Lorem.Sentence(2));
        RuleFor(o => o.NaturezaTransacaoId, f => f.Random.Int(1, 20));

        RuleFor(o => o.NaturezaTransacao, _ => new NaturezaTransacaoFaker().Generate());
    }
}
