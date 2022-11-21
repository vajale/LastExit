namespace SomethingArchitecture.Scripts.Dialoge
{
    public interface IDialogeUnit
    {
        string Text { get; }
        DialogeType DialogeType { get; }
    }
}