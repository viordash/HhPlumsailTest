/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { EditOrderComponent } from './edit-order.component';
import { HttpClientService } from 'src/app/services/http-client.service';
import { MockHttpClientService } from 'src/app/services/mock-http-client.service';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgbModalModule, NgbActiveModal, NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { RouterTestingModule } from '@angular/router/testing';


describe('EditOrderComponent', () => {
  let component: EditOrderComponent;
  let fixture: ComponentFixture<EditOrderComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [
        FormsModule,
        NgbModalModule,
        RouterTestingModule,
        NgbModule,
        ReactiveFormsModule
      ],
      declarations: [EditOrderComponent],
      providers: [{ provide: HttpClientService, useClass: MockHttpClientService },
        NgbActiveModal],
    })
      .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EditOrderComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
