import styled, { css } from "styled-components";
import "./pureCSSClass3.css";

export const PureCSSContainer = styled.div``;
export const PureCSSHeader = styled.div``;

export const pureCSSClass2 = `
  .pureCSSClass2 {
    color: white;
    background-color: blue;
  }
`;

export const DivWithPureCSSClass2Wrapper = styled.div`
  ${pureCSSClass2}
`;

export const DivWithPureCSSClass3 = styled.div`
  ${css`.pureCSSClass3 {}`}
`;

export const pureCSSClass4 = css`
  .pureCSSClass4 {
    border: 1px solid green;
  }
`;
