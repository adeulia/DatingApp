using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    //photo entity to be called photos in db
    [Table("Photos")]

    public class Photo
    {
        public int Id { get; set; }
        public string? Url { get; set; }
        public bool IsMain { get; set; }
        public string? PublicId { get; set; }

        //fully defining the relationship
        public AppUser? AppUser { get; set; }
        public int AppUserId { get; set; }
    }
}