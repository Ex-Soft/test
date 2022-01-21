import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { TestInjectableComponent } from './components/test-injectable/test-injectable.component';

@NgModule({
  declarations: [
    AppComponent,
    TestInjectableComponent
  ],
  imports: [
    BrowserModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
