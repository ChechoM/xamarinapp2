using AppParqueadero.Data.Models;
using AppParqueadero.Data.Models.Dto;
using Xamarin.Forms;

namespace AppParqueadero.Controls
{
    public class ClientTemplateSelector : DataTemplateSelector
    {
        public DataTemplate DefaultTemplate { get; set; }
        public DataTemplate CalificacionBaja { get; set; }
        public DataTemplate CalificacionesMedia { get; set; }
        public DataTemplate CalificacionesAlta { get; set; }

        protected override DataTemplate OnSelectTemplate(object clientObject, BindableObject container)
        {
            if (!(clientObject is ReporteVisitasDto client))
            {
                return DefaultTemplate;
            }

            var dnaLength = client.PromedioCalificacion;
            

                if (dnaLength > 0 && dnaLength <= 2)
                {
                    return CalificacionBaja;
                }

                if (dnaLength == 3)
                {
                    return CalificacionesMedia;
                }

                if (dnaLength > 3)
                {
                    return CalificacionesAlta;
                }

            

            return DefaultTemplate;
        }
    }
}
