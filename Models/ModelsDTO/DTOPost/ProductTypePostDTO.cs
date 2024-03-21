

using System.ComponentModel.DataAnnotations;

namespace Models.ModelsDTO.DTOPost
{
    public class ProductTypePostDTO
    {

        [Required(ErrorMessage = "This is required")]
        public string? name { get; set;}

        [Required(ErrorMessage = "This is required")]
        public string? description { get; set; }
    }
}
