import styled from "styled-components";
import { colors } from "../../theme";

export const Button = styled.button`
  color: #bf4f74;
  font-size: 1em;
  margin: 1em;
  padding: 0.25em 1em;
  border: 2px solid #bf4f74;
  border-radius: 3px;

  &:hover:not(:disabled) {
    background-color: ${colors.blue};
  }
`;

export const TomatoButton = styled(Button)`
  color: tomato;
  border-color: tomato;
`;
