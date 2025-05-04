using System;

namespace ReservaSalaDeEstudo.Modelos;

public class Reserva
{
    private DateTime _dataReserva;
    private TimeSpan _horaReserva;
    private string? _descricaoDaSala;
    private string? _capacidadeDaSala;

    public string DataReserva {
        get { return _dataReserva.ToString(); }
        set { _dataReserva = RegistrarData(value);}
    }

    public string HoraReserva {
        get { return _horaReserva.ToString(); }
        set { _horaReserva = RegistrarHora(value);}
    }

    public string? DescricaoDaSala {
        get { return _descricaoDaSala; }
        set {if (string.IsNullOrWhiteSpace(value)) {
            throw new Exception("A descrição da sala não pode ser vazia.");
        }
        _descricaoDaSala = value;}
    }

    public string? CapacidadeDaSala{
        get { return _capacidadeDaSala; }
        set{ if (value is null) {
            throw new ArgumentNullException(nameof(value), "Capacidade da sala não pode ser nula!");
            }
            _capacidadeDaSala = RegistrarCapacidade(value);
        }
    }
    private DateTime RegistrarData(string data){
        if (!DateTime.TryParseExact(data,
                   "dd/MM/yyyy",
                   System.Globalization.CultureInfo.GetCultureInfo("pt-BR"),
                   System.Globalization.DateTimeStyles.None,
                   out DateTime _data))
        {
        throw new Exception($"Data {data} Inválida!");
        }
        return _data;
    }

    private TimeSpan RegistrarHora(string hora) {
        if (!TimeSpan.TryParse(hora, out TimeSpan _hora))
        {
        throw new Exception($"Hora {hora} Inválida!");
        }
        return _hora;
    }

    private string RegistrarCapacidade(string capacidade) {
        if (!int.TryParse(capacidade, out int capacidadeInt) || capacidadeInt <= 0 || capacidadeInt >= 40) {
            throw new Exception("A capacidade deve estar obrigatoriamente entre 1 e 40 alunos.");
        }
        return capacidade.ToString();
    }
    
}
