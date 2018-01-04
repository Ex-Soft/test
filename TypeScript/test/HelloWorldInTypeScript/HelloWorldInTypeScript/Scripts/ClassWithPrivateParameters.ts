class ClassWithPrivateParameters {
    constructor(private x: number, private y: number) {}
}

class DerivedClassWithPrivateParameters extends ClassWithPrivateParameters {
    constructor(/*private */x: number, /*private */y: number) {
        super(x, y);
    }

    /*public getX(): number {
        return this.x;
    }

    public getY(): number {
        return this.y;
    }*/
}