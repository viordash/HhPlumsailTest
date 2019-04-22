import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SignupComponent } from './signup/signup.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { OrdersModule } from './orders/orders.module';

@NgModule({
   declarations: [
      AppComponent,
      SignupComponent,
      NavMenuComponent,
   ],
   imports: [
      FormsModule,
      BrowserModule,
      AppRoutingModule,
      OrdersModule
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
