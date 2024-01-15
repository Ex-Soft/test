import { useEffect, useState } from "react";
import "./index.css";

const UserOnlineStatus: React.FC<{ render: Function }> = ({ render }) => {
  const [isOnline, setIsOnline] = useState<boolean | undefined | null>(null);

  useEffect(() => {
    const timeout = setTimeout(() => {
      setIsOnline(true);
    }, 2000);

    return () => clearTimeout(timeout);
  }, []);

  return render(isOnline);
};

export default UserOnlineStatus;
