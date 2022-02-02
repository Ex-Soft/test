import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TestNgxEditorComponent } from './test-ngx-editor.component';

describe('TestNgxEditorComponent', () => {
  let component: TestNgxEditorComponent;
  let fixture: ComponentFixture<TestNgxEditorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TestNgxEditorComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TestNgxEditorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
