import styled, { Interpolation } from "styled-components";

export const TestPassStyles1Container = styled.div`
  display: grid;
  grid-template-columns: auto;
  width: 100%;
`;

export const TestPassStyles1Header = styled.div``;

export interface TestPassStyles1ChildrenContainerProps {
  $styles?: Interpolation<React.CSSProperties>;
}

export const TestPassStyles1ChildrenContainer = styled.div<TestPassStyles1ChildrenContainerProps>`
  ${({ $styles }) => $styles}
`;
