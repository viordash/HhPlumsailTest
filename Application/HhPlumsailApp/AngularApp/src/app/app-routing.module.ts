import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SignupComponent } from './signup/signup.component';
import { EditOrderComponent } from './orders/edit-order/edit-order.component';
import { ListOrdersComponent } from './orders/list-orders/list-orders.component';

const routes: Routes = [
  { path: 'signup', component: SignupComponent },
  { path: 'edit-order', component: EditOrderComponent },
  { path: 'orders', component: ListOrdersComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
