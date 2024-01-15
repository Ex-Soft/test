// https://www.developerway.com/posts/how-to-handle-errors-in-react

import React, { PropsWithChildren, ReactElement } from "react";
import "./index.css";

type ErrorBoundaryProps = PropsWithChildren & { fallback: ReactElement };
type State = { hasError: boolean };

class ErrorBoundary extends React.Component<ErrorBoundaryProps, State> {
  constructor(props: any) {
    super(props);
    this.state = { hasError: false };
    console.log("ErrorBoundary.ctor(%o) state=%o", props, this.state);
  }

  static getDerivedStateFromError(error: unknown) {
    console.log("ErrorBoundary.getDerivedStateFromError(%o)", error);
    return { hasError: true };
  }

  componentDidCatch(error: Error, errorInfo: React.ErrorInfo) {
    console.log("componentDidCatch(%o, %o)", error, errorInfo);
  }

  render() {
    console.log("ErrorBoundary.render() state=%o", this.state);

    if (this.state.hasError) {
      return this.props.fallback;
    } else {
      return this.props.children;
    }
  }
}

export default ErrorBoundary;
