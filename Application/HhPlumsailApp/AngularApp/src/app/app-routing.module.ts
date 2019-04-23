import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { EditOrderComponent } from './orders/edit-order/edit-order.component';
import { ListOrdersComponent } from './orders/list-orders/list-orders.component';
import { LoginComponent } from './authentification/login/login.component';

const routes: Routes = [
	{ path: 'login', component: LoginComponent },
	{ path: 'orders/order/:id', component: EditOrderComponent },
	{ path: 'orders/order', component: EditOrderComponent },
	{ path: 'orders', component: ListOrdersComponent },    
	{ path: '**', redirectTo: '/orders'}
];

@NgModule({
	imports: [RouterModule.forRoot(routes)],
	exports: [RouterModule]
})
export class AppRoutingModule { }
