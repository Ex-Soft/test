import { useState, useEffect } from "react";
import axios, { CanceledError } from "axios";

export const useDataApi = (
  initialUrl?: string,
  initialData?: any
): { data: any; isLoading: boolean; isError: boolean; setUrl: Function } => {
  const [data, setData] = useState(initialData);
  const [url, setUrl] = useState(initialUrl);
  const [isLoading, setIsLoading] = useState(false);
  const [isError, setIsError] = useState(false);

  useEffect(() => {
    let isActive = true;

    const controller = new AbortController();

    const fetchData = async () => {
      setIsError(false);
      setIsLoading(true);

      try {
        console.log('get("%s")', url);
        const response = await axios.get(url as string, {
          signal: controller.signal,
        });
        if (isActive) {
          setData(response.data);
        }
      } catch (error: any) {
        console.log(error);
        if (!(error instanceof CanceledError)) {
          setData(undefined);
          setIsError(true);

          if (error.response) {
            // The request was made and the server responded with a status code
            // that falls out of the range of 2xx
            console.log(
              '{ name: "%s", code: "%s", message: "%s", response: { data: "%s", status: %i, statusText: "%s", headers: %o } }',
              error.name,
              error.code,
              error.message,
              error.response.data,
              error.response.status,
              error.response.statusText,
              error.response.headers
            );
          } else if (error.request) {
            // The request was made but no response was received
            // `error.request` is an instance of XMLHttpRequest in the browser and an instance of
            // http.ClientRequest in node.js
            console.log(
              '{ name: "%s", code: "%s", message: "%s", request: %o }',
              error.name,
              error.code,
              error.message,
              error.request
            );
          } else {
            // Something happened in setting up the request that triggered an Error
            console.log("Error", error.message);
          }
          console.log(error.config);
        }
      }

      setIsLoading(false);
    };

    fetchData();

    return () => {
      controller.abort();
      isActive = false;
    };
  }, [url]);

  return { data, isLoading, isError, setUrl };
};
