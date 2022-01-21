// https://hackwild.com/article/event-handling-techniques/

import { Injectable } from '@angular/core';
import { EventEmitter } from 'events';

@Injectable({ providedIn: 'root' })
export class TestInjectableClassWithEvents extends EventEmitter {
    constructor() {
        super();

        console.log('TestInjectableClassWithEvents.ctor()');
    }

    fire(): void {
        this.emit('timer', new Date());
    }
}

export class TestInjectableClassWrapperBase {
    pString: string;
    pArrayOfString: string[];

    constructor() {
        this.pString = 'pString (from .ctor())';
        this.pArrayOfString = [
            'pArrayOfString #0 (from .ctor())',
            'pArrayOfString #1 (from .ctor())',
            'pArrayOfString #2 (from .ctor())'
        ];

        console.log('TestInjectableClassWrapperBase.ctor()');
    }

    get PString(): string {
        return this.pString;
    }

    get PArrayOfString(): string[] {
        return this.pArrayOfString;
    }
}

@Injectable({ providedIn: 'root' })
export class TestInjectableClassWrapper extends TestInjectableClassWrapperBase {

    constructor(
        private testInjectableClass1: TestInjectableClass1,
        private testInjectableClass2: TestInjectableClass2
    ) {
        super();

        console.log('TestInjectableClassWrapper.ctor()');
    }

    get PString1(): string {
        return this.testInjectableClass1.PString;
    }

    get PArrayOfString1(): string[] {
        return this.testInjectableClass1.PArrayOfString;
    }

    get PString2(): string {
        return this.testInjectableClass2.PString;
    }

    get PArrayOfString2(): string[] {
        return this.testInjectableClass2.PArrayOfString;
    }
}

@Injectable({ providedIn: 'root' })
export class TestInjectableClass1 {
    private pString: string;
    private pArrayOfString: string[];

    constructor() {
        this.pString = 'PString1 (from .ctor())';
        this.pArrayOfString = [
            'PArrayOfString1 #0 (from .ctor())',
            'PArrayOfString1 #1 (from .ctor())',
            'PArrayOfString1 #2 (from .ctor())'
        ];

        console.log('TestInjectableClass1.ctor()');
    }

    get PString(): string {
        return this.pString;
    }

    get PArrayOfString(): string[] {
        return this.pArrayOfString;
    }
}

@Injectable({ providedIn: 'root' })
export class TestInjectableClass2 {
    private pString: string;
    private pArrayOfString: string[];

    constructor() {
        this.pString = 'PString2 (from .ctor())';
        this.pArrayOfString = [
            'PArrayOfString2 #0 (from .ctor())',
            'PArrayOfString2 #1 (from .ctor())',
            'PArrayOfString2 #2 (from .ctor())'
        ];

        console.log('TestInjectableClass2.ctor()');
    }

    get PString(): string {
        return this.pString;
    }

    get PArrayOfString(): string[] {
        return this.pArrayOfString;
    }
}
