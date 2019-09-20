namespace Models.Entities
{
    public class Resim
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public short Sira { get; set; }
        public bool IsSelected { get; set; }
        public bool Deleted { get; set; }

        public int HizmetlerimizMenuId { get; set; }
        public virtual HizmetlerimizMenu HizmetlerimizMenu { get; set; }

    }
}