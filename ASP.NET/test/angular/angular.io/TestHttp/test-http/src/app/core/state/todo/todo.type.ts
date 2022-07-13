export interface ITodoGroupItemDto {
    id: number;
    name: string;
}

export interface ITodoGroupDto {
    id: number;
    name: string;
    items: ITodoGroupItemDto[];
}

export interface ITodoDto {
    id: number;
    name: string;
    groups: ITodoGroupDto[];
}

export const createTodo = (params: Partial<ITodoDto>) => ({ ...params } as ITodoDto);

export const createTodos = (params: Array<Partial<ITodoDto>>) =>
  params.map(todo => createTodo(todo)) as ITodoDto[];
