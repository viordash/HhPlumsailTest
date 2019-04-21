import { TestBed, async } from '@angular/core/testing';
import { RouterTestingModule } from '@angular/router/testing';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { EditOrderComponent } from './orders/edit-order/edit-order.component';
import { ListOrdersComponent } from './orders/list-orders/list-orders.component';
import { HttpClientModule } from '@angular/common/http/src/module';
import { HttpClientService } from './http-client.service';

describe('AppComponent', () => {
  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [
        RouterTestingModule
      ],
      declarations: [
        AppComponent,
        NavMenuComponent,
        EditOrderComponent,
        ListOrdersComponent
      ],
      providers: [HttpClientService],
    }).compileComponents();
  }));

  it('should create the app', () => {
    const fixture = TestBed.createComponent(AppComponent);
    const app = fixture.debugElement.componentInstance;
    expect(app).toBeTruthy();
  });
});
