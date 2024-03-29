using System.ComponentModel.DataAnnotations;

namespace Models.ModelsDTO.DTOPost
{
    public class ProductPostDTO
    {
        [Required(ErrorMessage = "This field is required")]
        public float unityPrice { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string? name { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public float stock { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string? unitMeasure { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public int type { get; set; }
    }
}
