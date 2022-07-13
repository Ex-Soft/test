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

export const createComplexObject = (params: Partial<IComplexObjectDto>) => ({ ...params } as IComplexObjectDto);

export const createComplexObjects = (params: Array<Partial<IComplexObjectDto>>) =>
  params.map(complexObject => createComplexObject(complexObject)) as IComplexObjectDto[];
