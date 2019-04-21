using System.Collections.Generic;
using HhPlumsailApp.Models;

namespace HhPlumsailApp.Services {
	public interface IOrderManagmentService {
		List<OrderModel> List();
		OrderModel Retrieve(int orderId);
		OrderModel Create(OrderModel order);
		OrderModel Edit(OrderModel order);
		void Delete(int orderId);
	}
}