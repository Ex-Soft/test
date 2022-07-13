import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TemplateComponentOneComponent } from '../template-component-one/template-component-one.component';
import { ExpandCollapseWithTemplateComponent } from './expand-collapse-with-template.component';

describe('ExpandCollapseComponentComponent', () => {
  let component: ExpandCollapseWithTemplateComponent;
  let fixture: ComponentFixture<ExpandCollapseWithTemplateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TemplateComponentOneComponent, ExpandCollapseWithTemplateComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ExpandCollapseWithTemplateComponent);
    component = fixture.componentInstance;
    component.legend = 'Legend';
    component.data = { people: [] };
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
