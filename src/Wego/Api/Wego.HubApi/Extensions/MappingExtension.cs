using Mapster;


namespace Wego.HubApi.Extensions
{
    public static class MappingExtension
    {
        public static T MapTo<T>(this object source) where T : class
        {
            return source.Adapt<T>();
        }
    }
}
