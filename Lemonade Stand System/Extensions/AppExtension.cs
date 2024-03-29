using Lemonade_Stand_System.Middleware;

namespace Lemonade_Stand_System.Extensions
{
    public static class AppExtension
    {
        public static void useErrorMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ErrorMiddleware>();
        }
    }
}
