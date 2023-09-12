namespace MyTriApp.Attributes
{
    [AttributeUsage(AttributeTargets.Parameter, Inherited = true, AllowMultiple = false)]
    public sealed class NotNullAttribute : Attribute
    {
    }
}
