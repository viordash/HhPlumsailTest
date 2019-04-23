using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using HhPlumsailApp.Exceptions;
using HhPlumsailApp.Models;

namespace HhPlumsailApp.Services {
	public class OrderManagmentService : IOrderManagmentService {
		readonly List<OrderModel> internalStorage;
		object lockObj = new object();

		public OrderManagmentService() {
			internalStorage = new List<OrderModel>() {
				new OrderModel() {
					Id = 0,
					Date = new DateTime(2019, 04, 22),
					Customer = "Customer1",
					Status = OrderStatus.Created,
					Prepaid = false,
					Summ = 12.34M,
					Description = "Description1"
				},
				new OrderModel() {
					Id = 1,
					Date = new DateTime(2019, 04, 01),
					Customer = "Customer2",
					Status = OrderStatus.InProcess,
					Prepaid = false,
					Summ = 19.42M,
					Description = "Description2"
				}
			};
		}

		public void Create(OrderModel order) {
			AssertOrderModel(order);
			if(internalStorage.Any(x => order.Equals(x))) {
				throw new DuplicateRecordException();
			}
			AppendRecord(order);
		}

		public void Delete(int orderId) {
			var order = Retrieve(orderId);
			internalStorage.Remove(order);
		}

		public void Edit(OrderModel order) {
			AssertOrderModel(order);
			Delete(order.Id);
			internalStorage.Add(order);
		}

		public List<OrderModel> List() {
			return internalStorage.OrderBy(x => x.Id).ToList();
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

		void AppendRecord(OrderModel order) {
			lock(lockObj) {
				order.Id = internalStorage.Count();
				internalStorage.Add(order);
			}
		}
	}
}