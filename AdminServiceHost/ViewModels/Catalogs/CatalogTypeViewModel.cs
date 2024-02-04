using System.ComponentModel.DataAnnotations;

namespace AdminServiceHost.ViewModels.Catalogs
{
    public class CatalogTypeViewModel
    {
        public long Id { get; set; }
        [Display(Name = "نام دسته بندی")]
        [Required]
        [MaxLength(100, ErrorMessage = "حداکثر باید 100 کاراکتر باشد")]
        public string Type { get; set; }
        public long? ParentCatalogTypeId { get; set; }
    }
}
