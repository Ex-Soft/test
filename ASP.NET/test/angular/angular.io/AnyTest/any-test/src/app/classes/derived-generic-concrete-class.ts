import { BaseGenericClass } from './base-generic-class';
import { SmthClassForTestGeneric } from './smth-class-for-test-generic';

export class DerivedGenericConcreteClass extends BaseGenericClass<SmthClassForTestGeneric> {
    dp1: SmthClassForTestGeneric;

    constructor(bp1: SmthClassForTestGeneric, dp1: SmthClassForTestGeneric) {
        super(bp1);

        this.dp1 = dp1;
    }

    foo1(): SmthClassForTestGeneric {
        super.foo1();

        if (window.console && console.log) {
            console.log('DerivedGenericConcreteClass.foo1() dp1 = %o', this.dp1);
        }

        return this.dp1;
    }
}
