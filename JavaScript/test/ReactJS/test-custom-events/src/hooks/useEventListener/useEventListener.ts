import { useEffect } from "react";
import { CustomEvents } from "./CustomEvents";

export function useEventListener<T extends keyof CustomEvents>(
  eventName: T,
  handler: (detail: CustomEvents[T]) => void
) {
  useEffect(() => {
    const eventHandler = (event: CustomEvent<CustomEvents[T]>) => {
      handler(event.detail);
    };

    document.addEventListener(eventName, eventHandler as EventListener);
    return () => {
      document.removeEventListener(eventName, eventHandler as EventListener);
    };
  }, [eventName, handler]);
}
