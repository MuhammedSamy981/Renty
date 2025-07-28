import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddRatingComponent } from './add-rating.component';

describe('AddRatingComponent', () => {
  let component: AddRatingComponent;
  let fixture: ComponentFixture<AddRatingComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AddRatingComponent]
    });
    fixture = TestBed.createComponent(AddRatingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
