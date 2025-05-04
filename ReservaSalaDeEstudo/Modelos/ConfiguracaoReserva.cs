using System;

namespace ReservaSalaDeEstudo.Modelos;

public class ConfiguracaoReserva
{

    private DateTime _dataMinima;
    private DateTime _dataMaxima;
    private TimeSpan _horaMinima;
    private TimeSpan _horaMaxima;


    public DateTime DataMinina {
        get { return _dataMinima; }
    }

    public DateTime DataMaxima {
        get { return _dataMaxima; }
    }

    public TimeSpan HoraMinima {
        get { return _horaMinima; }
    }

    public TimeSpan HoraMaxima {
        get { return _horaMaxima; }
    }

    public void ValidarData(DateTime dataMinima, DateTime dataMaxima)
    {
        if (dataMinima < DateTime.Now || dataMaxima < DateTime.Now)
            throw new ArgumentException("As datas não podem ser anteriores à data atual.");

        if (dataMinima >= dataMaxima)
            throw new ArgumentException("A data mínima deve ser menor que a data máxima.");

        _dataMinima = dataMinima;
        _dataMaxima = dataMaxima;

    }

    public void ValidarHora(TimeSpan horaMinima, TimeSpan horaMaxima)
    {   
        if (horaMinima >= horaMaxima)
            throw new ArgumentException("A hora mínima deve ser menor que a hora máxima.");

        _horaMinima = horaMinima;
        _horaMaxima = horaMaxima;
    }

}
