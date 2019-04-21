import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { OrderModel } from './orders/orderModel';
import { Observable, of } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class MockHttpClientService {
    orders: OrderModel[] = [
        { id: 1, date: 123456, customer: "customer1", status: null, prepaid: true, summ: 123.456, description: "description1" },
        { id: 2, date: 7890123, customer: "customer2", status: null, prepaid: true, summ: 78.901, description: "description2" },
    ];

    constructor() { }

    public getOrders(): Observable<OrderModel[]> {
        return of(this.orders);
    }

}