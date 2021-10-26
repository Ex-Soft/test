import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { ComplexObjectComponent } from './components/complex-object/complex-object.component';
import { ComplexObjectDtoToViewPipe } from './pipes/complex-object-dto-to-view.pipe';
import { TodoComponent } from './components/todo/todo.component';
import { TodoDtoToViewPipe } from './pipes/todo-dto-to-view.pipe';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatRadioModule } from '@angular/material/radio';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatDialogModule } from '@angular/material/dialog';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { TestRadioButtonComponent } from './modals/test-radio-button/test-radio-button.component';
import { DialogWrapperComponent } from './components/dialog-wrapper/dialog-wrapper.component';
import { ModalBaseComponent } from './modals/modal-base/modal-base.component';
import { ModalDerivedComponent } from './modals/modal-derived/modal-derived.component';
import { TestStoreComponent } from './components/test-store/test-store.component';
import { TestAsyncComponent } from './components/test-async/test-async.component';
import { TestItemWithEnumComponent } from './components/test-item-with-enum/test-item-with-enum.component';
import { TestObservableComponent } from './components/rxjs/test-observable/test-observable.component';
import { TestUnitTestComponent } from './components/test-unit-test/test-unit-test.component';
import { TostringPipe } from './pipes/tostring.pipe';

@NgModule({
  declarations: [
    AppComponent,
    ComplexObjectComponent,
    ComplexObjectDtoToViewPipe,
    TodoComponent,
    TodoDtoToViewPipe,
    TestRadioButtonComponent,
    DialogWrapperComponent,
    ModalBaseComponent,
    ModalDerivedComponent,
    TestStoreComponent,
    TestAsyncComponent,
    TestItemWithEnumComponent,
    TestObservableComponent,
    TestUnitTestComponent,
    TostringPipe
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    BrowserAnimationsModule,
    MatRadioModule,
    MatIconModule,
    MatDialogModule,
    MatInputModule,
    MatButtonModule,
    MatCardModule,
    MatFormFieldModule,
    MatProgressSpinnerModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
