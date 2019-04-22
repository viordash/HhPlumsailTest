import { Component, OnInit, Input } from '@angular/core';

import { HttpClientService } from 'src/app/http-client.service';
import { Router } from '@angular/router';
import { OrderModel } from '../orderModel';
import { CustomerModel } from 'src/app/customers/CustomerModel';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
	selector: 'app-edit-order',
	templateUrl: './edit-order.component.html',
	styleUrls: ['./edit-order.component.scss']
})
export class EditOrderComponent implements OnInit {
	@Input() orderId: number;
	order: OrderModel;
	customers: CustomerModel[];

	private get isNew(): boolean {
		return this.orderId == null;
	}
	get title(): string {
		return this.isNew ? "Create new order" : "Edit order"
	}

	constructor(private httpClientService: HttpClientService, public activeModal: NgbActiveModal, private router: Router) { }

	ngOnInit() {
		if (this.orderId != null) {
			this.httpClientService.getOrder(this.orderId)
				.subscribe(result => {
					this.order = result;
				});
		} else {
			this.order = {} as OrderModel;
		}

		this.httpClientService.getCustomers()
			.subscribe(result => {
				this.customers = result;
			});
	}

	saveOrder() {
		if (this.isNew) {
			this.httpClientService.createOrder(this.order)
				.subscribe(result => {
					this.activeModal.close(true);
					this.router.navigate(['/orders'])
				});
		} else {
			this.httpClientService.saveOrder(this.orderId, this.order)
				.subscribe(result => {
					this.activeModal.close(true);
					this.router.navigate(['/orders'])
				});
		}
	}
}
