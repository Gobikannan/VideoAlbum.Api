namespace VideoAlbum.Domain.Entities
{
    public class Album : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Artist { get; set; }
        public string Label { get; set; }
        public int TypeId { get; set; }
        public string Type { get; set; }
        public int Stock { get; set; }
    }
}
