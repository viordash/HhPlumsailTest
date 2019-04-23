using System.Collections.Generic;
using System.Web.Http;
using GuardNet;
using HhPlumsailApp.Extensions;
using HhPlumsailApp.Models;
using HhPlumsailApp.Services;

namespace HhPlumsailApp.Controllers {
	[Authorize]
	public class OrdersController : ApiController {
		readonly IOrderManagmentService orderManagmentService;

		public OrdersController(IOrderManagmentService orderManagmentService) {
			Guard.NotNull(orderManagmentService, nameof(orderManagmentService));
			this.orderManagmentService = orderManagmentService;
		}

		// GET api/Orders
		public IEnumerable<OrderModel> Get() {
			return orderManagmentService.List();
		}

		// GET api/Orders/5
		public OrderModel Get(int id) {
			return orderManagmentService.Retrieve(id);
		}

		// POST api/Orders
		public void Post([FromBody]OrderModel orderModel) {
			ModelState.Validate();
			orderManagmentService.Create(orderModel);
		}

		// PUT api/Orders/5
		public void Put(int id, [FromBody]OrderModel orderModel) {
			ModelState.Validate();
			orderModel.Id = id;
			orderManagmentService.Edit(orderModel);
		}

		// DELETE api/Orders/5
		public void Delete(int id) {
			orderManagmentService.Delete(id);
		}
	}
}