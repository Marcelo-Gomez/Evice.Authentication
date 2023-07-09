using FluentValidation.Results;
using System.Net;

namespace Evice.Authentication.Domain.SeedWork.Bases
{
    public class ResponseBase<T>
    {
        public ResponseBase() 
        {
            this.Success = true;
            this.HttpStatusCode = HttpStatusCode.OK;
            this.Errors = null;
        }

        public bool Success { get; set; }

        public T? Data { get; set; }

        public HttpStatusCode HttpStatusCode { get; set; }

        public IList<ErrorBase>? Errors { get; set; }

        public void AddError(HttpStatusCode httpStatusCode, string message)
        {
            this.Data = default;
            this.Success = false;
            this.HttpStatusCode = httpStatusCode;

            if (this.Errors == null)
            {
                this.Errors = new List<ErrorBase>() { new ErrorBase(message) };
            }
            else
            {
                this.Errors.Add(new ErrorBase(message));
            }
        }

        public void AddErrors(HttpStatusCode httpStatusCode, List<ValidationFailure> errors)
        {
            this.Data = default;
            this.Success = false;
            this.HttpStatusCode = httpStatusCode;

            if (this.Errors == null)
            {
                this.Errors = new List<ErrorBase>();
            }

            foreach (var error in errors)
            {
                this.Errors.Add(new ErrorBase(error.ErrorMessage));
            }
        }
    }
}