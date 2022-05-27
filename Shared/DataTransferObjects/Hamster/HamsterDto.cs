namespace Shared.DataTransferObjects.Hamster;

public record HamsterDto(int Id, string Name, int Age,string FavFood, string Loves, int Wins,
    int Defeats, int Games);
