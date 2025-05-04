using System;

namespace ReservaSalaDeEstudo.Modelos;

public class ConfiguracaoReserva
{

    private DateTime _dataMinima;
    private DateTime _dataMaxima;
    private TimeSpan _horaMinima;
    private TimeSpan _horaMaxima;


    public string DataMinima {
        get { return _dataMinima.ToString(); }
        set { _dataMinima = ValidarDataInformada(value);}
    }

    public string DataMaxima {
        get { return _dataMaxima.ToString(); }
        set { _dataMaxima = ValidarDataInformada(value);
            ValidarDataMaximaMaiorQueMinima();}
    }

    public string HoraMinima {
        get { return _horaMinima.ToString(); }
        set { _horaMinima = ValidarHoraInformada(value);}
    }

    public string HoraMaxima {
        get { return _horaMaxima.ToString(); }
        set {_horaMaxima = ValidarHoraInformada(value);
            ValidarHoraMaximaMaiorQueMinima();}
    }

    private DateTime ValidarDataInformada(string data)
    {
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

    private void ValidarDataMaximaMaiorQueMinima()
    {
        if (_dataMinima < DateTime.Now || _dataMaxima < DateTime.Now){
            throw new ArgumentException("As datas não podem ser anteriores à data atual.");
        } else if (_dataMaxima <= _dataMinima) {
            throw new ArgumentException("A data máxima deve ser maior que a data máxima.");
        }

    }

    private TimeSpan ValidarHoraInformada(string hora) {
        if (!TimeSpan.TryParse(hora, out TimeSpan _hora))
        {
        throw new Exception($"Hora {hora} Inválida!");
        }
        return _hora;
    }
    private void ValidarHoraMaximaMaiorQueMinima()
    {   
        if (_horaMaxima <= _horaMinima) {
            throw new ArgumentException("A hora máxima deve ser maior que a hora mínima.");
        }

    }

}
