using System;
using System.ComponentModel.DataAnnotations;

namespace HhPlumsailApp.Models {
	public class OrderModel {
		[Required]
		public int Id { get; set; }

		[Range(typeof(DateTime), "1/1/2010", "1/1/2029", ErrorMessage = "Value for {0} must be between {1} and {2}")]
		public DateTime Date { get; set; }

		[Required]
		[StringLength(16, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 4)]
		public string Customer { get; set; }

		public OrderStatus Status { get; set; }
		public bool Prepaid { get; set; }

		public decimal Summ { get; set; }

		public string Description { get; set; }

	}
}