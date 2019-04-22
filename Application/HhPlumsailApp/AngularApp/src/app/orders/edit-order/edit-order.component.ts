import { Component, OnInit } from '@angular/core';

import { HttpClientService } from 'src/app/http-client.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs/internal/Subscription';
import { OrderModel } from '../orderModel';
import { CustomerModel } from 'src/app/customers/CustomerModel';

@Component({
	selector: 'app-edit-order',
	templateUrl: './edit-order.component.html',
	styleUrls: ['./edit-order.component.scss']
})
export class EditOrderComponent implements OnInit {
	private id?: number;
	private subscription: Subscription;
	private order: OrderModel;
	private customers: CustomerModel[];

	private get isNew(): boolean {
		return !!!this.id;
	}

	constructor(private activateRoute: ActivatedRoute, private httpClientService: HttpClientService, private router: Router) {
		this.subscription = activateRoute.params.subscribe(params => {
			this.id = params['id'];
			if (this.id) {
				this.httpClientService.getOrder(this.id)
					.subscribe(result => {
						this.order = result;
					});
			} else {
				this.order = {} as OrderModel;
			}
		});

	}

	ngOnInit() {
		this.httpClientService.getCustomers()
			.subscribe(result => {
				this.customers = result;
			});
	}

	saveOrder() {
		if (!confirm(this.isNew ? "Create order?" : "Save order?")) {
			return;
		}
		if (this.isNew) {
			this.httpClientService.createOrder(this.order)
				.subscribe(result => {
					this.router.navigate(['/orders'])
				});
		} else {
			this.httpClientService.saveOrder(this.id, this.order)
				.subscribe(result => {
					this.router.navigate(['/orders'])
				});
		}
	}
}
