import * as S from "./styles";

export type TestPassStyles2Props = React.PropsWithChildren & {
  alignSelf?: string;
  justifySelf?: string;
  placeSelf?: string;
};

export const TestPassStyles2: React.FC<TestPassStyles2Props> = ({
  children,
  alignSelf,
  justifySelf,
  placeSelf,
}) => {
  return (
    <S.TestPassStyles2Container>
      <S.TestPassStyles2Header>Header</S.TestPassStyles2Header>
      <S.TestPassStyles2ChildrenContainer
        alignSelf={alignSelf}
        justifySelf={justifySelf}
        placeSelf={placeSelf}
      >
        {children}
      </S.TestPassStyles2ChildrenContainer>
    </S.TestPassStyles2Container>
  );
};

export default TestPassStyles2;
