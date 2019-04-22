import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SignupComponent } from './signup/signup.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { EditOrderComponent } from './orders/edit-order/edit-order.component';
import { HttpClientService } from './http-client.service';
import { ListOrdersComponent } from './orders/list-orders/list-orders.component';
import { NgbdDatepickerPopupModule } from './editors/datepicker-popup.module';

@NgModule({
   declarations: [
      AppComponent,
      SignupComponent,
      NavMenuComponent,
      EditOrderComponent,
      ListOrdersComponent
   ],
   imports: [
      FormsModule,
      BrowserModule,
      AppRoutingModule,
      HttpClientModule,
      NgbdDatepickerPopupModule
   ],
   providers: [HttpClientService],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
