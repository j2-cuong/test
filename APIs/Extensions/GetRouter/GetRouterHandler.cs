#pragma warning disable

using DapperServices;
using Dapper;
using System.Data.SqlClient;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace APIs.Logic
{
    public class GetRouterHandler : IGetRouterHandler
    {

        public async Task<string> GetUrls()
        {
            var urls = await GenerateUrls();
            return JsonConvert.SerializeObject(urls, Formatting.Indented);
        }

        public async Task<List<Dictionary<string, object>>> GenerateUrls()
        {
            var controllers = Assembly.GetExecutingAssembly().GetTypes()
                .Where(type => type.IsSubclassOf(typeof(ControllerBase)) && !type.IsAbstract);

            var urlList = new List<Dictionary<string, object>>();

            foreach (var controller in controllers)
            {
                // Kiểm tra nếu Controller có ControllerDescriptionAttribute
                var descriptionAttribute = controller.GetCustomAttribute<ControllerDescriptionAttribute>();
                if (descriptionAttribute == null)
                {
                    // Nếu không có ControllerDescriptionAttribute, bỏ qua controller này
                    continue;
                }

                var controllerName = controller.Name.Replace("Controller", "");
                var controllerRouteAttribute = controller.GetCustomAttribute<RouteAttribute>();
                string controllerRoute = controllerRouteAttribute?.Template ?? "[controller]";

                var actions = controller.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly)
                    .Where(m => m.IsPublic && !m.IsDefined(typeof(NonActionAttribute)));

                var actionUrls = new Dictionary<string, string>();

                foreach (var action in actions)
                {
                    var actionName = action.Name;
                    var actionRouteAttribute = action.GetCustomAttribute<RouteAttribute>();
                    string actionRoute = actionRouteAttribute?.Template ?? "[action]";

                    // Thay thế [controller] và [action] trong template
                    var url = controllerName + "/" + actionName;
                    actionUrls[actionName] = url;
                }

                // Lấy mô tả từ attribute
                var description = descriptionAttribute.Description;

                // Tạo đối tượng cho controller với mô tả và các action
                urlList.Add(new Dictionary<string, object>
            {
                { "Title", description },
                { "path", actionUrls }
            });
            }

            return urlList;
        }
    }
}
