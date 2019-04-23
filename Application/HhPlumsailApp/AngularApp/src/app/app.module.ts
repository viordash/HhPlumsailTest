import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { NgBootstrapFormValidationModule } from 'ng-bootstrap-form-validation';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { OrdersModule } from './orders/orders.module';
import { HttpClientService } from './services/http-client.service';
import { ErrorHandlerService } from './services/error-handler.service';
import { ToastNotificationService } from './services/toast-notification.service';
import { AuthentificationModule } from './authentification/authentification.module';
import { AuthentificationService } from './services/authentification.service';

@NgModule({
   declarations: [
      AppComponent,
      NavMenuComponent,
   ],
   imports: [
      FormsModule,
      BrowserModule,
      AppRoutingModule,
      NgbModule,
      OrdersModule,
      NgBootstrapFormValidationModule.forRoot(),
      AuthentificationModule
   ],
   bootstrap: [
      AppComponent
   ],
   providers: [HttpClientService, ErrorHandlerService, ToastNotificationService, AuthentificationService],
})
export class AppModule { }
