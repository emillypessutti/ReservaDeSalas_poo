using System.Globalization;
using ReservaSalaDeEstudo.Modelos;

ConfiguracaoReserva configuracao = new();

Console.Write("Informe a data mínima (dd/MM/yyyy): ");
var dataMinimaReserva = Console.ReadLine();

Console.Write("Informe a data máxima (dd/MM/yyyy): ");
var dataMaximaReserva = Console.ReadLine();

CultureInfo culturaBrasileira = new("pt-BR");

DateTime.TryParseExact(dataMinimaReserva, "dd/MM/yyyy", culturaBrasileira, DateTimeStyles.None, out DateTime dataMinima);
DateTime.TryParseExact(dataMaximaReserva, "dd/MM/yyyy", culturaBrasileira, DateTimeStyles.None, out DateTime dataMaxima);

try {
    configuracao.ValidarData(dataMinima, dataMaxima);
} catch (ArgumentException e) {
    Console.WriteLine(e.Message);
}

Console.Write("Informe a hora mínima (HH:mm): ");
var horaMinimaReserva = Console.ReadLine();

Console.Write("Informe a hora máxima (HH:mm): ");
var horaMaximaReserva = Console.ReadLine();

TimeSpan.TryParseExact(horaMinimaReserva, "HH:mm", null, TimeSpanStyles.None, out TimeSpan horaMinima);
TimeSpan.TryParseExact(horaMaximaReserva, "HH:mm", null, TimeSpanStyles.None, out TimeSpan horaMaxima);

try {
    configuracao.ValidarHora(horaMinima, horaMaxima);
} catch (ArgumentException e) {
    Console.WriteLine(e.Message);
}

