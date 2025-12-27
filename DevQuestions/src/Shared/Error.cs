using System.Text.Json.Serialization;

namespace Shared;

public record Error
{
    public string Code { get; }

    public string Message { get; }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public ErrorType Type { get; }

    public string? InvalideField { get; } // поле в котором возникла ошибка

    [JsonConstructor]
    private Error(string code, string message, ErrorType type, string? invalideField = null)
    {
        Code = code;
        Message = message;
        Type = type;
        InvalideField = invalideField;
    }

    public static Error NotFound(string? code, string message, Guid? id) =>
        new Error(code ?? "record.not.found", message, ErrorType.NOT_FOUND);

    public static Error Validation(string? code, string message, string? invalideField) =>
        new Error(code ?? "value.is.invalid", message, ErrorType.VALIDATION, invalideField);

    public static Error Conflict(string? code, string message) =>
        new Error(code ?? "value.is.conflict", message, ErrorType.CONFLICT);

    public static Error Failure(string? code, string message) =>
        new Error(code ?? "failure", message, ErrorType.FAILURE);
}

public enum ErrorType
{
    /// <summary>
    /// ошибка с валидацией
    /// </summary>
    VALIDATION,

    /// <summary>
    /// например запись не найдена
    /// </summary>
    NOT_FOUND,

    /// <summary>
    /// ошибка бизнеслогики , сервера
    /// </summary>
    FAILURE,

    /// <summary>
    /// При добавлении записи оказываеться , что она уже есть к примеру
    /// </summary>
    CONFLICT,
}