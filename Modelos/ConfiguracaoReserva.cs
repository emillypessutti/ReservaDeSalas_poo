using System;

namespace ReservaSalaDeEstudo.Modelos;

public class ConfiguracaoReserva
{

    private DateTime _dataMinima;
    private DateTime _dataMaxima;
    private TimeSpan _horaMinima;
    private TimeSpan _horaMaxima;


    public String DataMinima {
        get { return _dataMinima.ToString(); }
        set { _dataMinima = _validarDataInformada(value);}
    }

    public String DataMaxima {
        get { return _dataMaxima.ToString(); }
        set { _dataMaxima = _validarDataInformada(value);
            ValidarData();}
    }

    public String HoraMinima {
        get { return _horaMinima.ToString(); }
        set { _horaMinima = ValidarHoraInformada(value);}
    }

    public String HoraMaxima {
        get { return _horaMaxima.ToString(); }
        set {_horaMaxima = ValidarHoraInformada(value);
            ValidarHora();}
    }

  private DateTime _validarDataInformada(string data)
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

    public void ValidarData()
    {
        if (_dataMinima < DateTime.Now || _dataMaxima < DateTime.Now){
            throw new ArgumentException("As datas não podem ser anteriores à data atual.");
        } else if (_dataMinima >= _dataMaxima) {
            throw new ArgumentException("A data máxima deve ser maior que a data máxima.");
        }

    }

    public TimeSpan ValidarHoraInformada(string hora) {
        if (!TimeSpan.TryParse(hora, out TimeSpan _hora))
        {
        throw new Exception($"Hora {hora} Inválida!");
        }
        return _hora;
    }
    public void ValidarHora()
    {   
        if (_horaMaxima <= _horaMinima) {
            throw new ArgumentException("A hora máxima deve ser maior que a hora mínima.");
        }

    }

}
