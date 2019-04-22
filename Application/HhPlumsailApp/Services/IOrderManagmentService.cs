using System.Collections.Generic;
using HhPlumsailApp.Models;

namespace HhPlumsailApp.Services {
	public interface IOrderManagmentService {
		List<OrderModel> List();
		OrderModel Retrieve(int orderId);
		void Create(OrderModel order);
		void Edit(OrderModel order);
		void Delete(int orderId);
	}
}