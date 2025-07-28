import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RefuseProductComponent } from './refuse-product.component';

describe('RefuseProductComponent', () => {
  let component: RefuseProductComponent;
  let fixture: ComponentFixture<RefuseProductComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [RefuseProductComponent]
    });
    fixture = TestBed.createComponent(RefuseProductComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
