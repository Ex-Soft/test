import { IComplexObjectDto, IComplexObjectGroupDto, IComplexObjectGroupItemDto } from './IComplexObjectDto';

export interface IComplexObjectGroupItemView extends IComplexObjectGroupItemDto {
    checked: boolean;
}

export interface IComplexObjectGroupView extends IComplexObjectGroupDto {
    items: IComplexObjectGroupItemView[];
}

export interface IComplexObjectView extends IComplexObjectDto {
    groups: IComplexObjectGroupView[];
}
