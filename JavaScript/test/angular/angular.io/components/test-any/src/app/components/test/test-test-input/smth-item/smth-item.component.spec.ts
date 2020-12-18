import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';

import { SmthItemComponent } from './smth-item.component';
import { SmthType } from '../smth.type';

const mockItem = { pString1: '3.1', pString2: '3.2', pString3: '3.3', pNumber1: 2, pNumber2: 2, pNumber3: 3 } as SmthType;

describe('SmthItemComponent', () => {
  let component: SmthItemComponent;
  let fixture: ComponentFixture<SmthItemComponent>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ SmthItemComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SmthItemComponent);
    component = fixture.componentInstance;
    component.smthItem = mockItem;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
