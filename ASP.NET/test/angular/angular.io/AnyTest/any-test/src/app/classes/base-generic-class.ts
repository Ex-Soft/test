import { Injectable } from '@angular/core';

@Injectable({
    providedIn: 'root'
})
export class BaseGenericClass<T> {
    bp1: T;

    constructor(bp1: T) {
        this.bp1 = bp1;
    }

    foo1(): T {
        if (window.console && console.log) {
            console.log('BaseGenericClass<T>.foo1() bp1 = %o', this.bp1);
        }

        return this.bp1;
    }
}
