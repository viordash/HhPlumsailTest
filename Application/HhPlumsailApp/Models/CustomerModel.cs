using System.ComponentModel.DataAnnotations;

namespace HhPlumsailApp.Models {
	public class CustomerModel {
		[Required]
		public int Id { get; set; }
		[Required]
		[StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.")]
		public string Name { get; set; }
	}
}