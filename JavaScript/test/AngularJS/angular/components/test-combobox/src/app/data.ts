import { IData } from './IData';

export class Data implements IData {
    constructor(public id: number, public value: string) {}
}
