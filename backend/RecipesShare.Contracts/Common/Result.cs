namespace RecipesShare.Contracts.Common
{
    public class Result
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = string.Empty;
    }
    public class Result<T> where T : class
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = string.Empty;
        public T Value { get; set; }
    }
}