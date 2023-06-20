using System;
namespace Banking.Dto;

public enum ValidResponse
{
    Accepted,
    Declined
};

public record Response
{
    public string Message { get; set; } = ValidResponse.Declined.ToString();
};

