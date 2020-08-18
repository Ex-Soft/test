import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { httpInterceptorProviders } from './interceptors/index';
import { AppComponent } from './app.component';
import { TestHttpComponent } from './components/test-http/test-http.component';
import { TestAnyComponent } from './components/test-any/test-any.component';
import { TestTestComponent } from './components/test-test/test-test.component';
import { TestTestInjectComponent } from './components/test-test-inject/test-test-inject.component';
import { VICTIM_INJECTION_TOKEN, VICTIM_VALUE} from './components/test-test-inject/victim';
import { APP_CONFIG, APP_DI_CONFIG } from './app.config';

@NgModule({
  declarations: [
    AppComponent,
    TestHttpComponent,
    TestAnyComponent,
    TestTestComponent,
    TestTestInjectComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [
    httpInterceptorProviders,
    { provide: VICTIM_INJECTION_TOKEN, useValue: VICTIM_VALUE },
    { provide: APP_CONFIG, useValue: APP_DI_CONFIG }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
