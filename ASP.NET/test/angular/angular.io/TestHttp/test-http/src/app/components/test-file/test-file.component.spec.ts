import { ComponentFixture, TestBed } from '@angular/core/testing';
import { HttpClientTestingModule } from '@angular/common/http/testing';

import { TestFileComponent } from './test-file.component';

describe('TestFileComponent', () => {
  let component: TestFileComponent;
  let fixture: ComponentFixture<TestFileComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TestFileComponent ],
      imports: [ HttpClientTestingModule ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TestFileComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
