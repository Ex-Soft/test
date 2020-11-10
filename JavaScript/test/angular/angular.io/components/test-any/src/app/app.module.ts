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

@NgModule({
  declarations: [
    AppComponent,
    TestInputComponent,
    Dto2ViewPipe,
    ComplexObjectDto2ViewPipe,
    TestPipeComponent,
    TestInputOutputComponent,
    TestTestInputComponent,
    SmthItemComponent
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
