using System.ComponentModel.DataAnnotations;

namespace EXE201_2RE_API.Models
{
    public partial class TblFavorite
    {
        [Key]
        public Guid FavoriteId { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required]
        public Guid ProductId { get; set; }

        public virtual TblUser User { get; set; }

        public virtual TblProduct Product { get; set; }
    }
}
