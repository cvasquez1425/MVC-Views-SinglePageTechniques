using System;
using System.ComponentModel.DataAnnotations;

namespace SinglePage.Entities
{
    public class TrainingProduct
    {
        public int ProductId { get; set; }
        [Required(ErrorMessage ="Product Name must be filled in.")]
        [Display(Description ="Product Name")]
        [StringLength(150, MinimumLength =4, ErrorMessage ="Product name must be greater than {2} characters and less than {1} characters")]
        public string ProductName { get; set; }
        [Range(typeof(DateTime), "1/1/2000","12/31/2020", ErrorMessage ="Introduction Date must be in between {1} and {2}")]
        [Display(Description ="Introduction Date")]
        public DateTime IntroductionDate { get; set; }
        [Required(ErrorMessage ="Url must be filled in.")]
        [Display(Description ="URL")]
        [StringLength(150, MinimumLength = 4, ErrorMessage = "URL must be greater than {2} characters and less than {1} characters")]
        public string Url { get; set; }
        [Range(1, 9999,ErrorMessage ="{0} must be between {1} and {2}")]
        public decimal Price { get; set; }
    }
}
