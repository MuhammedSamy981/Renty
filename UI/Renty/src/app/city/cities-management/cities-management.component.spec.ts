import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CitiesManagementComponent } from './cities-management.component';

describe('CitiesManagementComponent', () => {
  let component: CitiesManagementComponent;
  let fixture: ComponentFixture<CitiesManagementComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CitiesManagementComponent]
    });
    fixture = TestBed.createComponent(CitiesManagementComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
