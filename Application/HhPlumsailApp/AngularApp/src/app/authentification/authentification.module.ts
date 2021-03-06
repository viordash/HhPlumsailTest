
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from '../app-routing.module';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { NgBootstrapFormValidationModule } from 'ng-bootstrap-form-validation';

import { LoginComponent } from './login/login.component';


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
		LoginComponent],
	exports: [
		LoginComponent
	],
})
export class AuthentificationModule { }
