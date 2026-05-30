namespace SalaryFinanceInterview.Api.Models.Common
{
    public class GenericModel<T>
    {
        public T? Data { get; set; }

        public string Message { get; set; } = "Default Metadata";
    }
}
