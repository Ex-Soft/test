import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TemplateComponentOneComponent } from './template-component-one.component';

describe('TemplateComponentComponentOne', () => {
  let component: TemplateComponentOneComponent;
  let fixture: ComponentFixture<TemplateComponentOneComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TemplateComponentOneComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TemplateComponentOneComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
