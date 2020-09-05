import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http'; 

import { AppComponent } from './app.component';
import { ComplexObjectComponent } from './components/complex-object/complex-object.component';
import { ComplexObjectDtoToViewPipe } from './pipes/complex-object-dto-to-view.pipe';
import { TodoComponent } from './components/todo/todo.component';
import { TodoDtoToViewPipe } from './pipes/todo-dto-to-view.pipe';

@NgModule({
  declarations: [
    AppComponent,
    ComplexObjectComponent,
    ComplexObjectDtoToViewPipe,
    TodoComponent,
    TodoDtoToViewPipe
  ],
  imports: [
    BrowserModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
