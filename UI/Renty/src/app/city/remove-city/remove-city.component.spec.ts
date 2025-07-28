import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RemoveCityComponent } from './remove-city.component';

describe('RemoveCityComponent', () => {
  let component: RemoveCityComponent;
  let fixture: ComponentFixture<RemoveCityComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [RemoveCityComponent]
    });
    fixture = TestBed.createComponent(RemoveCityComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
