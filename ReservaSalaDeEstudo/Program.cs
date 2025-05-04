using System.Globalization;
using ReservaSalaDeEstudo.Modelos;

ConfiguracaoReserva configuracao = new();

Console.WriteLine("***CONFIGURAÇÃO DA RESERVA***");

Console.Write("Informe a data mínima (dd/MM/yyyy): ");
while (true) {
    try {
        configuracao.DataMinima = Console.ReadLine() ?? string.Empty;
        break;
    } catch (Exception e) {
        Console.Write($"Erro: {e.Message}\nInforme a data mínima novamente (dd/MM/yyyy): ");
    }
}

Console.Write("Informe a data máxima (dd/MM/yyyy): ");
while (true) {
    try {
        configuracao.DataMaxima = Console.ReadLine() ?? string.Empty;
        break;
    } catch (Exception e) {
        Console.Write($"Erro: {e.Message}\nInforme a data máxima novamente (dd/MM/yyyy): ");
    }
}

Console.Write("Informe a hora mínima (HH:mm): ");
while (true) {
    try {
        configuracao.HoraMinima = Console.ReadLine() ?? string.Empty;
    
        break;
    } catch (Exception e) {
        Console.Write($"Erro: {e.Message}\nInforme a hora mínima novamente (HH:mm): ");
    }
}

Console.Write("Informe a hora máxima (HH:mm): ");
while (true) {
    try {
        configuracao.HoraMaxima = Console.ReadLine() ?? string.Empty;
        break;
    } catch (Exception e) {
        Console.Write($"Erro: {e.Message}\nInforme a hora máxima novamente (HH:mm): ");
    }
}



Console.WriteLine("***AGENDAMENTO DA RESERVA***");

Reserva reserva = new();

Console.Write("Informe a data da reserva (dd/MM/yyyy): ");
while (true) {
    try {
        reserva.DataReserva = Console.ReadLine() ?? string.Empty;

        var dataReserva = DateTime.Parse(reserva.DataReserva);
        var dataMin = DateTime.Parse(configuracao.DataMinima);
        var dataMax = DateTime.Parse(configuracao.DataMaxima);

        if (dataReserva < dataMin || dataReserva > dataMax) {
            throw new Exception($"A data {dataReserva:dd/MM/yyyy} está fora do período permitido ({dataMin:dd/MM/yyyy} a {dataMax:dd/MM/yyyy}).");
        }
        break;
    } catch (Exception e) {
        Console.Write($"Erro: {e.Message}\nInforme a data da reserva novamente (dd/MM/yyyy): ");
    }
}

Console.Write("Informe o horário da reserva (HH:mm): ");
while (true) {
    try {
        reserva.HoraReserva = Console.ReadLine() ?? string.Empty;

        TimeSpan horaReserva = TimeSpan.Parse(reserva.HoraReserva);
        TimeSpan horaMinima = TimeSpan.Parse(configuracao.HoraMinima);
        TimeSpan horaMaxima = TimeSpan.Parse(configuracao.HoraMaxima);

        if (horaReserva < horaMinima || horaReserva > horaMaxima) {
            throw new Exception($"A hora {horaReserva:hh\\:mm} está fora do período permitido ({horaMinima:hh\\:mm} a {horaMaxima:hh\\:mm}).");
        }

        break;
    } catch (Exception e) {
        Console.Write($"Erro: {e.Message}\nInforme o horário da reserva novamente (HH:mm): ");
    }
}

Console.Write("Informe a descrição da sala: ");
while (true) {
    try {
        reserva.DescricaoDaSala = Console.ReadLine();
        break;
    } catch (Exception e) {
        Console.Write($"Erro: {e.Message}\nInforme a descrição da sala novamente: ");
    }
}

Console.Write("Informe a capacidade da sala: ");
while (true) {
    try {
        reserva.CapacidadeDaSala = Console.ReadLine();
        break;
    } catch (Exception e) {
        Console.Write($"Erro: {e.Message}\nInforme a capacidade da sala novamente: ");
    }
}


Console.WriteLine("\n***AGENDAMENTO DA RESERVA REALIZADO COM SUCESSO\n");
Console.WriteLine($"Data: {DateTime.Parse(reserva.DataReserva):dd/MM/yyyy}");
Console.WriteLine($"Hora: {TimeSpan.Parse(reserva.HoraReserva):hh\\:mm}");
Console.WriteLine($"Descrição da sala: {reserva.DescricaoDaSala}");
Console.WriteLine($"Capacidade da sala: {reserva.CapacidadeDaSala}");
