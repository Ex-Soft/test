import styled from "styled-components";
import { colors } from "../../theme";

export const ComponentWithChildrenContainer = styled.div`
  display: flex;
  flex-flow: row wrap;
  justify-content: center;
  align-items: center;
  align-content: center;
  height: 100px;
  width: 100%;
  background-color: ${colors.blue};

  & div {
    display: flex;
    flex-flow: row wrap;
    justify-content: center;
    align-items: center;
    align-content: center;
    height: 50%;
    width: 50%;
    background-color: ${colors.green};
  }

  & div .divInner {
    background-color: ${colors.red};
  }
`;
