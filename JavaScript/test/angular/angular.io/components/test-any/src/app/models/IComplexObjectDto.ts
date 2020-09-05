export interface IComplexObjectGroupItemDto {
    id: number;
    name: string;
}

export interface IComplexObjectGroupDto {
    id: number;
    name: string;
    items: IComplexObjectGroupItemDto[];
}

export interface IComplexObjectDto {
    id: number;
    name: string;
    groups: IComplexObjectGroupDto[];
}
