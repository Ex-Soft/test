import * as React from 'react';
import { FunctionComponent } from 'react';

export interface IReactComponentProps {
    prop1: string;
    prop2: string;
    prop3: number;
}

export const ReactComponent: FunctionComponent<IReactComponentProps> = (props: IReactComponentProps) => {
    return <div className='reactComponent'><p>prop1: &#x22;{props.prop1}&#x22; (typeof &#x22;{typeof props.prop1}&#x22;)</p><p>prop2: &#x22;{props.prop2}&#x22; (typeof &#x22;{typeof props.prop2}&#x22;)</p><p>prop3: {props.prop3} (typeof &#x22;{typeof props.prop3}&#x22;)</p></div>;
};
