using LXF.Web.Models.ViewModels;
using Newtonsoft.Json;

namespace LXF.Web.Service.IService
{
    public class ServiceBase
    {
        public static List<T> DesearilizeList<T>(ResponseViewModel? vm)
        {
            return JsonConvert.DeserializeObject<List<T>>(Convert.ToString(vm.Result));
        }

        public static T Desearilize<T>(ResponseViewModel? vm)
        {
            return JsonConvert.DeserializeObject<T>(Convert.ToString(vm.Result));
        }
    }
}
