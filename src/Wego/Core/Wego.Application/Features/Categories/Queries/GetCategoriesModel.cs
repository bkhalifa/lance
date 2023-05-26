namespace Wego.Application.Features.Categories.Queries
{
    public class GetCategoriesModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public short? Type { get; set; }
    }
}
