import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ReviewRatingsCommentsComponent } from './review-ratings-comments.component';

describe('ReviewRatingsCommentsComponent', () => {
  let component: ReviewRatingsCommentsComponent;
  let fixture: ComponentFixture<ReviewRatingsCommentsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ReviewRatingsCommentsComponent]
    });
    fixture = TestBed.createComponent(ReviewRatingsCommentsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
