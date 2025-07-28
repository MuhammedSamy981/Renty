import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RemoveCountryComponent } from './remove-country.component';

describe('RemoveCountryComponent', () => {
  let component: RemoveCountryComponent;
  let fixture: ComponentFixture<RemoveCountryComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [RemoveCountryComponent]
    });
    fixture = TestBed.createComponent(RemoveCountryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
