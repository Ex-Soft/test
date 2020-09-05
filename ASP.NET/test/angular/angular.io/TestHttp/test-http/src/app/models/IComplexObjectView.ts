import { IComplexObjectDto, IComplexObjectGroupDto, IComplexObjectGroupItemDto } from '../core/state/complex-object/complex-object.type';

export interface IComplexObjectGroupItemView extends IComplexObjectGroupItemDto {
    checked: boolean;
}

export interface IComplexObjectGroupView extends IComplexObjectGroupDto {
    items: IComplexObjectGroupItemView[];
}

export interface IComplexObjectView extends IComplexObjectDto {
    groups: IComplexObjectGroupView[];
}
