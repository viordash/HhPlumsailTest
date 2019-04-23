
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from '../app-routing.module';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { NgBootstrapFormValidationModule } from 'ng-bootstrap-form-validation';

import { EditOrderComponent } from './edit-order/edit-order.component';
import { ListOrdersComponent } from './list-orders/list-orders.component';
import { OrderStatusPipe } from '../pipes/order-status.pipe';


@NgModule({
    imports: [
        FormsModule,
        BrowserModule,
        AppRoutingModule,
        HttpClientModule,
        NgBootstrapFormValidationModule,
        ReactiveFormsModule,
        NgbModule,
    ],
    declarations: [
        EditOrderComponent,
        ListOrdersComponent,
        OrderStatusPipe],
    exports: [
        EditOrderComponent,
        ListOrdersComponent
    ],
    bootstrap: [EditOrderComponent]
})
export class OrdersModule { }
