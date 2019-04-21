﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HhPlumsailApp.Exceptions;
using HhPlumsailApp.Models;
using HhPlumsailApp.Services;
using NUnit.Framework;

namespace HhPlumsailApp.Tests.Services {
	[TestFixture]
	public class OrderManagmentServiceTest {
		static OrderModel order1 = new OrderModel() {
			Id = 19,
			Date = DateTime.Now,
			Customer = "Customer1",
			Status = OrderStatus.Created,
			Prepaid = false,
			Summ = 12.34M,
			Description = "Description1"
		};
		static OrderModel order2 = new OrderModel() {
			Id = 42,
			Date = DateTime.Now,
			Customer = "Customer2",
			Status = OrderStatus.Created,
			Prepaid = false,
			Summ = 19.42M,
			Description = "Description2"
		};
		OrderManagmentService testable;

		[SetUp]
		public virtual void SetUp() {
			testable = new OrderManagmentService();
		}

		#region Create
		[Test]
		public void Create_ReturnsOrderModel() {
			var result = testable.Create(order1);
			Assert.That(result, Is.EqualTo(order1));
			AssertInternalStorage(new List<OrderModel>() { order1 });
		}

		[Test]
		public void Create_EmptyOrder_ThrowsValidationException() {
			Assert.Throws<ValidationException>(() => testable.Create(null));
		}

		[Test]
		public void Create_DuplicateOrder_ThrowsDuplicateRecordException() {
			AddOrderToInternalStorage(order1);
			Assert.Throws<DuplicateRecordException>(() => testable.Create(order1));
		}
		#endregion

		#region Delete
		[Test]
		public void Delete_Test() {
			AddOrderToInternalStorage(order1);
			AddOrderToInternalStorage(order2);
			testable.Delete(order1.Id);
			AssertInternalStorage(new List<OrderModel>() { order2 });
		}

		[Test]
		public void Delete_NotExistsOrder_ThrowsObjectNotFoundException() {
			Assert.Throws<ObjectNotFoundException>(() => testable.Delete(-1));
		}
		#endregion

		#region Edit
		[Test]
		public void Edit_ReturnsOrderModel() {
			AddOrderToInternalStorage(order1);
			var modifiedOrder = new OrderModel() { Id = order1.Id, Customer = order1.Customer + " edited" };
			var result = testable.Edit(modifiedOrder);
			Assert.That(result.Customer, Is.EqualTo(modifiedOrder.Customer));
			AssertInternalStorage(new List<OrderModel>() { modifiedOrder });
		}

		[Test]
		public void Edit_EmptyOrder_ThrowsValidationException() {
			Assert.Throws<ValidationException>(() => testable.Edit(null));
		}

		[Test]
		public void Edit_NotExistsOrder_ThrowsObjectNotFoundException() {
			var modifiedOrder = new OrderModel() { Id = -1 };
			Assert.Throws<ObjectNotFoundException>(() => testable.Edit(modifiedOrder));
		}
		#endregion

		#region List
		[Test]
		public void List_ReturnsOrderModels() {
			AddOrderToInternalStorage(order1);
			AddOrderToInternalStorage(order2);
			var orders = testable.List();
			Assert.That(orders, Is.EquivalentTo(new List<OrderModel>() { order1, order2 }));
		}
		#endregion

		#region Retrieve
		[Test]
		public void Retrieve_ReturnOrderModel() {
			AddOrderToInternalStorage(order1);
			AddOrderToInternalStorage(order2);
			var order = testable.Retrieve(order2.Id);
			Assert.That(order, Is.EqualTo(order2));
		}
		#endregion

		void AssertInternalStorage(IEnumerable equivalentToExpected) {
			var orders = testable.List();
			Assert.That(orders, Is.EquivalentTo(equivalentToExpected));
		}

		void AddOrderToInternalStorage(OrderModel orderModel) {
			var result = testable.Create(orderModel);
		}
	}
}