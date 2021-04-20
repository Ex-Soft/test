import { ITodoDto, ITodoGroupDto, ITodoGroupItemDto } from '../core/state/todo/todo.type';

export interface ITodoGroupItemView extends ITodoGroupItemDto {
    checked?: boolean;
}

export interface ITodoGroupView extends ITodoGroupDto {
    items: ITodoGroupItemView[];
}

export interface ITodoView extends ITodoDto {
    groups: ITodoGroupView[];
}
