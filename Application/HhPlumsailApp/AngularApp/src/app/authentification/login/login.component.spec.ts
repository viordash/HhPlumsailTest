/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { LoginComponent } from './login.component';
import { FormsModule, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { NgbModalModule, NgbModule, NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { RouterTestingModule } from '@angular/router/testing';
import { HttpClientService } from 'src/app/services/http-client.service';
import { MockHttpClientService } from 'src/app/services/mock-http-client.service';

describe('LoginComponent', () => {
  let component: LoginComponent;
  let fixture: ComponentFixture<LoginComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [
        FormsModule,
        NgbModalModule,
        RouterTestingModule,
        NgbModule,
        ReactiveFormsModule
      ],
      declarations: [ LoginComponent ],
      providers: [{ provide: HttpClientService, useClass: MockHttpClientService },
        NgbActiveModal],
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LoginComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
