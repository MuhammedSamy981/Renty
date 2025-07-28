import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AreasManagementComponent } from './areas-management.component';

describe('AreasManagementComponent', () => {
  let component: AreasManagementComponent;
  let fixture: ComponentFixture<AreasManagementComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AreasManagementComponent]
    });
    fixture = TestBed.createComponent(AreasManagementComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
