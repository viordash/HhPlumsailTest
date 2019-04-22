import { TestBed, async } from '@angular/core/testing';
import { RouterTestingModule } from '@angular/router/testing';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HttpClientService } from './services/http-client.service';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { OrdersModule } from './orders/orders.module';
import { SignupComponent } from './signup/signup.component';
import { FormsModule } from '@angular/forms';
import { EditorsModule } from './editors/editors.module';

describe('AppComponent', () => {
  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [
        RouterTestingModule,
        FormsModule,
        NgbModule,
        OrdersModule,
        EditorsModule
      ],
      declarations: [
        AppComponent,
        SignupComponent,
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
