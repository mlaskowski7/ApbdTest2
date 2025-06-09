namespace ApbdTest2.Api.Contracts.Response;

public record PurchaseResponseDto(
    DateTime Date,
    decimal Price,
    TicketResponseDto Ticket,
    ConcertResponseDto Concert);