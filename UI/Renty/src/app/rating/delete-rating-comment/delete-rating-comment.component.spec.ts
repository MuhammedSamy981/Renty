import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DeleteRatingCommentComponent } from './delete-rating-comment.component';

describe('DeleteRatingCommentComponent', () => {
  let component: DeleteRatingCommentComponent;
  let fixture: ComponentFixture<DeleteRatingCommentComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [DeleteRatingCommentComponent]
    });
    fixture = TestBed.createComponent(DeleteRatingCommentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
