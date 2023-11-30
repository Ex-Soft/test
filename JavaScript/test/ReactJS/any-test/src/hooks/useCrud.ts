import axios, { AxiosRequestConfig, CanceledError } from "axios";

export function useCrud({
  baseURL,
  setData,
  setIsLoading,
  setError,
}: {
  baseURL: string;
  setData: Function;
  setIsLoading: Function;
  setError: Function;
}): [Function] {
  const request = axios.create({ baseURL });

  function doCall(config: AxiosRequestConfig): Promise<any> {
    console.log("useCrud.doCall(%o)", config);

    return new Promise((resolve, reject) => {
      request(config)
        .then(function (response) {
          resolve(response.data);
        })
        .catch(function (error) {
          console.log(error);

          if (!(error instanceof CanceledError)) {
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
          }

          reject(!(error instanceof CanceledError) ? error : undefined);
        });
    });
  }

  const get = (params?: any) => {
    setError(undefined);
    setIsLoading(true);

    doCall({
      method: "get",
      ...(params && { params }),
    })
      .then(function (data: any) {
        setData(data);
      })
      .catch(function (error) {
        setData(undefined);
        setError(error);
      })
      .finally(function () {
        setIsLoading(false);
      });
  };

  return [get];
}
