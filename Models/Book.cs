using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Homework.Models
{
    public class Book
    {
        [Key]
        public long GId { get; set; }
        [Required(ErrorMessage = "必填")]
        [StringLength(30, ErrorMessage = "主旨最多30個字")]
        [Display(Name = "主旨")]
        public string Title { get; set; } = null!;
        [Required(ErrorMessage = "必填")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "留言內容")]
        public string Description { get; set; } = null!;
        [Required(ErrorMessage = "必填")]
        [StringLength(20, ErrorMessage = "姓名最多20個字")]
        [Display(Name = "留言人")]
        public string Author { get; set; } = null!;
        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm:ss}")]
        [Display(Name = "留言時間")]
        [HiddenInput]
        public DateTime TimeStamp { get; set; }
        [Display(Name = "照片")]
        public byte[]? Photo { get; set; }
        [HiddenInput]
        public string? ImageType { get; set; }

        public virtual List<ReBook>? ReBooks { get; set; }
    }
}
