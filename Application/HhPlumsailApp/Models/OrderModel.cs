using System;
using System.Collections.Generic;
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

		public override bool Equals(object obj) {
			if(ReferenceEquals(obj, null)) {
				return false;
			}

			if(ReferenceEquals(this, obj)) {
				return true;
			}
			if(!(obj is OrderModel otherOrderModel)) {
				return false;
			}
			return Date == otherOrderModel.Date
				&& Customer == otherOrderModel.Customer
				&& Status == otherOrderModel.Status
				&& Prepaid == otherOrderModel.Prepaid
				&& Summ == otherOrderModel.Summ
				&& Description == otherOrderModel.Description;
		}

		public override int GetHashCode() {
			var hashCode = 1754935533;
			hashCode = hashCode * -1521134295 + Date.GetHashCode();
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Customer);
			hashCode = hashCode * -1521134295 + Status.GetHashCode();
			hashCode = hashCode * -1521134295 + Prepaid.GetHashCode();
			hashCode = hashCode * -1521134295 + Summ.GetHashCode();
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Description);
			return hashCode;
		}
	}
}