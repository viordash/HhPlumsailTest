using System.Collections.Generic;

namespace HhPlumsailApp.Models {
	public enum OrderStatus {
		Created = 0,
		InProcess,
		Closed
	}

	public static class OrderStatusSpecifics {
		public static Dictionary<OrderStatus, string> Names = new Dictionary<OrderStatus, string>() {
			{ OrderStatus.Created, "Created" },
			{ OrderStatus.InProcess, "In process" },
			{ OrderStatus.Closed, "Closed" },
		};
	}
}