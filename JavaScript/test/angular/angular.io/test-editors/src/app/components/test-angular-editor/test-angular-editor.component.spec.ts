import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TestAngularEditorComponent } from './test-angular-editor.component';

describe('TestAngularEditorComponent', () => {
  let component: TestAngularEditorComponent;
  let fixture: ComponentFixture<TestAngularEditorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TestAngularEditorComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TestAngularEditorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
