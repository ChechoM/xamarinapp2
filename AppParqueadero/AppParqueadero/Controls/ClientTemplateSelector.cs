using AppParqueadero.Data.Models;
using Xamarin.Forms;

namespace AppParqueadero.Controls
{
    public class ClientTemplateSelector : DataTemplateSelector
    {
        public DataTemplate DefaultTemplate { get; set; }
        public DataTemplate OneToFiveTemplate { get; set; }
        public DataTemplate SixToTenTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object clientObject, BindableObject container)
        {
            if (!(clientObject is Client client))
            {
                return DefaultTemplate;
            }

            var dnaLength = client.nit.Length;
            var lastDigit = client.nit.Substring(dnaLength - 1);

            if (int.TryParse(lastDigit, out var intValue))
            {

                if (intValue > 0 && intValue <= 5)
                {
                    return OneToFiveTemplate;
                }

                if (intValue > 5 && intValue <= 10)
                {
                    return SixToTenTemplate;
                }
            }

            return DefaultTemplate;
        }
    }
}
