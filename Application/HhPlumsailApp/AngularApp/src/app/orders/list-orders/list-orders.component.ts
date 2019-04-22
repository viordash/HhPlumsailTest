import { Component, OnInit } from '@angular/core';
import { HttpClientService } from 'src/app/http-client.service';
import { OrderModel } from '../orderModel';
import { NgbModal, NgbModalOptions } from '@ng-bootstrap/ng-bootstrap';
import { EditOrderComponent } from '../edit-order/edit-order.component';

@Component({
	selector: 'app-list-orders',
	templateUrl: './list-orders.component.html',
	styleUrls: ['./list-orders.component.scss']
})
export class ListOrdersComponent implements OnInit {
	private orders: OrderModel[];

	constructor(private httpClientService: HttpClientService, private modalService: NgbModal) { }

	ngOnInit() {
		this.loadOrders();
	}

	loadOrders() {
		this.httpClientService.getOrders()
			.subscribe(result => {
				this.orders = result;
			});
	}

	editItem(orderId: number) {
		const config: NgbModalOptions = {
			backdrop: 'static',
			keyboard: false,
			// size: 'lg'
		}
		const modalRef = this.modalService.open(EditOrderComponent, config);
		modalRef.componentInstance.orderId = orderId;
		modalRef.result.then((value) => {
			if (!!value) {
				this.loadOrders();
			}
		});
	}

}
