#pragma warning disable

[AttributeUsage(AttributeTargets.Class, Inherited = false)]
public class ControllerDescriptionAttribute : Attribute
{
    public string Description { get; }

    public ControllerDescriptionAttribute(string description)
    {
        Description = description;
    }
}
