using System.Collections.Generic;
using System.Web.Http;
using GuardNet;
using HhPlumsailApp.Extensions;
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

		// GET api/Customers/5
		public CustomerModel Get(int id) {
			return customerManagmentService.Retrieve(id);
		}

		// POST api/Customers
		public CustomerModel Post([FromBody]CustomerModel customerModel) {
			ModelState.Validate();
			return customerManagmentService.Create(customerModel);
		}

		// PUT api/Customers/5
		public CustomerModel Put(int id, [FromBody]CustomerModel customerModel) {
			ModelState.Validate();
			customerModel.Id = id;
			return customerManagmentService.Edit(customerModel);
		}

		// DELETE api/Customers/5
		public void Delete(int id) {
			customerManagmentService.Delete(id);
		}
	}
}