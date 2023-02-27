using System.Text;
using DesafioProjetoHospedagem.Models;

Console.OutputEncoding = Encoding.UTF8;

// Cria os modelos de hóspedes e cadastra na lista de hóspedes
List<Pessoa> hospedes = new List<Pessoa>();

Pessoa hospede_1 = new Pessoa(nome: "Hóspede 1");
Pessoa hospede_2 = new Pessoa(nome: "Hóspede 2");

hospedes.Add(hospede_1);
hospedes.Add(hospede_2);

// Cria a suíte
Suite suite = new Suite(tipoSuite: "Premium", capacidade: 3, valorDiaria: 100);

// Cria uma nova reserva, passando a suíte e os hóspedes
Reserva reserva = new Reserva(diasReservados: 11);
reserva.CadastrarSuite(suite);
reserva.CadastrarHospedes(hospedes);

// Exibe a quantidade de hóspedes e o valor da diária
Console.WriteLine($"Hóspedes: {reserva.ObterQuantidadeHospedes()}");
Console.WriteLine($"Valor diária: {reserva.CalcularValorDiaria()}");