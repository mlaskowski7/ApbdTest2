using ApbdTest2.Api.Contracts.Response;
using ApbdTest2.Domain.Models;

namespace ApbdTest2.Application.Mappers.Impl;

public class ConcertMapper : IConcertMapper
{
    public ConcertResponseDto ToConcertResponseDto(Concert concert)
    {
        return new ConcertResponseDto(concert.Name, concert.Date);
    }
}