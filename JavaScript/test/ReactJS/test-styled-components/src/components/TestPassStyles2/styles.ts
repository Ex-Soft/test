import styled from "styled-components";

export const TestPassStyles2Container = styled.div`
  display: grid;
  grid-template-columns: auto;
  width: 100%;
`;

export const TestPassStyles2Header = styled.div``;

export type TestPassStyles2ChildrenContainerProps = React.DetailedHTMLProps<
  React.HTMLAttributes<HTMLDivElement>,
  HTMLDivElement
> &
  React.CSSProperties;

export const TestPassStyles2ChildrenContainer = styled.div<TestPassStyles2ChildrenContainerProps>`
  ${(props) => !!props.alignSelf && `align-self: ${props.alignSelf};`}
  ${(props) => !!props.justifySelf && `justify-self: ${props.justifySelf};`}
  ${(props) => !!props.placeSelf && `place-self: ${props.placeSelf};`}
  color: white;
  background-color: red;
`;

/*
const StyledDiv = styled.div.attrs((props: { color: string }) => props)`
  width: 100%;
  height: 100%;
  background-color: ${(props) => props.color};
`;
*/
