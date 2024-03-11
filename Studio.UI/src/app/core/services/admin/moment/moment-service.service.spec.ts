import { TestBed } from '@angular/core/testing';

import { MomentServiceService } from './moment-service.service';

describe('MomentServiceService', () => {
  let service: MomentServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(MomentServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
