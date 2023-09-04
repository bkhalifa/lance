namespace Wego.Domain.Common
{
    public class LocationModel : BaseReferentialModel
    {
        public string ZipCode { get; set; }
        public string ParentName { get; set; }
        public LocationType LocationType { get; set; }
    }

    public enum LocationType
    {
        ZipCode = 1,
        City = 2,
        Region = 3,
    }
}
