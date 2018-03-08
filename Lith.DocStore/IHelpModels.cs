namespace Lith.DocStore
{
    public interface IHelpModels
    {
        string Stringify(object data);

        T DeStringify<T>(string data);
    }
}
