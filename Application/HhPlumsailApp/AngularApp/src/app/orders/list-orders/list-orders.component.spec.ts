/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { ListOrdersComponent } from './list-orders.component';
import { MockHttpClientService } from 'src/app/services/mock-http-client.service';
import { HttpClientService } from 'src/app/services/http-client.service';
import { OrderStatusPipe } from 'src/app/pipes/order-status.pipe';

describe('ListOrdersComponent', () => {
  let component: ListOrdersComponent;
  let fixture: ComponentFixture<ListOrdersComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ListOrdersComponent, OrderStatusPipe],
      providers: [{ provide: HttpClientService, useClass: MockHttpClientService }],
    })
      .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ListOrdersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
