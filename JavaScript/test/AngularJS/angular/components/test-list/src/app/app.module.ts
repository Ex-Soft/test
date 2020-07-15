import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { TestlistComponent } from './testlist/testlist.component';
import { TestlistitemsComponent } from './testlist/testlistitems.component';

@NgModule({
  declarations: [
    AppComponent,
    TestlistComponent,
    TestlistitemsComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
