using Microsoft.Extensions.DependencyInjection;

namespace SalaryFinanceInterview.ApiClient.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSalaryFinanceApi(this IServiceCollection services,string baseUrl)
        {
            services.AddHttpClient<ISalaryFinanceApiClient, SalaryFinanceApiClient>(client =>
            {
                client.BaseAddress = new Uri(baseUrl);
            });

            return services;
        }
    }
}
