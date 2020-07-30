import { Injectable } from '@angular/core';
import { BaseGenericClass } from './base-generic-class';

@Injectable({
    providedIn: 'root'
})
export class DerivedGenericClass<T> extends BaseGenericClass<T> {
    dp1: T;

    constructor(bp1: T, dp1: T) {
        super(bp1);

        this.dp1 = dp1;
    }

    foo1(): T {
        super.foo1();

        if (window.console && console.log) {
            console.log('DerivedGenericClass<T>.foo1() dp1 = %o', this.dp1);
        }

        return this.dp1;
    }
}
