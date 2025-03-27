using LXF.Web.Models.ViewModels;
using Newtonsoft.Json;

namespace LXF.Web.Service.IService
{
    public class ServiceBase
    {
        public static List<T> DesearilizeList<T>(ResponseViewModel? ViewModel)
        {
            return JsonConvert.DeserializeObject<List<T>>(Convert.ToString(ViewModel.Result));
        }

        public static T Desearilize<T>(ResponseViewModel? ViewModel)
        {
            return JsonConvert.DeserializeObject<T>(Convert.ToString(ViewModel.Result));
        }
    }
}
