// https://stackoverflow.com/questions/38555744/injection-of-generic-services-in-angular

import { Component, OnInit } from '@angular/core';

import { BaseGenericClass, DerivedGenericClass, DerivedGenericConcreteClass, SmthClassForTestGeneric } from '../../classes';

@Component({
  selector: 'app-test-any',
  templateUrl: './test-any.component.html',
  styleUrls: ['./test-any.component.css']
})
export class TestAnyComponent implements OnInit {
  constructor() { }

  ngOnInit(): void {
  }

  onClickTestGeneric(): void {
    const baseGenericClass = new BaseGenericClass<string>('BaseGenericClass property# 1');
    const derivedGenericClass = new DerivedGenericClass<string>('BaseGenericClass property# 1', 'DerivedGenericClass property# 1');
    const derivedGenericConcreteClass = new DerivedGenericConcreteClass(
      new SmthClassForTestGeneric('BaseGenericConcreteClass property# 1'),
      new SmthClassForTestGeneric('DerivedGenericConcreteClass property# 1'));

    baseGenericClass.foo1();
    derivedGenericClass.foo1();
    derivedGenericConcreteClass.foo1();
  }
}
