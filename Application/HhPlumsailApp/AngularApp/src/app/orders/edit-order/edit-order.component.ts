import { Component, OnInit, Input } from '@angular/core';

import { HttpClientService } from 'src/app/services/http-client.service';
import { Router } from '@angular/router';
import { OrderModel } from '../orderModel';
import { CustomerModel } from 'src/app/customers/CustomerModel';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import { Observable, of } from 'rxjs';
import { tap, map } from 'rxjs/operators';
import { NgbDate } from '@ng-bootstrap/ng-bootstrap';

@Component({
	selector: 'app-edit-order',
	templateUrl: './edit-order.component.html',
	styleUrls: ['./edit-order.component.scss']
})
export class EditOrderComponent implements OnInit {
	formGroup: FormGroup;
	@Input() orderId: number;
	customers: CustomerModel[];
	order: Observable<OrderModel>;

	private get isNew(): boolean {
		return this.orderId == null;
	}
	get title(): string {
		return this.isNew ? "Create new order" : "Edit order"
	}

	constructor(private httpClientService: HttpClientService, public activeModal: NgbActiveModal, private router: Router,
		private formBuilder: FormBuilder) {
	}

	ngOnInit() {
		this.formGroup = this.formBuilder.group({
			date: ['', Validators.required],
			customer: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(16)]],
			status: ['', Validators.required],
			prepaid: [],
			summ: ['', Validators.required],
			description: []
		});

		if (this.orderId != null) {
			this.order = this.httpClientService.getOrder(this.orderId).pipe(
				tap(order => this.formGroup.patchValue({
					id: order.id,
					date: this.date2NgbDate(order.date),
					customer: order.customer,
					status: order.status,
					prepaid: order.prepaid,
					summ: order.summ,
					description: order.description

				}))
			);
		} else {
			this.order = of({} as OrderModel);
		}

		this.httpClientService.getCustomers()
			.subscribe(result => {
				this.customers = result;
			});
	}

	date2NgbDate(date: Date): NgbDate {
		const _date = new Date(date);
		return new NgbDate(_date.getFullYear(), _date.getMonth() + 1, _date.getDate());
	}

	ngbDate2Date(date: NgbDate): Date {
		const _date = new Date(date.year, date.month - 1, date.day);
		return _date;
	}

	saveOrder() {
		const formValue = this.formGroup.value;
		const order: OrderModel = {
			id: formValue.id,
			date: this.ngbDate2Date(formValue.date),
			customer: formValue.customer,
			status: formValue.status,
			prepaid: !!formValue.prepaid,
			summ: formValue.summ,
			description: formValue.description
		}

		if (this.isNew) {
			this.httpClientService.createOrder(order)
				.subscribe(result => {
					this.activeModal.close(true);
					this.router.navigate(['/orders'])
				});
		} else {
			this.httpClientService.saveOrder(this.orderId, order)
				.subscribe(result => {
					this.activeModal.close(true);
					this.router.navigate(['/orders'])
				});
		}
	}

}
