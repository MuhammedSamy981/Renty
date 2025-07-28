import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StarsRatingsComponent } from './stars-ratings.component';

describe('StarsRatingsComponent', () => {
  let component: StarsRatingsComponent;
  let fixture: ComponentFixture<StarsRatingsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [StarsRatingsComponent]
    });
    fixture = TestBed.createComponent(StarsRatingsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
