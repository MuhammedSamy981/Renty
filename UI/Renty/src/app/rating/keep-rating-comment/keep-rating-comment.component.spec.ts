import { ComponentFixture, TestBed } from '@angular/core/testing';

import { KeepRatingCommentComponent } from './keep-rating-comment.component';

describe('KeepRatingCommentComponent', () => {
  let component: KeepRatingCommentComponent;
  let fixture: ComponentFixture<KeepRatingCommentComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [KeepRatingCommentComponent]
    });
    fixture = TestBed.createComponent(KeepRatingCommentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
