import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StudentbyidComponent } from './studentbyid.component';

describe('StudentbyidComponent', () => {
  let component: StudentbyidComponent;
  let fixture: ComponentFixture<StudentbyidComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [StudentbyidComponent]
    });
    fixture = TestBed.createComponent(StudentbyidComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
