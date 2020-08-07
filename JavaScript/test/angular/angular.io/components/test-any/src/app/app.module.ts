import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { TestInputComponent } from './components/test-input/test-input.component';
import { Dto2ViewPipe } from './pipes/dto2view.pipe';
import { TestPipeComponent } from './components/test-pipe/test-pipe.component';
import { TestInputOutputComponent } from './components/test-input-output/test-input-output.component';

@NgModule({
  declarations: [
    AppComponent,
    TestInputComponent,
    Dto2ViewPipe,
    TestPipeComponent,
    TestInputOutputComponent
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
