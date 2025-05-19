using System.Text.Json.Serialization;
using ApplyBuddy.Server.Enums;
using ApplyBuddy.Server.Model.ValueObjects;

namespace ApplyBuddy.Server.Model.JobApplication;

// Base
[JsonPolymorphic(TypeDiscriminatorPropertyName = "details_type")]
[JsonDerivedType(typeof(ClosedApplicationDetails), "submitted")]
[JsonDerivedType(typeof(OpenApplicationDetails), "not_submitted")]
public abstract record ApplicationDetails
{
    // For EF Core
    protected ApplicationDetails()
    {
    }

    protected ApplicationDetails(Guid applicationId)
    {
        ApplicationId = applicationId;
    }
    
    public abstract ApplicationState ApplicationState { get; set; }

    public int Id { get; protected init; }
    public Guid ApplicationId { get; private set; }
}

// Derived
public record OpenApplicationDetails : ApplicationDetails
{
    private OpenApplicationDetails()
    {
    }

    public OpenApplicationDetails(Guid applicationId)
        : base(applicationId) { }

    public static OpenApplicationDetails CreateWithIdForSeeding(int id, Guid applicationId)
    {
        var details = new OpenApplicationDetails(applicationId)
        {
            Id = id
        };
        return details;
    }
}

public record ClosedApplicationDetails : ApplicationDetails
{
    private ClosedApplicationDetails()
    {
    }

    public ClosedApplicationDetails(DateTime appliedDate, Guid applicationId)
        : base(applicationId)
    {
        AppliedDate = appliedDate;
    }
    
    public DateTime AppliedDate { get; private set; } = DateTime.UtcNow;
    public int DaysSinceApplication => (int)(DateTime.UtcNow - AppliedDate).TotalDays;
}