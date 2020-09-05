// https://medium.com/@bharat.tiwari/intercept-input-property-change-in-angular-690567eb63ec
// https://stackoverflow.com/questions/36653678/angular2-input-to-a-property-with-get-set

import { Component, OnInit, Input, OnChanges, SimpleChanges, SimpleChange, ElementRef } from '@angular/core';

@Component({
  selector: 'app-test-input',
  templateUrl: './test-input.component.html',
  styleUrls: ['./test-input.component.css']
})
export class TestInputComponent implements OnInit, OnChanges {
  private _valueWithGetterAndSetter: string;

  get valueWithGetterAndSetter(): string {
    if (window.console && console.log) {
      console.log('get() \"%s\"', this._valueWithGetterAndSetter);
    }

    return this._valueWithGetterAndSetter;
  }

  @Input() set valueWithGetterAndSetter(newValue: string) {
    if (window.console && console.log) {
      console.log('set(\"%s\")', newValue);
    }

    this._valueWithGetterAndSetter = newValue;
  }

  @Input() value: string;
  @Input() parentValue: string;

  constructor(private hostElement: ElementRef) {
    if (window.console && console.log) {
      console.log('TestInputComponent.ctor(%o) %o @Input()value=\"%s\"', hostElement, this, this.value);
    }
  }

  ngOnInit(): void {
    if (window.console && console.log) {
      console.log('TestInputComponent.ngOnInit(%o) %o @Input()value=\"%s\"', arguments, this, this.value);
    }
  }

  ngOnChanges(changes: SimpleChanges): void {
    const currentItemOfValueWithGetterAndSetter: SimpleChange = changes.valueWithGetterAndSetter;
    if (currentItemOfValueWithGetterAndSetter) {
      if (window.console && console.log) {
        console.log('ngOnChanges(): valueWithGetterAndSetter.previousValue = \"%s\" valueWithGetterAndSetter.currentValue = \"%s\" valueWithGetterAndSetter.firstChange = %o valueWithGetterAndSetter.isFirstChange() = %o', currentItemOfValueWithGetterAndSetter.previousValue, currentItemOfValueWithGetterAndSetter.currentValue, currentItemOfValueWithGetterAndSetter.firstChange, currentItemOfValueWithGetterAndSetter.isFirstChange());
      }
    }

    const currentItemOfValue: SimpleChange = changes.value;
    if (currentItemOfValue) {
      if (window.console && console.log) {
        console.log('ngOnChanges(): value.previousValue = \"%s\" value.currentValue = \"%s\" value.firstChange = %o value.isFirstChange() = %o', currentItemOfValue.previousValue, currentItemOfValue.currentValue, currentItemOfValue.firstChange, currentItemOfValue.isFirstChange());
      }
    }

    const currentItemOfParentValue: SimpleChange = changes.parentValue;
    if (currentItemOfParentValue) {
      if (window.console && console.log) {
        console.log('ngOnChanges(): parentValue.previousValue = \"%s\" parentValue.currentValue = \"%s\" parentValue.firstChange = %o parentValue.isFirstChange() = %o', currentItemOfParentValue.previousValue, currentItemOfParentValue.currentValue, currentItemOfParentValue.firstChange, currentItemOfParentValue.isFirstChange());
      }
    }
  }
}
