import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ExpandCollapseWithContentComponent } from './expand-collapse-with-content.component';

describe('ExpandCollapseWithContentComponent', () => {
  let component: ExpandCollapseWithContentComponent;
  let fixture: ComponentFixture<ExpandCollapseWithContentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ExpandCollapseWithContentComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ExpandCollapseWithContentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
