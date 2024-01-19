import * as S from "./styles";

const ComponentWithChildren: React.FC = () => {
  return (
    <S.ComponentWithChildrenContainer>
      <div>
        <div className="divInner"></div>
      </div>
    </S.ComponentWithChildrenContainer>
  );
};

export default ComponentWithChildren;
