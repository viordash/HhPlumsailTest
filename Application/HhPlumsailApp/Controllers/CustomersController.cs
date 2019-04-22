using System.Collections.Generic;
using System.Web.Http;
using GuardNet;
using HhPlumsailApp.Models;
using HhPlumsailApp.Services;

namespace HhPlumsailApp.Controllers {
	//[Authorize]
	public class CustomersController : ApiController {
		readonly ICustomerManagmentService customerManagmentService;

		public CustomersController(ICustomerManagmentService customerManagmentService) {
			Guard.NotNull(customerManagmentService, nameof(customerManagmentService));
			this.customerManagmentService = customerManagmentService;
		}

		// GET api/Customers
		public IEnumerable<CustomerModel> Get() {
			return customerManagmentService.List();
		}
	}
}