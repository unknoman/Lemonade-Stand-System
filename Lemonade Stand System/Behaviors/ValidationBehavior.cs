using MediatR;
using System.ComponentModel.DataAnnotations;

public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var validationContext = new ValidationContext(request);
        var validationResults = new List<ValidationResult>();

        // Realizar la validación
        if (!Validator.TryValidateObject(request, validationContext, validationResults, validateAllProperties: true))
        {
            // Construir un diccionario de errores de validación en el formato deseado
            var validationErrors = new Dictionary<string, List<string>>();
            if (!Validator.TryValidateObject(request, validationContext, validationResults, validateAllProperties: true))
            {
                // Construir un mensaje de error que represente los errores de validación
                var errorMessage = string.Join("\n", validationResults
                    .SelectMany(result => result.MemberNames.Select(memberName => $"{memberName}: {result.ErrorMessage}")));

                // Lanzar una excepción de validación con el mensaje de error
                throw new ValidationException(errorMessage);
            }
        }

        // Continuar con la ejecución del siguiente handler
        return await next();
    }


}
