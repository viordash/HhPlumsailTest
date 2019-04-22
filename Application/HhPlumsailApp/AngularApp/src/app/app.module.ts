import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SignupComponent } from './signup/signup.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { OrdersModule } from './orders/orders.module';
import { HttpClientService } from './services/http-client.service';
import { ErrorHandlerService } from './services/error-handler.service';

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
   ],
   providers: [HttpClientService, ErrorHandlerService],
})
export class AppModule { }
