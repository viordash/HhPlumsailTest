using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using HhPlumsailApp.Exceptions;
using HhPlumsailApp.Models;

namespace HhPlumsailApp.Services {
	public class OrderManagmentService : IOrderManagmentService {
		readonly List<OrderModel> internalStorage;

		public OrderManagmentService() {
			internalStorage = new List<OrderModel>();
		}

		public OrderModel Create(OrderModel order) {
			AssertOrderModel(order);
			if(internalStorage.Any(x => x.Id == order.Id)) {
				throw new DuplicateRecordException();
			}
			internalStorage.Add(order);
			return order;
		}

		public void Delete(int orderId) {
			var order = Retrieve(orderId);
			internalStorage.Remove(order);
		}

		public OrderModel Edit(OrderModel order) {
			AssertOrderModel(order);
			Delete(order.Id);
			return Create(order);
		}

		public List<OrderModel> List() {
			return internalStorage;
		}

		public OrderModel Retrieve(int orderId) {
			var order = internalStorage.Where(x => x.Id == orderId).FirstOrDefault();
			if(order == null) {
				throw new ObjectNotFoundException();
			}
			return order;
		}

		void AssertOrderModel(OrderModel order) {
			var exception = new ValidationException();
			if(order == null) {
				exception.Data.Add(nameof(order), "The empty order");
			}

			if(exception.Data.Count > 0) {
				throw exception;
			}
		}
	}
}