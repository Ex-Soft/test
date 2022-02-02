import { Component, OnInit, ViewChild, AfterViewInit, ElementRef } from '@angular/core';

@Component({
  selector: 'app-child',
  templateUrl: './child.component.html',
  styleUrls: ['./child.component.css']
})
export class ChildComponent implements OnInit, AfterViewInit {
  checked!: boolean;
  value = 'from child';

  @ViewChild('button') button!: ElementRef;
  @ViewChild('btn') buttonByTemplateReferenceVariable!: ElementRef;
  @ViewChild('tref') tref!: ElementRef;

  constructor(private hostElement: ElementRef) {
    console.log('ChildComponent: hostElement = %o', hostElement);
   }

  ngOnInit(): void {
  }

  ngAfterViewInit(): void {
    console.log('ChildComponent: button = %o', this.button);
    console.log('ChildComponent: buttonByTemplateReferenceVariable = %o', this.buttonByTemplateReferenceVariable);
    console.log('ChildComponent: tref = %o', this.tref);
  }

  onLogClick(): void {
    console.log('ChildComponent: checked = %o', this.checked);
    console.log('ChildComponent: value = \"%s\"', this.value);
    console.log('ChildComponent: button = %o', this.button);
    console.log('ChildComponent: buttonByTemplateReferenceVariable = %o', this.buttonByTemplateReferenceVariable);
    console.log('ChildComponent: tref = %o', this.tref);
  }
}
