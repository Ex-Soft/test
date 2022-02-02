import { Component, OnInit, ViewChild, AfterViewInit, ElementRef } from '@angular/core';
import { ChildComponent } from '../child/child.component';

@Component({
  selector: 'app-parent',
  templateUrl: './parent.component.html',
  styleUrls: ['./parent.component.css']
})
export class ParentComponent implements OnInit, AfterViewInit {
  @ViewChild(ChildComponent) child!: ChildComponent;

  @ViewChild('button') button!: ElementRef;

  constructor(private hostElement: ElementRef) {
    console.log('ParentComponent: hostElement = %o', hostElement);
  }

  ngOnInit(): void {
  }

  ngAfterViewInit(): void {
    console.log('ParentComponent: child = %o', this.child);
    console.log('ParentComponent: button = %o', this.button);
  }

  onBtnClick(): void {
    this.child.value = 'from parent';
  }
}
