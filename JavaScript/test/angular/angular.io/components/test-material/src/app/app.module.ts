import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatSliderModule } from '@angular/material/slider';
import { MatDialogModule } from '@angular/material/dialog';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatRadioModule } from '@angular/material/radio';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { AngularEditorModule } from '@kolkov/angular-editor';

import { AppComponent } from './app.component';
import { TestCheckboxComponent } from './material/testcheckbox/testcheckbox.component';
import { TestSliderComponent } from './material/testslider/testslider.component';
import { TestRadiobuttonComponent } from './material/testradiobutton/testradiobutton.component';
import { CustomFilterPipe } from './pipes/custom-filter.pipe';
import { TestIconComponent } from './material/testicon/testicon.component';
import { TestinputComponent } from './material/testinput/testinput.component';
import { TestAutocompleteComponent } from './material/testautocomplete/testautocomplete/testautocomplete.component';
import { TestAutocompleteDifferentElementComponent } from './material/testautocomplete/testautocompletedifferentelement/testautocompletedifferentelement.component';
import { TestAutocompleteFirstOptionComponent } from './material/testautocomplete/testautocompletefirstoption/testautocompletefirstoption.component';
import { TestAutocompleteTriggerComponent } from './material/testautocomplete/testautocompletetrigger/testautocompletetrigger.component';
import { AddressyComponent } from './addressy/addressy/addressy.component';
import { AddressyModalComponent } from './addressy/addressy-modal/addressy-modal.component';
import { CustomComponentValidationOneComponent } from './form/custom-component-validation-one/custom-component-validation-one.component';
import { CustomComponentValidationOneFormComponent } from './form/custom-component-validation-one-form/custom-component-validation-one-form.component';
import { CustomComponentValidationTwoComponent } from './form/custom-component-validation-two/custom-component-validation-two.component';
import { CustomComponentValidationTwoFormComponent } from './form/custom-component-validation-two-form/custom-component-validation-two-form.component';
import { FormSimpleComponent } from './form/form-simple/form-simple.component';
import { SimpleComponentComponent } from './form/simple-component/simple-component.component';
import { TestValidationComponent } from './form/test-validation/test-validation.component';
import { TestspinnerComponent } from './material/testspinner/testspinner.component';
import { TestAngularEditorComponent } from './form/test-angular-editor/test-angular-editor.component';

@NgModule({
  declarations: [
    AppComponent,
    TestCheckboxComponent,
    TestSliderComponent,
    TestRadiobuttonComponent,
    CustomFilterPipe,
    TestIconComponent,
    TestinputComponent,
    TestAutocompleteComponent,
    TestAutocompleteDifferentElementComponent,
    TestAutocompleteFirstOptionComponent,
    TestAutocompleteTriggerComponent,
    AddressyComponent,
    AddressyModalComponent,
    CustomComponentValidationOneComponent,
    CustomComponentValidationOneFormComponent,
    CustomComponentValidationTwoComponent,
    CustomComponentValidationTwoFormComponent,
    FormSimpleComponent,
    SimpleComponentComponent,
    TestValidationComponent,
    TestspinnerComponent,
    TestAngularEditorComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    HttpClientModule,
    MatDialogModule,
    MatSliderModule,
    MatCheckboxModule,
    MatRadioModule,
    MatIconModule,
    MatInputModule,
    MatAutocompleteModule,
    MatProgressSpinnerModule,
    AngularEditorModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
