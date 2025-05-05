using System;

namespace ReservaSalaDeEstudo.Modelos;

public class Reserva
{
    private DateTime _dataReserva;
    private TimeSpan _horaReserva;
    private string? _descricaoDaSala;
    private string? _capacidadeDaSala;
    public List<string> ErrosDeValidacao = [];

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
            throw new Exception("A descrição da sala não pode ser nula.");
        }
        _descricaoDaSala = value;}
    }

    public string? CapacidadeDaSala{
        get { return _capacidadeDaSala; }
        set{ if (value is null) {
            throw new ArgumentNullException(nameof(value), "A capacidade da sala não pode ser nula.");
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
        throw new Exception($"Data {data} inválida!");
        }
        return _data;
    }

    private TimeSpan RegistrarHora(string hora) {
        if (!TimeSpan.TryParse(hora, out TimeSpan _hora))
        {
        throw new Exception($"Hora {hora} inválida!");
        }
        return _hora;
    }

    private string RegistrarCapacidade(string capacidade) {
        if (!int.TryParse(capacidade, out int capacidadeInt) || capacidadeInt <= 0 || capacidadeInt >= 40) {
            throw new Exception("A capacidade deve estar obrigatoriamente entre 1 e 40 alunos.");
        }
        return capacidade.ToString();
    }
    
    public bool ValidarReserva() {
         
        ErrosDeValidacao.Clear();

        if (string.IsNullOrEmpty(_descricaoDaSala)) {
            ErrosDeValidacao.Add("A descrição da sala não pode ser nula.");
        }

        if (string.IsNullOrEmpty(_capacidadeDaSala))
        {
            ErrosDeValidacao.Add("A capacidade da sala não pode ser nula.");
        }
        else if (!int.TryParse(_capacidadeDaSala, out int capacidadeInt) || capacidadeInt <= 0 || capacidadeInt >= 40)
        {
            ErrosDeValidacao.Add("A capacidade deve estar obrigatoriamente entre 1 e 40 alunos.");
        }

        if (!DateTime.TryParseExact(_dataReserva.ToString("dd/MM/yyyy"), "dd/MM/yyyy", System.Globalization.CultureInfo.GetCultureInfo("pt-BR"), System.Globalization.DateTimeStyles.None, out _))
        {
            ErrosDeValidacao.Add("Data inválida!");
        }

        if (!TimeSpan.TryParse(_horaReserva.ToString(), out _))
        {
            ErrosDeValidacao.Add("Hora inválida!");
        }

        return ErrosDeValidacao.Count == 0;
    }

}
