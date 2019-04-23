/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { ErrorHandlerService } from './error-handler.service';
import { RouterTestingModule } from '@angular/router/testing';

describe('Service: ErrorHandler', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [
        RouterTestingModule,
      ],
      providers: [ErrorHandlerService]
    });
  });

  it('should ...', inject([ErrorHandlerService], (service: ErrorHandlerService) => {
    expect(service).toBeTruthy();
  }));
});
