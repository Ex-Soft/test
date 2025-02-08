import * as S from "./styles";

export const PureCSS: React.FC = () => {
  return (
    <S.PureCSSContainer>
      <S.PureCSSHeader>Pure CSS</S.PureCSSHeader>
      <div className="pureCSSClass1">&lt;div class="pureCSSClass1"&gt;&lt;/div&gt;</div>
      <S.DivWithPureCSSClass2Wrapper><div className="pureCSSClass2">&lt;div class="pureCSSClass2"&gt;&lt;/div&gt;</div></S.DivWithPureCSSClass2Wrapper>
      <S.DivWithPureCSSClass3 className="pureCSSClass3">&lt;DivWithPureCSSClass3 /&gt;</S.DivWithPureCSSClass3>
      <div className="pureCSSClass4">&lt;div class="pureCSSClass4"&gt;&lt;/div&gt;</div>
      <div className="colorRed">&lt;div class="colorRed"&gt;&lt;/div&gt;</div>
    </S.PureCSSContainer>
  );
};

export default PureCSS;