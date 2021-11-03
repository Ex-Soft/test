import { TestBed, waitForAsync } from '@angular/core/testing';

import { FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { Dto2ViewPipe } from './pipes/dto2view.pipe';
import { ComplexObjectDto2ViewPipe } from './pipes/complexObjectDto2view.pipe';
import { TestInputComponent } from './components/test-input/test-input.component';
import { TestPipeComponent } from './components/test-pipe/test-pipe.component';
import { TestInputOutputComponent } from './components/test-input-output/test-input-output.component';
import { TestTestInputComponent } from './components/test/test-test-input/test-test-input.component';
import { SmthItemComponent } from './components/test/test-test-input/smth-item/smth-item.component';
import { CustomButtonComponent } from './components/custom-button/custom-button.component';
import { CustomIconComponent } from './components/custom-icon/custom-icon.component';
import { TestInjectableComponent } from './components/test-injectable/test-injectable.component';
import { TestWatchingComponent } from './components/test-watching/test-watching.component';
import { ExpandCollapseWithTemplateComponent } from './components/expand-collapse-with-template/expand-collapse-with-template.component';
import { TemplateComponentOneComponent } from './components/template-component-one/template-component-one.component';
import { TestSimpleComponent } from './components/test-simple/test-simple.component';
import { TestFackerComponent } from './components/test-facker/test-facker.component';
import { TestConditionalAttributesComponent } from './components/test-conditional-attributes/test-conditional-attributes.component';
import { CustomBaseComponent } from './components/inheritance/custom-base/custom-base.component';
import { CustomDerivedComponent } from './components/inheritance/custom-derived/custom-derived.component';
import { ContentComponentOneComponent } from './components/content-component-one/content-component-one.component';
import { ExpandCollapseWithContentComponent } from './components/expand-collapse-with-content/expand-collapse-with-content.component';
import { IComplexObjectDto, IComplexObjectGroupDto, IComplexObjectGroupItemDto } from './models/IComplexObjectDto';

describe('AppComponent', () => {
  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      imports: [FormsModule],
      declarations: [
        AppComponent,
        Dto2ViewPipe,
        ComplexObjectDto2ViewPipe,
        TestInputComponent,
        TestPipeComponent,
        TestInputOutputComponent,
        TestTestInputComponent,
        SmthItemComponent,
        CustomButtonComponent,
        CustomIconComponent,
        TestInjectableComponent,
        TestWatchingComponent,
        ExpandCollapseWithTemplateComponent,
        TemplateComponentOneComponent,
        TestSimpleComponent,
        TestFackerComponent,
        TestConditionalAttributesComponent,
        CustomBaseComponent,
        CustomDerivedComponent,
        ContentComponentOneComponent,
        ExpandCollapseWithContentComponent
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
