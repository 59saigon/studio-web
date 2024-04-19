import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WeddingCreateComponent } from './wedding-create.component';

describe('WeddingCreateComponent', () => {
  let component: WeddingCreateComponent;
  let fixture: ComponentFixture<WeddingCreateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ WeddingCreateComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(WeddingCreateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
