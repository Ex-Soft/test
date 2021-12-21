import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { PureUiComponent } from './components/pure-ui/pure-ui.component';
import { WithDataServiceComponent } from './components/with-service/with-data-service.component';

@NgModule({
  declarations: [
    AppComponent,
    PureUiComponent,
    WithDataServiceComponent
  ],
  imports: [
    BrowserModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
