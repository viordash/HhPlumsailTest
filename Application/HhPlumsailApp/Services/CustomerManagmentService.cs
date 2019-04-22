using System.Collections.Generic;
using System.Linq;
using HhPlumsailApp.Models;

namespace HhPlumsailApp.Services {
	public class CustomerManagmentService : ICustomerManagmentService {
		readonly List<CustomerModel> internalStorage;

		public CustomerManagmentService() {
			internalStorage = new List<CustomerModel>() {
				new CustomerModel() { Id = 0, Name = "Customer1" },
				new CustomerModel() { Id = 1, Name = "Customer2" },
				new CustomerModel() { Id = 2, Name = "Customer3" },
				new CustomerModel() { Id = 3, Name = "Customer4" },
				new CustomerModel() { Id = 4, Name = "Customer5" }
			};
		}

		public List<CustomerModel> List() {
			//Thread.Sleep(2000);
			return internalStorage.OrderBy(x => x.Id).ToList();
		}
	}
}