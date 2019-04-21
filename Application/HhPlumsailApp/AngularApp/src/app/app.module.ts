import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SignupComponent } from './signup/signup.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { EditOrderComponent } from './orders/edit-order/edit-order.component';
import { HttpClientService } from './http-client.service';

@NgModule({
   declarations: [
      AppComponent,
      SignupComponent,
      NavMenuComponent,
      EditOrderComponent
   ],
   imports: [
      BrowserModule,
      AppRoutingModule,
      HttpClientModule
   ],
   providers: [HttpClientService],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
