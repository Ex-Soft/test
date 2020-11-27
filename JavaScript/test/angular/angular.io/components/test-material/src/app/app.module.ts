import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatSliderModule } from '@angular/material/slider';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatRadioModule } from '@angular/material/radio';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';

import { AppComponent } from './app.component';
import { TestCheckboxComponent } from './material/testcheckbox/testcheckbox.component';
import { TestSliderComponent } from './material/testslider/testslider.component';
import { TestRadiobuttonComponent } from './material/testradiobutton/testradiobutton.component';
import { CustomFilterPipe } from './pipes/custom-filter.pipe';
import { TestIconComponent } from './material/testicon/testicon.component';
import { TestinputComponent } from './material/testinput/testinput.component';

@NgModule({
  declarations: [
    AppComponent,
    TestCheckboxComponent,
    TestSliderComponent,
    TestRadiobuttonComponent,
    CustomFilterPipe,
    TestIconComponent,
    TestinputComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    BrowserAnimationsModule,
    MatSliderModule,
    MatCheckboxModule,
    MatRadioModule,
    MatIconModule,
    MatInputModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
