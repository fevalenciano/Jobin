using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Jobin.Practices.Helpers
{
    public static class ConversaoData
    {
        public static string ConverterStringMes(int idMes)
        {
            switch (idMes)
            {
                case 1: { return "Janeiro"; }
                case 2: { return "Fevereiro"; }
                case 3: { return "Março"; }
                case 4: { return "Abril"; }
                case 5: { return "Maio"; }
                case 6: { return "Junho"; }
                case 7: { return "Julho"; }
                case 8: { return "Agosto"; }
                case 9: { return "Setembro"; }
                case 10: { return "Outubro"; }
                case 11: { return "Novembro"; }
                case 12: { return "Dezembro"; }
                default: { return ""; }
            }
        }

        public static string ConverteDiaSemana(string diaSemana)
        {
            switch (diaSemana)
            {
                case "Monday": { return "Segunda-feira,"; }
                case "Tuesday": { return "Terça-feira,"; }
                case "Wednesday": { return "Quarta-feira,"; }
                case "Thursday": { return "Quinta-feira,"; }
                case "Friday": { return "Sexta-feira,"; }
                case "Saturday": { return "Sábado,"; }
                case "Sunday": { return "Domingo,"; }
                default: { return ""; }
            }
        }
    }
}
