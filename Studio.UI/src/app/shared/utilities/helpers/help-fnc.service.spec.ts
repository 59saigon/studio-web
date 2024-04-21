import { TestBed } from '@angular/core/testing';

import { HelpFncService } from './help-fnc.service';

describe('HelpFncService', () => {
  let service: HelpFncService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(HelpFncService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
