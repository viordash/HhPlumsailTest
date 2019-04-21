using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using HhPlumsailApp.Exceptions;
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

		public CustomerModel Create(CustomerModel customer) {
			AssertCustomerModel(customer);
			if(internalStorage.Any(x => x.Id == customer.Id)) {
				throw new DuplicateRecordException();
			}
			internalStorage.Add(customer);
			return customer;
		}

		public void Delete(int customerId) {
			var customer = Retrieve(customerId);
			internalStorage.Remove(customer);
		}

		public CustomerModel Edit(CustomerModel customer) {
			AssertCustomerModel(customer);
			Delete(customer.Id);
			return Create(customer);
		}

		public List<CustomerModel> List() {
			//Thread.Sleep(2000);
			return internalStorage.OrderBy(x => x.Id).ToList();
		}

		public CustomerModel Retrieve(int customerId) {
			var customer = internalStorage.Where(x => x.Id == customerId).FirstOrDefault();
			if(customer == null) {
				throw new ObjectNotFoundException();
			}
			return customer;
		}

		void AssertCustomerModel(CustomerModel customer) {
			var exception = new ValidationException();
			if(customer == null) {
				exception.Data.Add(nameof(customer), "The empty customer");
			}

			if(exception.Data.Count > 0) {
				throw exception;
			}
		}
	}
}