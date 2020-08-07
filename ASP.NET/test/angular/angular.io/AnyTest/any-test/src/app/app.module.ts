import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { httpInterceptorProviders } from './interceptors/index';
import { AppComponent } from './app.component';
import { TestHttpComponent } from './components/test-http/test-http.component';
import { TestAnyComponent } from './components/test-any/test-any.component';
import { TestTestComponent } from './components/test-test/test-test.component';

@NgModule({
  declarations: [
    AppComponent,
    TestHttpComponent,
    TestAnyComponent,
    TestTestComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [httpInterceptorProviders],
  bootstrap: [AppComponent]
})
export class AppModule { }
