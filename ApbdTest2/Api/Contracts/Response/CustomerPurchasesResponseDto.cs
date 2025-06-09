namespace ApbdTest2.Api.Contracts.Response;

public record CustomerPurchasesResponseDto(
    string FirstName,
    string LastName,
    string? PhoneNumber,
    List<PurchaseResponseDto> Purchases);