// https://stackoverflow.com/questions/67990513/how-to-pass-styles-via-props-with-styled-components-without-having-to-create-the

import { Interpolation } from "styled-components";
import * as S from "./styles";

export type TestPassStyles1Props = React.PropsWithChildren & {
  childrenContainerStyles?: Interpolation<React.CSSProperties>;
};

export const TestPassStyles1: React.FC<TestPassStyles1Props> = ({
  children,
  childrenContainerStyles,
}) => {
  return (
    <S.TestPassStyles1Container>
      <S.TestPassStyles1Header>Header</S.TestPassStyles1Header>
      <S.TestPassStyles1ChildrenContainer $styles={childrenContainerStyles}>
        {children}
      </S.TestPassStyles1ChildrenContainer>
    </S.TestPassStyles1Container>
  );
};

export default TestPassStyles1;
