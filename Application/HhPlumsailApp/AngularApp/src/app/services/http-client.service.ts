import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';
import { OrderModel } from '../orders/orderModel';
import { Observable, Subject } from 'rxjs';
import { CustomerModel } from '../customers/CustomerModel';
import { ErrorHandlerService } from './error-handler.service';
import { UserModel } from '../authentification/userModel';
import { AuthentificationService } from './authentification.service';
import { AuthTokenModel } from '../authentification/authTokenModel';

@Injectable({
	providedIn: 'root'
})
export class HttpClientService {

	constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string,
		private errorHandler: ErrorHandlerService, private authentification: AuthentificationService, ) { }

	public getOrders(): Observable<OrderModel[]> {
		var subject = new Subject<OrderModel[]>()
		this.http.get<OrderModel[]>(this.baseUrl + 'api/Orders')
			.subscribe(result => {
				subject.next(result);
			}, error => {
				this.errorHandler.show(error);
			});
		return subject.asObservable();
	}

	public getOrder(orderId: number): Observable<OrderModel> {
		var subject = new Subject<OrderModel>()
		this.http.get<OrderModel>(this.baseUrl + 'api/Orders/' + orderId)
			.subscribe(result => {
				subject.next(result);
			}, error => {
				this.errorHandler.show(error);
			});
		return subject.asObservable();
	}

	public createOrder(order: OrderModel): Observable<OrderModel> {
		var subject = new Subject<OrderModel>()
		this.http.post<OrderModel>(this.baseUrl + 'api/Orders', order)
			.subscribe(result => {
				subject.next(result);
			}, error => {
				this.errorHandler.show(error);
			});
		return subject.asObservable();
	}

	public saveOrder(orderId: number, order: OrderModel): Observable<OrderModel> {
		var subject = new Subject<OrderModel>()
		this.http.put<OrderModel>(this.baseUrl + 'api/Orders/' + orderId, order)
			.subscribe(result => {
				subject.next(result);
			}, error => {
				this.errorHandler.show(error);
			});
		return subject.asObservable();
	}


	public getCustomers(): Observable<CustomerModel[]> {
		var subject = new Subject<CustomerModel[]>()
		this.http.get<CustomerModel[]>(this.baseUrl + 'api/Customers')
			.subscribe(result => {
				subject.next(result);
			}, error => {
				this.errorHandler.show(error);
			});
		return subject.asObservable();
	}

	public login(user: UserModel): void {
		const body = new HttpParams()
			.set('grant_type', 'password')
			.set('UserName', user.userName)
			.set('Password', user.password);

		this.http.post(this.baseUrl + 'token',
			body.toString(),
			{
				headers: new HttpHeaders()
					.set('Content-Type', 'application/x-www-form-urlencoded')
			}
		).subscribe(result => {
			this.authentification.acceptToken(result as AuthTokenModel);
		}, error => {
			this.errorHandler.show(error);
		});
	}

	public signUp(user: UserModel): Observable<any> {
		var subject = new Subject<any>()
		this.http.post<any>(this.baseUrl + '/api/account/register', user)
			.subscribe(result => {
				subject.next(result);
			}, error => {
				this.errorHandler.show(error);
			});
		return subject.asObservable();
	}
}
