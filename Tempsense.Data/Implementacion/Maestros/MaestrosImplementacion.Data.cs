using AutoMapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tempsense.Data.Interfaz.Maestros;
using Tempsense.Entities;
using Tempsense.Entities.Dtos.Dtos.Maestros;

namespace Tempsense.Data.Implementacion.Maestros
{
    public class MaestrosImplementacionData: IMaestrosInterfazData
    {
        private const int FiltroDias = 1440;

        private IntelControlEntities _interlControlEntitie = new IntelControlEntities();

        public List<TipoMedidasDto> ListarMedidas()
        {
            var resutlSave = _interlControlEntitie.tbl_TipoMedidas.ToList();
            return Mapper.Map<List<TipoMedidasDto>>(resutlSave);
        }

        //public List<Medida> ListarPromedios(int pageIndex, int pageSize, out int pageCount,
        //    int dispositivo, string fechaInicio, string fechaFin, string idUser = "",
        //    string perfil = "", int filtroTiempo = 0)
        //{
            
        //        SqlDataReader reader;
        //        List<Medida> listaMedidas = new List<Medida>();

        //        string fechaInicioSt;
        //        string fechaFinSt;

        //        int diasAtras = 0;
        //        if (!Int32.TryParse(ConfigurationManager.AppSettings["DaysAgo"], out diasAtras))
        //        {
        //            diasAtras = 30;
        //        }

        //        //if (perfil != PerfilAdministrador && dispositivo != 0)
        //        //{
        //        //    if (!UserHelper.ValidarDispositivosAsociados(idUser, dispositivo))
        //        //    {
        //        //        pageCount = 0;
        //        //        return listaMedidas;
        //        //    }
        //        //}

        //        if (fechaInicio != "" && fechaFin != "")
        //        {
        //            fechaInicioSt = fechaInicio + " 00:00";
        //            fechaFinSt = fechaFin + " 23:59";
        //        }
        //        else if (fechaFin != "")
        //        {
        //            var fechaActual = DateTime.Now;
        //            var hor = fechaActual.Hour;
        //            var min = fechaActual.Minute;

        //            var fechaAnterior = fechaActual.Date.AddDays(-diasAtras).AddHours(hor).AddMinutes(min);
        //            fechaInicioSt = $"{fechaAnterior:yyyy-MM-dd HH:mm:ss}";
        //            fechaFinSt = fechaFin + " 23:59";
        //        }
        //        else if (fechaInicio != "")
        //        {
        //            var fechaActual = DateTime.Now;
        //            fechaInicioSt = fechaInicio + " 00:00";
        //            fechaFinSt = $"{fechaActual:yyyy-MM-dd HH:mm:ss}";
        //        }
        //        else
        //        {
        //            var fechaActual = DateTime.Now;
        //            var hor = fechaActual.Hour;
        //            var min = fechaActual.Minute;

        //            var fechaAnterior = fechaActual.Date.AddDays(-diasAtras).AddHours(hor).AddMinutes(min);

        //            fechaFinSt = $"{fechaActual:yyyy-MM-dd HH:mm:ss}";
        //            fechaInicioSt = $"{fechaAnterior:yyyy-MM-dd HH:mm:ss}";
        //        }

        //        string whereTotal = " FechaHora BETWEEN ('" + fechaInicioSt + "') AND ('" + fechaFinSt + "') ";


        //        if (dispositivo != 0)
        //        {
        //            whereTotal = whereTotal != "" ? whereTotal + " AND DispositivoID = " + dispositivo : " DispositivoID = " + dispositivo;
        //        }
        //        else
        //        {
        //            whereTotal = "";
        //        }

        //        whereTotal = whereTotal != "" ? "WHERE " + whereTotal : "";

        //        string querySearch = " Select(DATEPART(MINUTE, FechaHora) / " + filtroTiempo + ") as minuto, " +
        //                             " DATEPART(hh, FechaHora) as hora, " +
        //                             " DATEPART(DAY, FechaHora) as dia, ";

        //        string queryGroupSearch = " DATEPART(hh, FechaHora), " + " (DATEPART(MINUTE, FechaHora) / " + filtroTiempo + ") ";

        //        if (filtroTiempo == FiltroDias)
        //        {
        //            querySearch = "Select (DATEPART(DAY, FechaHora)) as dia, ";
        //            queryGroupSearch = "";
        //        }

        //        string sqlCountMedidas = "SELECT COUNT(Promedios.promedio) FROM ( " +
        //              querySearch +
        //            " AVG(Valor) as promedio " +
        //            " FROM Medidas " + whereTotal +
        //            " Group by " +
        //            queryGroupSearch +
        //            ", DATEPART(DAY, FechaHora) " +
        //            " ) AS Promedios";

        //        int consultaTotalMedidasEncontradas = 0;

        //        using (SqlCommand cmdTotal = new SqlCommand())
        //        {

        //            // consulta total items encontrado
        //            try
        //            {
        //                cmdTotal.CommandType = CommandType.Text;
        //                cmdTotal.Connection = _interlControlEntitie.;
        //                cmdTotal.CommandText = sqlCountMedidas;

        //                reader = cmdTotal.ExecuteReader();

        //                while (reader.Read())
        //                {
        //                    consultaTotalMedidasEncontradas = (int)reader[0];
        //                }

        //            }
        //            catch (Exception ex)
        //            {
                        
        //            }
        //        }

        //        string filtro = "";
        //        switch (filtroTiempo)
        //        {
        //            case 15:
        //                filtro = " WHERE minuto IN (" + 00 + "," + 15 + "," + 30 + "," + 45 + "))b";
        //                break;
        //            case 30:
        //                filtro = " WHERE minuto IN (" + 00 + "," + 30 + "))b";
        //                break;
        //            case 60:
        //                filtro = " WHERE minuto IN (" + 00 + "))b";
        //                break;
        //            default:
        //                filtro = " WHERE minuto IN (" + 00 + "))b";
        //                break;
        //        }

        //        string consultaFiltroTotal = "SELECT * " +
        //        "FROM(SELECT(ROW_NUMBER() OVER(ORDER BY Years desc,mes desc, dia desc, hora desc, minuto desc)) AS consecutivo, * " +
        //        "FROM " +
        //        "(SELECT " +
        //        "DATEPART(n, FechaHora) AS minuto, " +
        //        "DATEPART(hh, FechaHora) AS hora, " +
        //        "DATEPART(DAY, FechaHora) AS dia, " +
        //        "DATEPART(MONTH, FechaHora) mes, " +
        //        "DATEPART(YEAR, FechaHora) Years, " +
        //        "AVG(Valor) AS valor " +
        //        "FROM Medidas " +
        //        "WHERE " +
        //        "FechaHora BETWEEN('" + fechaInicioSt + "') AND('" + fechaFinSt + "')  AND DispositivoID = " + dispositivo +
        //        " Group by DATEPART(YEAR, FechaHora), " +
        //        " DATEPART(MONTH, FechaHora)," +
        //        " DATEPART(DAY, FechaHora)," +
        //        " DATEPART(hh, FechaHora)," +
        //        " DATEPART(MINUTE, FechaHora))t " +
        //          filtro +
        //        " ORDER BY consecutivo ASC";
        //        //WHERE b.consecutivo BETWEEN(" + pageIndex + ") AND(" + (pageIndex + pageSize) + ")
        //        using (SqlCommand cmd = new SqlCommand())
        //        {
        //            try
        //            {

        //                cmd.CommandType = CommandType.Text;
        //                cmd.CommandText = consultaFiltroTotal;
        //                reader = cmd.ExecuteReader();
        //                while (reader.Read())
        //                {
        //                    var medida = new Medida { Valor = (decimal)reader["valor"] };
        //                    string hora = "00";
        //                    string minuto = "00";
        //                    if (filtroTiempo != FiltroDias)
        //                    {
        //                        if (reader["hora"] != DBNull.Value)
        //                        {
        //                            hora = reader["hora"].ToString();
        //                        }
        //                        if (reader["minuto"] != DBNull.Value)
        //                        {
        //                            minuto = reader["minuto"].ToString();
        //                        }
        //                    }

        //                    var fechaD = reader["dia"] + "/" + reader["mes"] + "/" + reader["Years"] + " " + (hora == "24" ? "00" : hora) + ":" + minuto + ":00";
        //                    medida.FechaHora = Convert.ToDateTime(fechaD);
        //                    medida.DispositivoID = dispositivo;
        //                    listaMedidas.Add(medida);

        //                }

        //            }
        //            catch (Exception ex)
        //            {
        //            //    Debug.WriteLine("ERROR Medidas.cs Func ListarPromedios: ");
        //            //    Debug.WriteLine("ERROR EN EL SISTEMA : " + ex.GetBaseException());
        //            }
        //            //finally
        //            //{
        //            //    sqlConnection1.Close();
        //            //}

        //        }

        //        pageCount = consultaTotalMedidasEncontradas;

        //        return listaMedidas;
        //    }
        


    }
}
