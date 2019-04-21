import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { OrderModel } from './orders/orderModel';
import { Observable, Subject } from 'rxjs';

@Injectable({
	providedIn: 'root'
})
export class HttpClientService {

	constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }


	public getOrders(): Observable<OrderModel[]> {
		var subject = new Subject<OrderModel[]>()
		this.http.get<OrderModel[]>(this.baseUrl + 'api/Orders')
			.subscribe(result => {
				subject.next(result);
			}, error => {
				console.error(error);
			});
		return subject.asObservable();
	}

	// getOrders(): Observable<OrderModel[]> {
	// 	return this.http.get<OrderModel[]>(this.baseUrl + 'api/Orders')
	// 		.subscribe(result => {
	// 			return result;
	// 		}, error => console.error(error));
	// }

}
