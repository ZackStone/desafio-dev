namespace DesafioCnab.Domain.DTO
{
    public class CnabFileLine
    {
        public CnabFileLine(string str)
        {
            Tipo = str[..1];
            Data = str[1..9];
            Valor = str[9..19];
            CPF = str[19..30];
            Cartão = str[30..42];
            Hora = str[42..48];
            DonoLoja = str[48..62];
            NomeLoja = str[62..];
        }

        public string Tipo { get; set; }
        public string Data { get; set; }
        public string Valor { get; set; }
        public string CPF { get; set; }
        public string Cartão { get; set; }
        public string Hora { get; set; }
        public string DonoLoja { get; set; }
        public string NomeLoja { get; set; }
    }
}