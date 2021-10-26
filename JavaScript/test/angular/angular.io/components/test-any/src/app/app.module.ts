import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { TestInputComponent } from './components/test-input/test-input.component';
import { Dto2ViewPipe } from './pipes/dto2view.pipe';
import { ComplexObjectDto2ViewPipe } from './pipes/complexObjectDto2view.pipe';
import { TestPipeComponent } from './components/test-pipe/test-pipe.component';
import { TestInputOutputComponent } from './components/test-input-output/test-input-output.component';
import { TestTestInputComponent } from './components/test/test-test-input/test-test-input.component';
import { SmthItemComponent } from './components/test/test-test-input/smth-item/smth-item.component';
import { CustomIconComponent } from './components/custom-icon/custom-icon.component';
import { CustomButtonComponent } from './components/custom-button/custom-button.component';
import { CustomButtonSimpleComponent } from './components/custom-button-simple/custom-button-simple.component';
import { CustomBaseComponent } from './components/inheritance/custom-base/custom-base.component';
import { CustomDerivedComponent } from './components/inheritance/custom-derived/custom-derived.component';
import { TestConditionalAttributesComponent } from './components/test-conditional-attributes/test-conditional-attributes.component';
import { TestFackerComponent } from './components/test-facker/test-facker.component';
import { TestSimpleComponent } from './components/test-simple/test-simple.component';
import { ExpandCollapseWithTemplateComponent } from './components/expand-collapse-with-template/expand-collapse-with-template.component';
import { TemplateComponentOneComponent } from './components/template-component-one/template-component-one.component';
import { ExpandCollapseWithContentComponent } from './components/expand-collapse-with-content/expand-collapse-with-content.component';
import { ContentComponentOneComponent } from './components/content-component-one/content-component-one.component';

@NgModule({
  declarations: [
    AppComponent,
    TestInputComponent,
    Dto2ViewPipe,
    ComplexObjectDto2ViewPipe,
    TestPipeComponent,
    TestInputOutputComponent,
    TestTestInputComponent,
    SmthItemComponent,
    CustomIconComponent,
    CustomButtonComponent,
    CustomButtonSimpleComponent,
    CustomBaseComponent,
    CustomDerivedComponent,
    TestConditionalAttributesComponent,
    TestFackerComponent,
    TestSimpleComponent,
    ExpandCollapseWithTemplateComponent,
    TemplateComponentOneComponent,
    ExpandCollapseWithContentComponent,
    ContentComponentOneComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
