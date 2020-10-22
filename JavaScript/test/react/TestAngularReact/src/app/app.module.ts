import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { ReactComponentWrapperComponent } from './components/react-component-wrapper/react-component-wrapper.component';

@NgModule({
  declarations: [
    AppComponent,
    ReactComponentWrapperComponent
  ],
  imports: [
    BrowserModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
