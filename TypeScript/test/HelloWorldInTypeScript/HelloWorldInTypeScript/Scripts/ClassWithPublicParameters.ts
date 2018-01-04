class ClassWithPublicParameters {
    constructor(public x: number, public y: number) {}
}

class DerivedClassWithPublicParameters extends ClassWithPublicParameters {
    constructor(public x: number, public y: number) {
        super(x, y);
    }

    public getX(): number {
        return this.x;
    }

    public getY(): number {
        return this.y;
    }
}