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

	public getOrder(orderId: number): Observable<OrderModel> {
		var subject = new Subject<OrderModel>()
		this.http.get<OrderModel>(this.baseUrl + 'api/Orders/' + orderId)
			.subscribe(result => {
				subject.next(result);
			}, error => {
				console.error(error);
			});
		return subject.asObservable();
	}

	public createOrder(order: OrderModel): Observable<OrderModel> {
		var subject = new Subject<OrderModel>()
		this.http.post<OrderModel>(this.baseUrl + 'api/Orders', order)
			.subscribe(result => {
				subject.next(result);
			}, error => {
				console.error(error);
			});
		return subject.asObservable();
	}

	public saveOrder(orderId: number, order: OrderModel): Observable<OrderModel> {
		var subject = new Subject<OrderModel>()
		this.http.put<OrderModel>(this.baseUrl + 'api/Orders/' + orderId, order)
			.subscribe(result => {
				subject.next(result);
			}, error => {
				console.error(error);
			});
		return subject.asObservable();
	}
}
