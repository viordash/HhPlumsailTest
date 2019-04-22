using System.Collections.Generic;
using HhPlumsailApp.Models;

namespace HhPlumsailApp.Services {
	public interface ICustomerManagmentService {
		List<CustomerModel> List();
	}
}