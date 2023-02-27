namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            bool suiteComportaOsHospedes = ValidarCapacidade(hospedes.Count, Suite.Capacidade);
            
            if (suiteComportaOsHospedes)
            {
                Hospedes = hospedes;
            }
            else
            {
                throw new InvalidOperationException("A quantidade de hóspedes não pode exceder a capacidade da Suíte");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            return Hospedes.Count;
        }

        public decimal CalcularValorDiaria()
        {
            bool recebeDesconto = ClienteRecebeDesconto();
            decimal valor;

            if (recebeDesconto)
            {
                decimal desconto = Suite.ValorDiaria - (Suite.ValorDiaria * 0.1m);
                return  DiasReservados * desconto ;
            }
            valor = DiasReservados * Suite.ValorDiaria;
            return valor;
        }

        private bool ValidarCapacidade(int quantidadeHospedes, int capacidade)
        {
            if (quantidadeHospedes <= capacidade)
            {
                return true;
            }
            return false;
        }

        private bool ClienteRecebeDesconto()
        {
            if(DiasReservados >= 10)
            {
                return true;
            }
            return false;
        }
    }
}