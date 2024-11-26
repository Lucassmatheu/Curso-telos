using System.Data.SqlClient;
using System.Web.Mvc;
using System.Web.Routing;

public class RouteConfig
{
    public static void RegisterRoutes(RouteCollection routes)
    {
        // Ignorar os arquivos .axd
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

        // Definir a rota padrão
        routes.MapRoute(
            name: "Default",
            url: "{controller}/{action}/{id}",
            defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
        );
    }
}
