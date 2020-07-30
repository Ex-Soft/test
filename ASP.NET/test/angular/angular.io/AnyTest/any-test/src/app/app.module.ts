import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

import { httpInterceptorProviders } from './interceptors/index';
import { AppComponent } from './app.component';
import { TestHttpComponent } from './components/test-http/test-http.component';
import { TestAnyComponent } from './components/test-any/test-any.component';

@NgModule({
  declarations: [
    AppComponent,
    TestHttpComponent,
    TestAnyComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule
  ],
  providers: [httpInterceptorProviders],
  bootstrap: [AppComponent]
})
export class AppModule { }
