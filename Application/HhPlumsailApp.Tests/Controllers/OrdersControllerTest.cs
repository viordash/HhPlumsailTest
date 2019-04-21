using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HhPlumsailApp.Controllers;
using HhPlumsailApp.Models;
using HhPlumsailApp.Services;
using Moq;
using NUnit.Framework;

namespace HhPlumsailApp.Tests.Controllers {
	[TestFixture]
	public class OrdersControllerTest {
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

		OrdersController testable;
		Mock<IOrderManagmentService> orderManagmentServiceMock;

		[SetUp]
		public virtual void SetUp() {
			orderManagmentServiceMock = new Mock<IOrderManagmentService>();
			testable = new OrdersController(orderManagmentServiceMock.Object);
		}

		[TearDown]
		public virtual void TearDown() {
			testable.Dispose();
		}

		#region Get
		[Test]
		public void Get_ReturnsOrders() {
			orderManagmentServiceMock
				.Setup(x => x.List())
				.Returns(() => {
					return new List<OrderModel>() { order1, order2 };
				});

			var result = testable.Get();
			Assert.That(result, Is.EquivalentTo(new List<OrderModel>() { order1, order2 }));
		}

		[Test]
		public void Get_ReturnSelectedOrder() {
			orderManagmentServiceMock
				.Setup(x => x.Retrieve(It.Is<int>(id => id == order2.Id)))
				.Returns(() => {
					return order2;
				});

			var result = testable.Get(order2.Id);
			Assert.That(result, Is.EqualTo(order2));
		}
		#endregion

		#region Post
		[Test]
		public void Post_ReturnSelectedOrder() {
			orderManagmentServiceMock
				.Setup(x => x.Create(It.Is<OrderModel>(order => order.Id == order1.Id)))
				.Returns<OrderModel>((order) => {
					return order;
				})
				.Verifiable();

			testable.ModelState.Clear();
			var result = testable.Post(order1);
			Assert.That(result, Is.EqualTo(order1));
			orderManagmentServiceMock.VerifyAll();
		}

		[Test]
		public void Post_ModelStateHasErrors_ThrowsValidationException() {
			testable.ModelState.AddModelError("orderModel.Date", "Value for Date must be between 01.01.2010 0:00:00 and 01.01.2029 0:00:00");
			Assert.Throws<ValidationException>(() => testable.Post(order1));
		}
		#endregion

		#region Put
		[Test]
		public void Put_Test() {
			orderManagmentServiceMock
				.Setup(x => x.Edit(It.Is<OrderModel>(order => order.Id == order1.Id)))
				.Returns<OrderModel>((order) => {
					return order;
				})
				.Verifiable();

			testable.ModelState.Clear();
			var result = testable.Put(order1.Id, order1);
			Assert.That(result, Is.EqualTo(order1));
			orderManagmentServiceMock.VerifyAll();
		}
		[Test]
		public void Put_Replace_Id_In_Model() {
			orderManagmentServiceMock
				.Setup(x => x.Edit(It.Is<OrderModel>(order => order.Id == 1234)))
				.Returns<OrderModel>((order) => {
					return order;
				})
				.Verifiable();

			testable.ModelState.Clear();
			var result = testable.Put(1234, new OrderModel() { Id = 0 });
			Assert.That(result.Id, Is.EqualTo(1234));
			orderManagmentServiceMock.VerifyAll();
		}

		[Test]
		public void Put_ModelStateHasErrors_ThrowsValidationException() {
			testable.ModelState.AddModelError("orderModel.Date", "Value for Date must be between 01.01.2010 0:00:00 and 01.01.2029 0:00:00");
			Assert.Throws<ValidationException>(() => testable.Put(19, order1));
		}
		#endregion


		#region Post
		[Test]
		public void Delete() {
			orderManagmentServiceMock
				.Setup(x => x.Delete(It.Is<int>(id => id == order2.Id)))
				.Verifiable();

			testable.Delete(order2.Id);
			orderManagmentServiceMock.VerifyAll();
		}
		#endregion

	}
}
