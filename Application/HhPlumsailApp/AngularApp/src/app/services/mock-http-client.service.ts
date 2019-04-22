import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { OrderModel } from '../orders/orderModel';
import { Observable, of } from 'rxjs';
import { CustomerModel } from '../customers/CustomerModel';

@Injectable({
    providedIn: 'root'
})
export class MockHttpClientService {
    orders: OrderModel[] = [
        { id: 1, date: new Date(), customer: "customer1", status: null, prepaid: true, summ: 123.456, description: "description1" },
        { id: 2, date: new Date(), customer: "customer2", status: null, prepaid: true, summ: 78.901, description: "description2" },
    ];
    customers: CustomerModel[] = [
        { id: 1, name: "customer1" },
        { id: 2, name: "customer2" },
    ];

    constructor() { }

    public getOrders(): Observable<OrderModel[]> {
        return of(this.orders);
    }

    public getCustomers(): Observable<CustomerModel[]> {
        return of(this.customers);
    }
}