import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProductsSupervisionComponent } from './products-supervision.component';

describe('ProductsSupervisionComponent', () => {
  let component: ProductsSupervisionComponent;
  let fixture: ComponentFixture<ProductsSupervisionComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ProductsSupervisionComponent]
    });
    fixture = TestBed.createComponent(ProductsSupervisionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
