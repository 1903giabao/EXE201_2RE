using System.ComponentModel.DataAnnotations;

namespace EXE201_2RE_API.Models
{
    public partial class TblFavorite
    {
        [Key]
        public int FavoriteId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int ProductId { get; set; }

        public virtual TblUser User { get; set; }

        public virtual TblProduct Product { get; set; }
    }
}
