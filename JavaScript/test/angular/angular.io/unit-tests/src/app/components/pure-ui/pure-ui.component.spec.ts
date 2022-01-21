import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PureUiComponent } from './pure-ui.component';
import { IData } from '../components.type';

describe('PureUiComponent', () => {
  let component: PureUiComponent;
  let fixture: ComponentFixture<PureUiComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PureUiComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PureUiComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should render \'Data is undefined or null\'', () => {
    component.data = undefined;
    fixture.detectChanges();
    const compiled = fixture.nativeElement as HTMLElement;
    expect(compiled.querySelector('.pure-ui .data-pNumber')?.textContent).toBe('Data is undefined or null');
  });

  it('should render \'data.pNumber is undefined or null\'', () => {
    component.data = {} as IData;
    fixture.detectChanges();
    const compiled = fixture.nativeElement as HTMLElement;
    expect(compiled.querySelector('.pure-ui .data-pNumber')?.textContent).toBe('data.pNumber is undefined or null');
  });

  it('should render \'data.pNumber is below zero\'', () => {
    component.data = { pNumber: -13 } as IData;
    fixture.detectChanges();
    const compiled = fixture.nativeElement as HTMLElement;
    expect(compiled.querySelector('.pure-ui .data-pNumber')?.textContent).toBe('data.pNumber is below zero');
  });

  it('should render \'data.pNumber is above or equal to zero\'', () => {
    component.data = { pNumber: 13 } as IData;
    fixture.detectChanges();
    const compiled = fixture.nativeElement as HTMLElement;
    expect(compiled.querySelector('.pure-ui .data-pNumber')?.textContent).toBe('data.pNumber is above or equal to zero');
  });
});
