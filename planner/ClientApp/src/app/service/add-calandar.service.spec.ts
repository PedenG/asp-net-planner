import { TestBed, inject } from '@angular/core/testing';

import { AddCalandarService } from './add-calandar.service';

describe('AddCalandarService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [AddCalandarService]
    });
  });

  it('should be created', inject([AddCalandarService], (service: AddCalandarService) => {
    expect(service).toBeTruthy();
  }));
});
