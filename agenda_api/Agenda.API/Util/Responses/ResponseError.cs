using Microsoft.AspNetCore.Mvc;

namespace Agenda.API.Util.Responses
{
    public class ResponseError
    {
        public ProblemDetails DetailsError { get; set; }

        public ProblemDetails ResponseDetailsError(int statusCode, string message, string detail)
        {
            DetailsError = new ProblemDetails
            {
                Status = statusCode,
                Title = message,
                Detail = detail
            };

            return DetailsError;
        }
    }
}