import { TestBed, async } from '@angular/core/testing';
import { RouterTestingModule } from '@angular/router/testing';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HttpClientService } from './services/http-client.service';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { OrdersModule } from './orders/orders.module';
import { FormsModule } from '@angular/forms';
import { AuthentificationModule } from './authentification/authentification.module';

describe('AppComponent', () => {
  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [
        RouterTestingModule,
        FormsModule,
        NgbModule,
        OrdersModule,
        AuthentificationModule
      ],
      declarations: [
        AppComponent,
        NavMenuComponent
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
