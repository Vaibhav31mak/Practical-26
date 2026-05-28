namespace Practical26.Domain.Entities;

/// <summary>
/// Interface representing the status of an entity, typically 
/// used to soft delete records or indicate active & inactive state in the system.
/// </summary>
public interface IStatus
{
    bool Status { get; set; }
}
