import { Pipe, PipeTransform } from '@angular/core';
import { OrderStatus } from '../orders/orderModel';

@Pipe({
	name: 'DisplayOrderStatus'
})
export class OrderStatusPipe implements PipeTransform {

	transform(value: any, args?: any): any {
		switch (value) {
			case OrderStatus.Created:
				return "Created";
			case OrderStatus.InProcess:
				return "In process";
			case OrderStatus.Closed:
				return "Closed";
			default:
				return "";
		}
	}
}
