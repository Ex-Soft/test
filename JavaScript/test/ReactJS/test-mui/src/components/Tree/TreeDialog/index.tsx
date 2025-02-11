import Dialog from "@mui/material/Dialog";
import DialogTitle from "@mui/material/DialogTitle";
import DialogContent from "@mui/material/DialogContent";
import DialogActions from "@mui/material/DialogActions";
import Button from "@mui/material/Button";
import AddBoxIcon from "@mui/icons-material/AddBox";
import IndeterminateCheckBoxIcon from "@mui/icons-material/IndeterminateCheckBox";
import SvgIcon, { SvgIconProps } from "@mui/material/SvgIcon";
import { styled } from "@mui/material/styles";
import { RichTreeView } from "@mui/x-tree-view/RichTreeView";
import { TreeItem, treeItemClasses } from "@mui/x-tree-view/TreeItem";

import "./index.css";

export interface TreeDialogProps {
  open: boolean;
  title?: string;
  data?: any;
  onClose?: () => void;
}

const TreeDialog: React.FC<TreeDialogProps> = ({
  open = false,
  title = undefined,
  data = undefined,
  onClose = undefined,
}) => {
  const handleClose = () => {
    onClose?.();
  };

  const CustomTreeItem = styled(TreeItem)({
    [`& .${treeItemClasses.iconContainer}`]: {
      "& .close": {
        opacity: 0.3,
      },
    },
  });

  function CloseSquare(props: SvgIconProps) {
    return (
      <SvgIcon
        className="close"
        fontSize="inherit"
        style={{ width: 14, height: 14 }}
        {...props}
      >
        {/* tslint:disable-next-line: max-line-length */}
        <path d="M17.485 17.512q-.281.281-.682.281t-.696-.268l-4.12-4.147-4.12 4.147q-.294.268-.696.268t-.682-.281-.281-.682.294-.669l4.12-4.147-4.12-4.147q-.294-.268-.294-.669t.281-.682.682-.281.696 .268l4.12 4.147 4.12-4.147q.294-.268.696-.268t.682.281 .281.669-.294.682l-4.12 4.147 4.12 4.147q.294.268 .294.669t-.281.682zM22.047 22.074v0 0-20.147 0h-20.12v0 20.147 0h20.12zM22.047 24h-20.12q-.803 0-1.365-.562t-.562-1.365v-20.147q0-.776.562-1.351t1.365-.575h20.147q.776 0 1.351.575t.575 1.351v20.147q0 .803-.575 1.365t-1.378.562v0z" />
      </SvgIcon>
    );
  }

  return (
    <Dialog onClose={handleClose} open={open} fullWidth maxWidth="md">
      {!!title ? <DialogTitle>{title}</DialogTitle> : undefined}
      <DialogContent>
        <RichTreeView
          items={data}
          defaultExpandedItems={["12"]}
          aria-label="tree-dialog"
          slots={{
            expandIcon: AddBoxIcon,
            collapseIcon: IndeterminateCheckBoxIcon,
            endIcon: CloseSquare,
            item: CustomTreeItem,
          }}
          sx={{ height: 264, flexGrow: 1 }}
        />
      </DialogContent>
      <DialogActions>
        <Button onClick={handleClose} autoFocus>
          Close
        </Button>
      </DialogActions>
    </Dialog>
  );
};

export default TreeDialog;
