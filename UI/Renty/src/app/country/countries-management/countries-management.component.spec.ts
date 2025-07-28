import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CountriesManagementComponent } from './countries-management.component';

describe('CountriesManagementComponent', () => {
  let component: CountriesManagementComponent;
  let fixture: ComponentFixture<CountriesManagementComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CountriesManagementComponent]
    });
    fixture = TestBed.createComponent(CountriesManagementComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
