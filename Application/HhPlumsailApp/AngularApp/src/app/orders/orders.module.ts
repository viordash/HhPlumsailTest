
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from '../app-routing.module';

import { EditOrderComponent } from './edit-order/edit-order.component';
import { ListOrdersComponent } from './list-orders/list-orders.component';
import { EditorsModule } from '../editors/editors.module';
import { HttpClientService } from '../http-client.service';


@NgModule({
    imports: [
        FormsModule,
        BrowserModule,
        AppRoutingModule,
        HttpClientModule,
        EditorsModule
    ],
    providers: [HttpClientService],
    declarations: [
        EditOrderComponent,
        ListOrdersComponent],
    exports: [
        EditOrderComponent,
        ListOrdersComponent
    ]
})
export class OrdersModule { }
