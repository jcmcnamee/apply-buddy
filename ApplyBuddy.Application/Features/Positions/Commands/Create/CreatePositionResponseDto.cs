namespace ApplyBuddy.Application.Features.Positions.Commands.Create;

public class CreatePositionResponseDto
{
    public Guid Id { get; init; }
    public string Name { get; set; } = string.Empty;
    public string? ShortDescription { get; set; } = string.Empty;
    public bool IsActive { get; set; }
}