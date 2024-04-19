import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WeddingManagementComponent } from './wedding-management.component';

describe('WeddingManagementComponent', () => {
  let component: WeddingManagementComponent;
  let fixture: ComponentFixture<WeddingManagementComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ WeddingManagementComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(WeddingManagementComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
