namespace Lith.DocStore.Common
{
    public interface IHelpModels
    {
        string Stringify(object data);

        T DeStringify<T>(string data);
    }
}
