class TestClassWithInterface implements ITestInterface {
    interfaceProperty1: string;

    constructor(aInterfaceProperty1: string) {
        this.interfaceProperty1 = aInterfaceProperty1;
    }
}