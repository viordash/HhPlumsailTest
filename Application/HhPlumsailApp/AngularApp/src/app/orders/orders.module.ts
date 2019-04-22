
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from '../app-routing.module';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { EditOrderComponent } from './edit-order/edit-order.component';
import { ListOrdersComponent } from './list-orders/list-orders.component';
import { EditorsModule } from '../editors/editors.module';
import { HttpClientService } from '../services/http-client.service';
import { OrderStatusPipe } from '../pipes/order-status.pipe';


@NgModule({
    imports: [
        FormsModule,
        BrowserModule,
        AppRoutingModule,
        HttpClientModule,
        EditorsModule,
        NgbModule
    ],
    providers: [HttpClientService],
    declarations: [
        EditOrderComponent,
        ListOrdersComponent,
        OrderStatusPipe],
    exports: [
        EditOrderComponent,
        ListOrdersComponent
    ]
})
export class OrdersModule { }
