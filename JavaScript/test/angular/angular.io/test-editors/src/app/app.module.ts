import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AngularEditorModule } from '@kolkov/angular-editor';
import { NgxEditorModule } from "ngx-editor";

import { AppComponent } from './app.component';
import { TestAngularEditorComponent } from './components/test-angular-editor/test-angular-editor.component';
import { TestNgxEditorComponent } from './components/test-ngx-editor/test-ngx-editor.component';

@NgModule({
  declarations: [
    AppComponent,
    TestAngularEditorComponent,
    TestNgxEditorComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    AngularEditorModule,
    NgxEditorModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
