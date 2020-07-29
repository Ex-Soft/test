import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { TestHttpComponent } from './components/test-http/test-http.component';
import { httpInterceptorProviders } from './interceptors/index';

@NgModule({
  declarations: [
    AppComponent,
    TestHttpComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule
  ],
  providers: [httpInterceptorProviders],
  bootstrap: [AppComponent]
})
export class AppModule { }
