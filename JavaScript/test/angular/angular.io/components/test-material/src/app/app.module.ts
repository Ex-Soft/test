import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatSliderModule } from '@angular/material/slider';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatRadioModule } from '@angular/material/radio';

import { AppComponent } from './app.component';
import { TestCheckboxComponent } from './material/testcheckbox/testcheckbox.component';
import { TestSliderComponent } from './material/testslider/testslider.component';
import { TestRadiobuttonComponent } from './material/testradiobutton/testradiobutton.component';
import { CustomFilterPipe } from './pipes/custom-filter.pipe';

@NgModule({
  declarations: [
    AppComponent,
    TestCheckboxComponent,
    TestSliderComponent,
    TestRadiobuttonComponent,
    CustomFilterPipe
  ],
  imports: [
    BrowserModule,
    FormsModule,
    BrowserAnimationsModule,
    MatSliderModule,
    MatCheckboxModule,
    MatRadioModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
