class ClassWithProtectedParameters {
    constructor(protected x: number, protected y: number) {}
}

class DerivedClassWithProtectedParameters extends ClassWithProtectedParameters {
    constructor(protected x: number, protected y: number) {
        super(x, y);
    }

    public getX(): number {
        return this.x;
    }

    public getY(): number {
        return this.y;
    }
}