namespace ApplyBuddy.Server.Domain.Documents;

public class CV
{
    public string? Summary { get; init; }
    public IReadOnlyList<string>? Skills { get; init; }
    public IReadOnlyList<EducationEntry>? Education { get; init; }
    public IReadOnlyList<JobHistoryEntry>? JobHistory { get; init; }
    public string? AboutSection { get; init; }
    
    public override string ToString()
    {
        var educationList = Education?.Select(e => 
            $"\n    - {e.Institute} ({e.StartDate:yyyy}-{e.EndDate:yyyy}), Grade: {e.Grade}, Subjects: {string.Join(", ", e.Subjects)}").ToList();
            
        var jobList = JobHistory?.Select(j => 
            $"\n    - {j.Title} ({j.StartDate:yyyy}-{j.EndDate:yyyy})\n      {j.Description}").ToList();
            
        return $"""
            Summary: {Summary}
            
            Skills: {(Skills != null ? string.Join(", ", Skills) : "None")}
            
            Education: {(educationList?.Any() == true ? string.Join("", educationList) : "\n    None")}
            
            Job History: {(jobList?.Any() == true ? string.Join("", jobList) : "\n    None")}
            
            About: {AboutSection}
            """;
    }
}

public record JobHistoryEntry(
    string? Title,
    DateTime? StartDate,
    DateTime? EndDate,
    string? Description);

public record EducationEntry(
    string? Institute,
    string? Grade,
    DateTime? StartDate,
    DateTime? EndDate,
    List<string> Subjects);