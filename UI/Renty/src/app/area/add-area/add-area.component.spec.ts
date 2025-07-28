import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddAreaComponent } from './add-area.component';

describe('AddAreaComponent', () => {
  let component: AddAreaComponent;
  let fixture: ComponentFixture<AddAreaComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AddAreaComponent]
    });
    fixture = TestBed.createComponent(AddAreaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
