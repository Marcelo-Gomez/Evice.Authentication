namespace Evice.Authentication.Domain.SeedWork.Bases
{
    public class ErrorBase
    {
        public ErrorBase(string message) => this.Message = message;
        
        public string Message { get; set; }
    }
}