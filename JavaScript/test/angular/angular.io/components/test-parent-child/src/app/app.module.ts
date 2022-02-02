import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { ParentComponent } from './components/parent/parent.component';
import { ChildComponent } from './components/child/child.component';
import { ViewEncapsulationShadowDomParentComponent } from './components/view-encapsulation/shadow-dom/view-encapsulation-shadow-dom-parent.component';
import { ViewEncapsulationShadowDomChildComponent } from './components/view-encapsulation/shadow-dom/view-encapsulation-shadow-dom-child.component';
import { ViewEncapsulationEmulatedParentComponent } from './components/view-encapsulation/emulated/view-encapsulation-emulated-parent.component';
import { ViewEncapsulationEmulatedChildComponent } from './components/view-encapsulation/emulated/view-encapsulation-emulated-child.component';
import { ViewEncapsulationNoneParentComponent } from './components/view-encapsulation/none/view-encapsulation-none-parent.component';
import { ViewEncapsulationNoneChildComponent } from './components/view-encapsulation/none/view-encapsulation-none-child.component';

@NgModule({
  declarations: [
    AppComponent,
    ParentComponent,
    ChildComponent,
    ViewEncapsulationShadowDomParentComponent,
    ViewEncapsulationShadowDomChildComponent,
    ViewEncapsulationEmulatedParentComponent,
    ViewEncapsulationEmulatedChildComponent,
    ViewEncapsulationNoneParentComponent,
    ViewEncapsulationNoneChildComponent
  ],
  imports: [
    BrowserModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
