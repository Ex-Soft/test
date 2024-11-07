// https://muhimasri.com/blogs/react-mui-fieldset/

import { ReactNode } from "react";
import { Box, Typography } from "@mui/material";
import { SxProps, Theme } from "@mui/system";

export interface FieldsetWithMUIProps {
  title?: ReactNode;
  color?: string;
  titleSize?: string;
  borderWidth?: number;
  borderRadius?: number;
  children?: ReactNode;
  sx?: SxProps<Theme>;
}

const FieldsetWithMUI = ({
  title,
  color = "grey.800",
  titleSize = "1rem",
  borderWidth = 1,
  borderRadius = 2,
  children,
  sx = {},
  ...props
}: FieldsetWithMUIProps) => {
  return (
    <Box
      component="fieldset"
      sx={{
        borderColor: color,
        borderWidth: borderWidth,
        borderRadius: borderRadius,
        ...sx,
      }}
      {...props}
    >
      {!!title && (
        <Typography
          component="legend"
          sx={{
            color: color,
            fontSize: titleSize,
          }}
        >
          {title}
        </Typography>
      )}
      {children}
    </Box>
  );
};

export default FieldsetWithMUI;
