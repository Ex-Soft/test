import { PropsWithChildren } from "react";
import * as S from "./styles";

export type CustomButtonProps = PropsWithChildren & { disabled?: boolean };

export const CustomButton: React.FC<CustomButtonProps> = ({
  children,
  disabled,
}) => {
  const handleOnClick = (e: React.MouseEvent<HTMLButtonElement>) => {
    console.log("CustomButton.onClick(%o)", e);
  };

  return (
    <S.Button disabled={disabled} onClick={handleOnClick}>
      {children}
    </S.Button>
  );
};

export const CustomButtonAsA: React.FC<{ children: any }> = ({ children }) => {
  return (
    <S.Button as="a" href="#">
      {children}
    </S.Button>
  );
};

export const CustomTomatoButton: React.FC<CustomButtonProps> = ({
  children,
  disabled,
}) => {
  return <S.TomatoButton disabled={disabled}>{children}</S.TomatoButton>;
};

export const CustomTomatoButtonAsA: React.FC<{ children: any }> = ({
  children,
}) => {
  return (
    <S.TomatoButton as="a" href="#">
      {children}
    </S.TomatoButton>
  );
};

export const CustomReversedButton = (props: any) => (
  <CustomButton {...props} children={props.children.split("").reverse()} />
);

export const CustomButtonAsCustomReversedButton: React.FC<{
  children: any;
}> = ({ children }) => {
  return <S.Button as={CustomReversedButton}>{children}</S.Button>;
};
