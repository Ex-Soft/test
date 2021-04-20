export interface IVictimSubGroup {
    id: number;
    p1: string;
    p2: string;
    p3: string;
}

export interface IVictim {
    id: number;
    p1: string;
    p2: string;
    p3: string;
    p4: string;
    p5: string;
    subGroup1: IVictimSubGroup;
    subGroup2: IVictimSubGroup;
    subGroup3: IVictimSubGroup;
}
