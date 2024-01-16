import * as S from "./styles";

export type CustomDivProps = {
  height?: string;
  width?: string;
  borderRadius?: string;
  enabled?: boolean;
};

const CustomDiv: React.FC<CustomDivProps> = ({
  height,
  width,
  borderRadius,
  enabled,
}) => {
  return (
    <S.Button
      data-status={enabled}
      $height={height}
      $width={width}
      $borderRadius={borderRadius}
    >
      {!!enabled ? "Enabled" : "Disabled"}
    </S.Button>
  );
};

export default CustomDiv;
