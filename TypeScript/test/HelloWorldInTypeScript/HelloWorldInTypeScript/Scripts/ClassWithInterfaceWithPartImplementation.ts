class ClassWithInterfaceWithPartImplementation implements IInterfaceWithPartImplementation {
    pString2: string;
    pString3: string;

    constructor(public pString1: string, pString4?: string) {
        this.pString2 = ".ctor()";
    }
}

let classWithInterfaceWithPartImplementation = new ClassWithInterfaceWithPartImplementation("RunTime");
