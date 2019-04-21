using System.Collections.Generic;
using HhPlumsailApp.Models;

namespace HhPlumsailApp.Services {
	public interface ICustomerManagmentService {
		List<CustomerModel> List();
		CustomerModel Retrieve(int customerId);
		CustomerModel Create(CustomerModel customer);
		CustomerModel Edit(CustomerModel customer);
		void Delete(int orderId);
	}
}