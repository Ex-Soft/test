import styled from "styled-components";
import { colors } from "../../theme";

interface ButtonProps {
  $height?: string;
  $width?: string;
  $borderRadius?: string;
}

export const Button = styled.div<ButtonProps>`
  height: ${(props) => props.$height || "50px"};
  width: ${(props) => props.$width || "100px"};
  ${(props) => !!props.$borderRadius && `border-radius: ${props.$borderRadius};`}
  color: ${colors.white};
  display: flex;
  align-items: center;
  justify-content: center;

  &:hover {
    cursor: pointer;
  }

  &:not([data-status]) {
    background-color: ${colors.red};
  }

  &[data-status="false"] {
    background-color: ${colors.red};
  }

  &[data-status="true"] {
    background-color: ${colors.green};
  }
`;
