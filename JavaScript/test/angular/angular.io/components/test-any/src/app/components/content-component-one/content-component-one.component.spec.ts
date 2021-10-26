import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ContentComponentOneComponent } from './content-component-one.component';
import { IPeopleView, IPerson } from '../../models';

const data = {
  people: [
    { id: 1, name: 'Name# 1' } as IPerson,
    { id: 2, name: 'Name# 2' } as IPerson,
    { id: 3, name: 'Name# 3' } as IPerson
  ]
} as IPeopleView;

describe('ContentComponentOneComponent', () => {
  let component: ContentComponentOneComponent;
  let fixture: ComponentFixture<ContentComponentOneComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ContentComponentOneComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ContentComponentOneComponent);
    component = fixture.componentInstance;
    component.data = data;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
