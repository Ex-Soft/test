import * as S from "./styles";

export const PureCSS: React.FC = () => {
  return (
    <S.PureCSSContainer>
      <S.PureCSSHeader>Pure CSS</S.PureCSSHeader>
      <div className="pureCSSClass">&lt;div class="pureCSSClass"&gt;&lt;/div&gt;</div>
    </S.PureCSSContainer>
  );
};

export default PureCSS;