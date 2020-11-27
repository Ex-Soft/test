import { TestBed, async } from '@angular/core/testing';
import { AppComponent } from './app.component';
import { Dto2ViewPipe } from './pipes/dto2view.pipe';
import { ComplexObjectDto2ViewPipe } from './pipes/complexObjectDto2view.pipe';
import { TestInputComponent } from './components/test-input/test-input.component';
import { TestPipeComponent } from './components/test-pipe/test-pipe.component';
import { TestInputOutputComponent } from './components/test-input-output/test-input-output.component';
import { TestTestInputComponent } from './components/test/test-test-input/test-test-input.component';
import { SmthItemComponent } from './components/test/test-test-input/smth-item/smth-item.component';
import { IComplexObjectDto, IComplexObjectGroupDto, IComplexObjectGroupItemDto } from './models/IComplexObjectDto';

describe('AppComponent', () => {
  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [
        AppComponent,
        Dto2ViewPipe,
        ComplexObjectDto2ViewPipe,
        TestInputComponent,
        TestPipeComponent,
        TestInputOutputComponent,
        TestTestInputComponent,
        SmthItemComponent
      ],
    }).compileComponents();
  }));

  it('should create the app', () => {
    const fixture = TestBed.createComponent(AppComponent);
    const app = fixture.componentInstance;
    app.parentValue = 'parentValue';
    app.dto = [];
    app.complexObjectDto = {} as IComplexObjectDto;
    app.allChecked = true;
    expect(app).toBeTruthy();
  });

  it(`should have as title 'test-any'`, () => {
    const fixture = TestBed.createComponent(AppComponent);
    const app = fixture.componentInstance;
    app.parentValue = 'parentValue';
    app.dto = [];
    app.complexObjectDto = {} as IComplexObjectDto;
    app.allChecked = true;
    expect(app.title).toEqual('test-any');
  });

  it('should render title', () => {
    const fixture = TestBed.createComponent(AppComponent);
    const app = fixture.componentInstance;
    app.parentValue = 'parentValue';
    app.dto = [];
    app.complexObjectDto = {} as IComplexObjectDto;
    app.allChecked = true;
    fixture.detectChanges();
    const compiled = fixture.nativeElement;
    expect(compiled.querySelector('.content span').textContent).toContain('test-any app is running!');
  });
});
