namespace StockApi.UI.Models
{
    public class ErrorResponse
    {
        public ErrorResponse()
        {
            Errors = new List<ErrorModel>();
        }
        public IList<ErrorModel> Errors { get; set; } 
    }
}
